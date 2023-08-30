using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class LoadLeaderboardManager : MonoBehaviour
{

    public GameObject leaderboardEntryPrefab;
    public Transform content;

    private List<LeaderboardModel> Leaderboard { get; set; }

    void Start()
    {

        Leaderboard = FindObjectOfType<User>().Leaderboard;

        Leaderboard.Sort((score1, score2) => score2.leaderboard_score.CompareTo(score1.leaderboard_score));

        content.ClearChildren();
        // Instantiate leaderboardEntryPrefab for each leaderboard entry, up to maxEntries
        for (int score = 0, rank = 1; score < Mathf.Min(Leaderboard.Count, ENV.MAX_ENTRIES); score++, rank++)
        {

            GameObject entry = Instantiate(leaderboardEntryPrefab, content);
            entry.transform.localScale = Vector3.one;

            // Set the rank text
            TextMeshProUGUI rankText = entry
                .transform
                .Find("TextRankNumber")
                .GetComponent<TextMeshProUGUI>();

            rankText.text = rank.ToString();

            // Set the score text
            entry
                .transform
                .Find("TextName")
                .GetComponent<TextMeshProUGUI>()
                .text = Leaderboard[score].leaderboard_name.ToString();

            entry
                .transform
                .Find("TextScoreNumber")
                .GetComponent<TextMeshProUGUI>()
                .text = Leaderboard[score].leaderboard_score.ToString();

            // Change the color for the top three ranks
            if (rank == 1)

                rankText.color = Color.yellow; // gold

            else if (rank == 2)

                rankText.color = Color.gray; // silver

            else if (rank == 3)

                rankText.color = new Color(205f / 255f, 127f / 255f, 50f / 255f); // bronze

        }

    }

}
