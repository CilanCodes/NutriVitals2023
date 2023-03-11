using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    public List<int> LeaderboardScores { get; set; }

    public int UserCharacterState { get; set; }

    public string UserName { get; set; }

    private void LocalSave() => Database.LocalSave(this);

    private void LocalLoad()
    {

        UserModel userModel = Database.LocalLoadUser();

        LeaderboardScores = userModel.leaderboard_scores;
        UserCharacterState = userModel.user_character_state;
        UserName = userModel.user_name;

    }

    public void OnSave() => LocalSave();

    public void OnLoad() => LocalLoad();

    private void NewUser()
    {

        LeaderboardScores = FindObjectOfType<ENV>().LEADERBOARDS;

        LocalSave();

    }

    public void OnNewUser() => NewUser();

}
