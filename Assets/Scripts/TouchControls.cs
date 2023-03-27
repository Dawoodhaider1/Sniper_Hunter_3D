using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchControls : MonoBehaviour
{
    public Joystick moveJoystick;
    public Joystick lookJoystick;
    public Button shootButton;
    public float moveSpeed = 5f;
    public float lookSpeed = 5f;
    public Transform playerTransform;

    private Rigidbody playerRigidbody;
    private bool isShooting = false;

    private void Start()
    {
        playerRigidbody = playerTransform.GetComponent<Rigidbody>();

        // Set the size and position of the look joystick to cover the whole screen
        lookJoystick.background.sizeDelta = new Vector2(Screen.width, Screen.height);
        lookJoystick.background.position = new Vector2(Screen.width / 2f, Screen.height / 2f);

        // Add a listener to the shoot button's onClick event
        shootButton.onClick.AddListener(Shoot);
    }

    private void Update()
    {
        // Move the player using the move joystick
        Vector3 moveInput = new Vector3(moveJoystick.Horizontal, 0f, moveJoystick.Vertical);
        Vector3 moveVelocity = moveInput * moveSpeed;
        playerRigidbody.velocity = moveVelocity;

        // Rotate the player using the look joystick
        Vector2 lookInput = new Vector2(lookJoystick.Horizontal, lookJoystick.Vertical);
        playerTransform.rotation *= Quaternion.Euler(lookInput.y * lookSpeed, lookInput.x * lookSpeed, 0f);
    }

    // Called when the shoot button is clicked
    private void Shoot()
    {
        // Call your shooting function here
        // Example: Debug.Log("Shoot!");
    }
}
