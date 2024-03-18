using UnityEngine;

public class DataSeeder : MonoBehaviour
{
    void Start()
    {
        SeedScores();
    }

    void SeedScores()
    {
        for (int i = 8; i >= 0; i--)
        {
            PlayerPrefs.SetInt("Score" + i, (i + 1) * 100); // Make fake score
        }
        
        PlayerPrefs.Save(); // Save to PlayerPrefs
    }
}
