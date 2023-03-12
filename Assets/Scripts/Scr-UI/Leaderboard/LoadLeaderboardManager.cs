using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class LeaderboardEntry
{
    public int rank;
    public int score;
}

public class LoadLeaderboardManager : MonoBehaviour
{


    public GameObject leaderboardEntryPrefab;
    public Transform content;

    private List<LeaderboardEntry> leaderboardEntries = new List<LeaderboardEntry>();

    private int maxEntries = 10;

    private List<int> leaderboardScores;

    private void Start()
    {
        UserModel model = Database.LocalLoadUser();

        if (model == null)
            FindObjectOfType<User>().OnNewUser();
        else
            FindObjectOfType<User>().OnLoad();

        leaderboardScores = model.leaderboard_scores;

        leaderboardScores.Sort((x, y) => y.CompareTo(x));

        // Populate leaderboardEntries with data from PlayerPrefs or some other storage
        for (int i = 0; i <= 9; i++)
        {
            leaderboardEntries.Add(new LeaderboardEntry() { rank = i, score = leaderboardScores[i] }); // Add some random scores

            Debug.Log("Added" + leaderboardScores[i]);
        }

        // Sort leaderboardEntries by score in descending order
        leaderboardEntries = leaderboardEntries.OrderByDescending(entry => entry.score).ToList();

        // Update the rank of each entry based on their position in the sorted list
        for (int i = 0; i < leaderboardEntries.Count; i++)
        {
            leaderboardEntries[i].rank = i + 1;
        }

        // Instantiate leaderboardEntryPrefab for each leaderboard entry, up to maxEntries
        for (int i = 0; i < Mathf.Min(leaderboardEntries.Count, maxEntries); i++)
        {
            GameObject entry = Instantiate(leaderboardEntryPrefab, content);
            entry.transform.localScale = Vector3.one;

            // Set the rank text
            TextMeshProUGUI rankText = entry.transform.Find("TextRankNumber").GetComponent<TextMeshProUGUI>();
            rankText.text = leaderboardEntries[i].rank.ToString();

            // Set the score text
            entry.transform.Find("TextScoreNumber").GetComponent<TextMeshProUGUI>().text = leaderboardEntries[i].score.ToString();

            // Change the color for the top three ranks
            if (leaderboardEntries[i].rank == 1)
            {
                rankText.color = Color.yellow; // gold
            }
            else if (leaderboardEntries[i].rank == 2)
            {
                rankText.color = Color.gray; // silver
            }
            else if (leaderboardEntries[i].rank == 3)
            {
                rankText.color = new Color(205f / 255f, 127f / 255f, 50f / 255f); // bronze
            }
        }


    }

}
