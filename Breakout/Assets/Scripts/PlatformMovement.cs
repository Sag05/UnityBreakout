using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float playerSpeed = 2.0f;

    private void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 myInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);

        myRigidbody.MovePosition(transform.position + myInput * Time.deltaTime * playerSpeed);
    }
}
