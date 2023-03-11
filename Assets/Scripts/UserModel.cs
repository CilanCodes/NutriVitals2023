using System.Collections.Generic;

[System.Serializable]

public class UserModel
{
    public List<int> leaderboardScores;

    public UserModel(User user)
    {

        leaderboardScores = user.leaderboardScores;

    }

}
