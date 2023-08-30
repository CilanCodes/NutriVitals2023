using System.Collections.Generic;

[System.Serializable]

public class UserModel
{

    public List<LeaderboardModel> leaderboard;

    public int user_character_state;

    public string user_name;

    public UserModel(User user)
    {

        leaderboard = user.Leaderboard;
        user_character_state = user.UserCharacterState;
        user_name = user.UserName;

    }

}
