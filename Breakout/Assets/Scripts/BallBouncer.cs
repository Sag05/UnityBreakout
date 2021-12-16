using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBouncer : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    private GameObject myBall;
    public float horizontalBouncePower = 2.0f;
    public float bouncePower = 5.0f;
    float relativePosition;

    void Start()
    {
        myBall = GameObject.FindGameObjectWithTag("Ball");
        ballRigidbody = myBall.GetComponent<Rigidbody>();
    }

    public void UpdateBall()
    {
        myBall = GameObject.FindGameObjectWithTag("Ball");
        ballRigidbody = myBall.GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            relativePosition = transform.position.x - myBall.transform.position.x;

            //Set velocity
            ballRigidbody.velocity = new Vector3(relativePosition * -1 * horizontalBouncePower, bouncePower, 0);
        }
    }
}
