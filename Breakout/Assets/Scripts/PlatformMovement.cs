using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private Rigidbody myRigidbody;
    public float playerSpeed = 2.0f;
    public float clampLeft = -4;
    public float clampRight = 4;

    private void Start()
    {
        myRigidbody = gameObject.GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        Vector3 myInput = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        Vector3 newPosition = transform.position + myInput * Time.deltaTime * playerSpeed;

        newPosition.x = Mathf.Clamp(newPosition.x, clampLeft, clampRight);
        myRigidbody.MovePosition(newPosition);
    }
}
