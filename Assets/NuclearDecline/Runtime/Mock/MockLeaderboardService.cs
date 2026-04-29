using UnityEngine;

namespace NuclearDecline
{
    public sealed class MockLeaderboardService : ILeaderboardService
    {
        public void SetScore(string leaderboardName, int score)
        {
            Debug.Log("[NuclearDecline] Mock leaderboard score set: " + leaderboardName + " = " + score);
        }

        public void RequestLeaderboard(string leaderboardName)
        {
            Debug.Log("[NuclearDecline] Mock leaderboard requested: " + leaderboardName);
        }
    }
}
