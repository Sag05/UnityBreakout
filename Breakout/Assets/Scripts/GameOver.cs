using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class GameOver : MonoBehaviour
{
    GameObject endScoreText;
    GameObject highScoreText;
    GameObject newHighScoteText;
    GameObject ball;
    string highScorePath;
    string highScore;
    int endScore;

    // Start is called before the first frame update
    void Start()
    {

        highScorePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "highscore.txt";
        highScore = File.ReadAllText(highScorePath);

        endScoreText = GameObject.FindGameObjectWithTag("EndScore");
        ball = GameObject.FindGameObjectWithTag("Ball");
        highScoreText = GameObject.FindGameObjectWithTag("EndHighscore");
        newHighScoteText = GameObject.FindGameObjectWithTag("NewHighscore");

        endScore = ball.GetComponent<BrickBreaker>().score;
        Destroy(ball);


        endScoreText.GetComponent<TextMeshProUGUI>().SetText("Final Score:" + endScore);
        highScoreText.GetComponent<TextMeshProUGUI>().SetText("Highscore:" + highScore);

        if (endScore >= int.Parse(highScore))
        {
        newHighScoteText.GetComponent<TextMeshProUGUI>().SetText("New Highscore!");
        }
    }
}
