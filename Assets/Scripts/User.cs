using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public List<int> leaderboardScores { get; set; }

    private void LocalSave()
    {

        Database.LocalSave(this);

    }

    private void LocalLoad()
    {

        UserModel user = Database.LocalLoadUser();

        leaderboardScores = user.leaderboardScores;
    }

    public void OnSave() => LocalSave();

    public void OnLoad() => LocalLoad();

    private void NewUser()
    {
        leaderboardScores = new List<int> {
        200, 175, 150, 125, 95,
        70, 60, 50, 40, 30,};

        LocalSave();

    }

    public void OnNewUser() => NewUser();
}
