using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // ok as long as this is the only script that loads scenes

public class CollisionHandler : MonoBehaviour
{

    [Tooltip("FX prefab on player")][SerializeField] GameObject deathFX;
    [SerializeField] int health = 50;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        deathFX.SetActive(true);
        TakeDamage();
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage()
    {
        health -= 20;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        levelManager.LoadGameOver();
        Destroy(gameObject);
    }
}
