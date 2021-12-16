using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayAgain : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject bricksPrefab;
    public GameObject ball;
    GameObject deathDetector;
    GameObject oldBricks;
    GameObject platform;
    GameObject scoreText;

    // Start is called before the first frame update
    void Start()
    {
        deathDetector = GameObject.FindGameObjectWithTag("DeathDetector");
        oldBricks = GameObject.FindGameObjectWithTag("AllBricks");
        platform = GameObject.FindGameObjectWithTag("Platform");
        scoreText = GameObject.FindGameObjectWithTag("ScoreText");
    }
    public void ResetGame()
    {
        Destroy(gameOverScreen);
        Instantiate(bricksPrefab, oldBricks.transform.position, oldBricks.transform.rotation);
        Destroy(oldBricks);
        Instantiate(ball);
        platform.GetComponent<BallBouncer>().UpdateBall();
        deathDetector.GetComponent<Death>().UpdateLives();
        deathDetector.GetComponent<Death>().UpdateBall();
        scoreText.GetComponent<TextMeshProUGUI>().SetText("Score:0");
    }
}
