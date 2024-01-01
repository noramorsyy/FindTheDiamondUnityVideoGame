using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    // Yaw and Pitch for camera rotation
    private float Yaw = 0.0f, Pitch = 0.0f;

    // Reference to the Rigidbody component
    private Rigidbody RigidBody;

    // Reference to the main camera
    Camera PlayerCamera;

    // Walk speed and sensitivity for mouse movement
    [SerializeField] float WalkSpeed = 5.0f, Sensitivity = 2.0f;

    // Called when the script is first initialized
    void Start()
    {
        PlayerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        RigidBody = gameObject.GetComponent<Rigidbody>();
    }

    // Called once per frame
    void Update()
    {
        // Check for jumping and perform a raycast to ensure the character is grounded
        if (Input.GetKey(KeyCode.Space) && Physics.Raycast(RigidBody.transform.position, Vector3.down, 1 + 0.001f))
            RigidBody.velocity = new Vector3(RigidBody.velocity.x, 5.0f, RigidBody.velocity.z);

        Look();
    }

    // Called at a fixed time interval, handle character movement
    private void FixedUpdate()
    {
        Movement();
    }

    // Handle mouse look rotation
    void Look()
    {
        Pitch -= Input.GetAxisRaw("Mouse Y") * Sensitivity;
        Pitch = Mathf.Clamp(Pitch, -90.0f, 90.0f);
        Yaw += Input.GetAxisRaw("Mouse X") * Sensitivity;
        PlayerCamera.transform.localRotation = Quaternion.Euler(Pitch, Yaw, 0);
    }

    // Handle character movement
    void Movement()
    {
        Vector2 axis = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * WalkSpeed;
        Vector3 forward = new Vector3(-PlayerCamera.transform.right.z, 0.0f, PlayerCamera.transform.right.x);
        Vector3 wishDirection = (forward * axis.x + PlayerCamera.transform.right * axis.y + Vector3.up * RigidBody.velocity.y);
        RigidBody.velocity = wishDirection;
    }
}
