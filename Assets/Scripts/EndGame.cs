using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    string playersTag = "Player";
    public bool ended = false;
    public Text endText;
    public Score player1Score;
    public Score player2Score;
    public Text winnerScore;
    public Text loserScore;
    public GameObject endCanvas;
    public GameObject fireworks;
    GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        GameObject tmp = GameObject.Find("EndGameCanvas/Text");
        if(tmp != null)
        {
            endText = tmp.GetComponent<Text>();
        }
        if (endText == null)
        {
            Debug.Log("txt is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag(playersTag);
        if(players.Length != 2)
        {
            fireworks.SetActive(true);
            endCanvas.SetActive(true);
            //player1Score.gameObject.SetActive(false);
            //player2Score.gameObject.SetActive(false);
        }
        if (players.Length == 0)
        {
            endText.text = "GAME OVER";
        }
        if (players.Length == 1)
        {
            DisplayScores(players[0].name);
            endText.text = "winner is " + players[0].name;
        }
        
    }
    void DisplayScores(string winner)
    {
        
        string playerWinner = "Player ";
        if (winner.Contains("1")){
            if (!ended)
            {
                player1Score.AddToScore(100);
                ended = true;
            }
            winnerScore.text = "Player1 score: " + player1Score.getScore().ToString();
        }
        else if (winner.Contains("2"))
        {
            if (!ended)
            {
                player2Score.AddToScore(100);
                ended = true;
            }
            winnerScore.text = "Player1 score: " + player2Score.getScore().ToString();
        }
    }
}
