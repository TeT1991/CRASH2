using UnityEngine;
using UnityEngine.UI;
using YG;

public class NewResultLeaderboard : MonoBehaviour
{
    public static NewResultLeaderboard instance;

    [SerializeField] LeaderboardYG leaderboardYG;

    private void Awake()
    {
        instance = this;
    }


    public void UpdateLeader()
    {
        Debug.Log("+1");
       leaderboardYG.NewScore(+LavaFloor.instance.LBKillScore);
        YandexGame.SaveProgress();
        leaderboardYG.UpdateLB();
    }


}
