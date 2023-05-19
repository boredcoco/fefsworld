using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;  // Reference to the player's transform
    [SerializeField] private float distance = 5f;  // Distance between the camera and the player
    [SerializeField] private float height = 2f;  // Height offset of the camera

    private void LateUpdate()
    {
        if (player != null)
        {
            // Calculate the desired position based on the player's position, distance, and height
            Vector3 desiredPosition = player.position - player.forward * distance + Vector3.up * height;

            // Smoothly move the camera towards the desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * 5f);

            // Make the camera look at the player
            transform.LookAt(player);
        }
    }
}
