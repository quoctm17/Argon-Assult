using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] CollisionHandler playerHealth;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Time")]
    [SerializeField] TextMeshProUGUI timeText;
    private float elapsedTime;


    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
        UpdateTime();
    }

    void UpdateTime()
    {
        elapsedTime += Time.deltaTime;
        TimeSpan time = TimeSpan.FromSeconds(elapsedTime);
        timeText.text = time.ToString(@"mm\:ss");
    }
}
