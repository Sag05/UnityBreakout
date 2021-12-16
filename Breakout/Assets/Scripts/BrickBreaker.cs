using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using System.Text;
using System;

public class BrickBreaker : MonoBehaviour
{
    GameObject thisBrick;
    GameObject scoreText;
    TextMeshProUGUI scoreMesh;
    GameObject highScoreText;
    TextMeshProUGUI highScoreMesh;
    public GameObject explotion;
    public int score;  
    string highScorePath;
    string highScore;

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
        scoreMesh = scoreText.GetComponent<TextMeshProUGUI>();

        highScoreText = GameObject.FindGameObjectWithTag("Highscore");
        highScoreMesh = highScoreText.GetComponent<TextMeshProUGUI>();

        highScorePath = Application.persistentDataPath + Path.DirectorySeparatorChar + "highscore.txt";

        if (!File.Exists(highScorePath))
        {
            File.Create(highScorePath);
            StartCoroutine(WaitForFile());
            highScore = "0";
            highScoreMesh.SetText("Highscore:" + highScore);
        }
        else
        {
            highScore = File.ReadAllText(highScorePath);
            highScoreMesh.SetText("Highscore:" + highScore);
        }

        //wait some time or else you get IO error
    }

    IEnumerator WaitForFile()
    {
        yield return new WaitForSeconds(0.2f);
        score = 0;
        File.WriteAllText(highScorePath, score.ToString());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            //Get Brick
            thisBrick = collision.gameObject;

            //Spawn Explotion
            Instantiate(explotion, thisBrick.transform.position, Quaternion.identity);

            //Destroy
            Destroy(thisBrick);

            //Update Score
            score += 10;
            scoreMesh.SetText("Score:" + score);

            #region Highscore 
            highScore = File.ReadAllText(highScorePath);
            if (score > int.Parse(highScore))
            {
                File.WriteAllText(highScorePath, score.ToString());
            }
            highScore = File.ReadAllText(highScorePath);

            highScoreMesh.SetText("Highscore:" + highScore);
            #endregion
        }
    }
}
