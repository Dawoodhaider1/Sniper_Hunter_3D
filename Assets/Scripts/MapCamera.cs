using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCamera : MonoBehaviour
{
    public Transform target; // The player's Transform component

    void LateUpdate()
    {
        // Get the player's position and set the camera's position to the same x and z coordinates,
        // but keep the camera's y-coordinate fixed
        Vector3 newPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        transform.position = newPosition;

        // Freeze the y-axis rotation of the camera and set the x and z-axis rotations to be the same as the target object
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, target.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
