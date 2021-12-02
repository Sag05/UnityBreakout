using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BrickBreaker : MonoBehaviour
{
    GameObject thisBrick;
    GameObject scoreText;
    TextMeshProUGUI scoreMesh;
    int score;
    

    void Start()
    {
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
        scoreMesh = scoreText.GetComponent<TextMeshProUGUI>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Brick"))
        {
            thisBrick = collision.gameObject;
            Destroy(thisBrick);
            score += 10;
            scoreMesh.SetText("Score:" + score);
        }
    }
}
