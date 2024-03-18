using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI scoreTextColumn1;
    [SerializeField] TextMeshProUGUI scoreTextColumn2;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        DisplayScores();
    }

    void DisplayScores()
    {
        int playerScore = scoreKeeper.GetScore();
        string playerScoreText = "<color=red>Your Score: " + playerScore + "</color>\n";

        // Prepare strings for both columns
        string scoresTextColumn1 = "Top Scores:\n";
        string scoresTextColumn2 = "\n"; // Start with a newline for alignment if needed

        List<int> scores = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            scores.Add(PlayerPrefs.GetInt("Score" + i, 0));
        }

        // Ensure the scores list is correctly sorted just in case
        scores.Sort((a, b) => b.CompareTo(a));

        for (int i = 0; i < scores.Count; i++)
        {
            string scoreLine = "Player" + (i + 1) + ". " + scores[i] + "\n";
            if (i < 5)
            {
                scoresTextColumn1 += scoreLine;
            }
            else
            {
                scoresTextColumn2 += scoreLine;
            }
        }

        // Always display the player's score prominently
        scoreText.text = playerScoreText;

        // Assign to TextMeshProUGUI components for each column
        scoreTextColumn1.text = scoresTextColumn1;
        scoreTextColumn2.text = scoresTextColumn2;
    }
}
