using NuclearDecline;
using UnityEngine;

public class NewResultLeaderboard : MonoBehaviour
{
    public static NewResultLeaderboard instance;

    [SerializeField] private string leaderboardName = "leaderboard";

    private void Awake()
    {
        instance = this;
    }

    public void UpdateLeader()
    {
        if (LavaFloor.instance == null)
            return;

        GamePlatformBridge.Leaderboards.SetScore(leaderboardName, LavaFloor.instance.LBKillScore);
        GamePlatformBridge.Leaderboards.RequestLeaderboard(leaderboardName);
    }
}
