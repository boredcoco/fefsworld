using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float xSpeed;
    [SerializeField] private float zSpeed;

    [SerializeField] private Rigidbody rb;

    private Camera mainCamera;
    private Vector3 currentDirection;

    private void Start()
    {
      mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal") * xSpeed * Time.deltaTime;
        float zDirection = Input.GetAxis("Vertical") * zSpeed * Time.deltaTime;
        Vector3 newForce = transform.rotation * new Vector3(xDirection, 0f, zDirection);

        if (Input.GetAxisRaw("Horizontal") != 0f || Input.GetAxisRaw("Vertical") != 0f)
        {
          currentDirection = transform.rotation * new Vector3(
            Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")
          );
        }

        rb.AddForce(newForce, ForceMode.VelocityChange);

        if (!Input.GetMouseButtonDown(0)) {
          return;
        }

/*
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = mainCamera.nearClipPlane;
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePos);

        Quaternion angle = new Quaternion();
        angle.SetFromToRotation(transform.position, worldPosition);

        // rotate player
        rb.rotation = rb.rotation * angle;
        Debug.Log(angle.eulerAngles);
        */
    }

    private void Update()
    {
      // look in the right direction
      Quaternion targetRotation = Quaternion.LookRotation(currentDirection);
      transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 0.15f);
    }

}
