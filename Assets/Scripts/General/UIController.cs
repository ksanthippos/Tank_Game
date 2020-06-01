using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{

    public Text scoreText;
    public Text healthText;
    public Text livesText;

    public UIController ui;
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = ui.scoreText;
        healthText = ui.healthText;
        livesText = ui.livesText;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void setScore(float score)
    {
        scoreText.text = "Score: " + score;
    }

    public void setHealth(float current, float max)
    {
        healthText.text = "Health: " + current + "/" + max;
    }

    public void setLives(int current, int max)
    {
        livesText.text = "Lives: " + current + "/" + max;
    }
}
