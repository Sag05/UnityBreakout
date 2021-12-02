using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    GameObject ball;
    Rigidbody ballRigidbody;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            ballRigidbody.velocity = Vector3.Reflect(ballRigidbody.velocity, Vector3.right);
            Debug.Log("Wall");
        }
    }
}
