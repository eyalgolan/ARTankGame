using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    string playersTag = "Player";
    public Text endText;
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
        }
        if (players.Length == 0)
        {
            endText.text = "GAME OVER";
        }
        if (players.Length == 1)
        {
            endText.text = "winner is " + players[0].name;
        }
    }
}
