using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using JetSystems;

public class MoneyScript : MonoBehaviour
{
    int[] amounts = { 500, 2000, 5000, 10000 };
    int currentAmountIndex = 0;
    int stoppedAmount;
    bool isStopped = false;

    public Text moneyText;
    public Button button;

    void Start()
    {
        StartCoroutine(ChangeAmount());
    }

    IEnumerator ChangeAmount()
    {
        while (!isStopped)
        {
            int currentAmount = amounts[currentAmountIndex];
            moneyText.text = "Монет: " + currentAmount;

            yield return new WaitForSeconds(1);

            if (!isStopped)
            {
                currentAmountIndex = (currentAmountIndex + 1) % amounts.Length;
            }
        }
    }

    public void OnButtonPress()
    {
        isStopped = true;
        stoppedAmount = amounts[currentAmountIndex];
        moneyText.text = "Выиграно: " + stoppedAmount;

        switch (stoppedAmount)
        {
            case 500:
                UIManager.AddCoins(500);
                break;
            case 2000:
                UIManager.AddCoins(2000);
                break;
            case 5000:
                UIManager.AddCoins(5000);
                break;
            case 10000:
                UIManager.AddCoins(10000);
                break;
        }

        button.interactable = false;
    }
}
