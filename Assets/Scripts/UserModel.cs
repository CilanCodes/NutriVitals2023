using System.Collections.Generic;

[System.Serializable]

public class UserModel
{

    public List<int> leaderboard_scores;

    public int user_character_state;

    public string user_name;

    public UserModel(User user)
    {

        leaderboard_scores = user.LeaderboardScores;
        user_character_state = user.UserCharacterState;
        user_name = user.UserName;

    }

}
