using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{

    public List<LeaderboardModel> Leaderboard { get; set; }

    public int UserCharacterState { get; set; }

    public string UserName { get; set; }

    void Start()
    {

        UserModel userModel = Database.LocalLoadUser();

        if (userModel == null)

            NewUser();

        else

            OnLoad(userModel);

    }

    private void LocalSave() => Database.LocalSave(this);

    private void LocalLoad(UserModel _userModel)
    {

        Leaderboard = _userModel.leaderboard;
        UserCharacterState = _userModel.user_character_state;
        UserName = _userModel.user_name;

    }

    public void OnSave() => LocalSave();

    public void OnLoad(UserModel _userModel) => LocalLoad(_userModel);

    private void NewUser()
    {

        Leaderboard = ENV.LEADERBOARDS;
        UserCharacterState = 0;
        UserName = "";

        LocalSave();

    }

}
