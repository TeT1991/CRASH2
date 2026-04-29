namespace NuclearDecline
{
    public interface ILeaderboardService
    {
        void SetScore(string leaderboardName, int score);
        void RequestLeaderboard(string leaderboardName);
    }
}
