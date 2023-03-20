[System.Serializable]

public class LeaderboardModel
{ 

    public int leaderboard_score;

    public string leaderboard_name;

    public LeaderboardModel(int leaderboard_score, string leaderboard_name)
    {

        this.leaderboard_score = leaderboard_score;
        this.leaderboard_name = leaderboard_name;

    }

}
