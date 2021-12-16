using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounce : MonoBehaviour
{
    GameObject ball;
    Rigidbody ballRigidbody;
    Vector3 oldVelocity;
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball");
        ballRigidbody = ball.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        oldVelocity = ballRigidbody.velocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Platform"))
        {
            ballRigidbody.velocity = Vector3.Reflect(oldVelocity, collision.GetContact(0).normal);
        }
    }
}
