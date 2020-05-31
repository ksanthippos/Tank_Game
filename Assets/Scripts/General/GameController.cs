using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public Spawner spawner;
    public float score;
    public int lives;
    public float scorePerTank;
    public int enemyStartingAmount;
    public int maxEnemiesAmount;

    private int currentLives;
    private int currentEnemyAmount;
    private GameObject player;
    
    void Start()
    {
        for (int i = 0; i < enemyStartingAmount; i++)
        {
            spawner.SpawnEnemy();
        }
        
        
        
        spawner.SpawnPlayer();
        
        score = 0f;
        currentLives = lives;
        currentEnemyAmount = enemyStartingAmount;
    }

    public void addScore()
    {
        score += scorePerTank;
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
