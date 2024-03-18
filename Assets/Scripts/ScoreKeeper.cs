using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score;

    static ScoreKeeper instance;


    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void SaveScore(int newScore)
    {
        List<int> scores = new List<int>();
        for (int i = 0; i < 10; i++)
        {
            scores.Add(PlayerPrefs.GetInt("Score" + i, 0));
        }

        scores.Add(newScore);
        scores.Sort((a, b) => b.CompareTo(a)); // Sort Descending
        scores.RemoveAt(scores.Count - 1); // Delete the Minimum score if have > 10 record

        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetInt("Score" + i, scores[i]);
        }
    }

}
