using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float zSpeed;

    [SerializeField] private Rigidbody rb;

    private void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        float zDirection = Input.GetAxis("Vertical") * zSpeed * Time.deltaTime;
        Vector3 newForce = new Vector3(xDirection, 0f, zDirection);

        Debug.Log(xDirection);
        Debug.Log(zDirection);

        // rb.velocity = newForce;

        rb.AddForce(newForce, ForceMode.VelocityChange);
    }
}
