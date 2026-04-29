using UnityEngine;
using UnityEngine.UI;
using JetSystems;
using NuclearDecline;

public class MoneyScript : MonoBehaviour
{
    private int levelStartCoins;
    private int earnedCoins;
    private bool rewardClaimed;

    public Text moneyText;
    public Button button;

    private void OnEnable()
    {
        UIManager.onGameSet += ResetEarnedCoins;
        UIManager.onLevelCompleteSet += UpdateEarnedCoinsOnLevelComplete;
    }

    private void OnDisable()
    {
        UIManager.onGameSet -= ResetEarnedCoins;
        UIManager.onLevelCompleteSet -= UpdateEarnedCoinsOnLevelComplete;
    }

    void Start()
    {
        levelStartCoins = UIManager.COINS;
        earnedCoins = Mathf.Max(0, UIManager.COINS - levelStartCoins);
        UpdateRewardText();
    }

    public void OnButtonPress()
    {
        if (rewardClaimed)
            return;

        if (button != null)
            button.interactable = false;

        GamePlatformBridge.Ads.ShowRewarded("double_reward", OnRewardedAdComplete);
    }

    private void OnRewardedAdComplete(AdResult result)
    {
        if (!result.IsSuccess)
        {
            if (button != null)
                button.interactable = true;

            return;
        }

        int bonus = GetEarnedCoins();
        earnedCoins = bonus;
        rewardClaimed = true;

        UIManager.AddCoins(bonus);

        if (button != null)
            button.interactable = false;

        UpdateRewardText();
    }

    public void SetEarnedCoins(int earnedCoins)
    {
        this.earnedCoins = Mathf.Max(0, earnedCoins);
        rewardClaimed = false;

        if (button != null)
            button.interactable = true;

        UpdateRewardText();
    }

    private void ResetEarnedCoins()
    {
        levelStartCoins = UIManager.COINS;
        earnedCoins = 0;
        rewardClaimed = false;

        if (button != null)
            button.interactable = true;

        UpdateRewardText();
    }

    private void UpdateEarnedCoinsOnLevelComplete(int starsCount)
    {
        SetEarnedCoins(UIManager.COINS - levelStartCoins);
    }

    private void UpdateRewardText()
    {
        if (moneyText != null)
            moneyText.text = "Бонус x2: +" + GetEarnedCoins();
    }

    private int GetEarnedCoins()
    {
        if (earnedCoins > 0)
            return earnedCoins;

        return Mathf.Max(0, UIManager.COINS - levelStartCoins);
    }
}
