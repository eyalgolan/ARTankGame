using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public PlayerDamage health;
    Text scoreText;
    int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
    }
    public void AddToScore(int amount)
    {
        if ((score + amount) < 0)
        {
            score = 0;
        }
        else
        {
            score += amount;
        }
    }
    public int getScore()
    {
        return score;
    }
}
