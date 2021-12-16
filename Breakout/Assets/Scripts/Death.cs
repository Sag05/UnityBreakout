using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Death : MonoBehaviour
{
    GameObject livesText;
    GameObject ball;
    TextMeshProUGUI livesMesh;
    Rigidbody ballRigidbody;
    public GameObject gameOverScreen;
    public GameObject canvas;
    public int lives = 3;
    public int endScore;
    int startingLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        //get Livestext
        livesText = GameObject.FindGameObjectWithTag("LivesText");
        livesMesh = livesText.GetComponent<TextMeshProUGUI>();

        //get ball
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    public void UpdateLives()
    {
        lives = startingLives;
        livesMesh.SetText("Lives:" + lives);
    }
    public void UpdateBall()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    // Update is called on collision
    private void OnCollisionEnter(Collision collision)
    {
        if (lives > 1)
        {
            //Reset ball position & Velocity
            ball.transform.position = Vector3.zero;
            ballRigidbody.velocity = Vector3.zero;

            //Change lives
            lives--;
            livesMesh.SetText("Lives:" + lives);
        }
        else
        {
            endScore = ball.GetComponent<BrickBreaker>().score;
            Destroy(ball);
            Instantiate(gameOverScreen, canvas.transform);
        }
    }
}
