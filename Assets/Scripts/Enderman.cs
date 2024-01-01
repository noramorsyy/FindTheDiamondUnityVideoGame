using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enderman : MonoBehaviour
{
    Transform target;
    public float MovementSpeed;

    // Time it takes for the Enderman to get angry when looked at
    public float TimeToGetAngry;

    public float TeleportationDelay;
    public Vector3 offset;
    float timeStamp;
    bool angry = false;
    float countdown;

    // Called when the script is first initialized
    void Start()
    {
        // Find the player's transform using the "Player" tag
        target = GameObject.FindWithTag("Player").transform;
        // Set initial countdown for teleportation
        countdown = TeleportationDelay;
    }

    // Called when another collider enters the trigger collider attached to this object
    void OnTriggerEnter(Collider playerDetected)
    {
        // If the entering collider has is the player, make the Enderman look at the player
        if (playerDetected.CompareTag("Player"))
        {
            transform.LookAt(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the target position
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

        // Check if the player is looking at the Enderman
        if (IsLookedAtByTarget())
        {
            Debug.Log("Player is looking at enemy.");
            timeStamp = Time.time;

            // Check if the time threshold for getting angry is reached
            if (timeStamp >= TimeToGetAngry)
            {
                angry = true;
            }
        }
        // Check if the player is not looking at the Enderman but it's angry
        else if (angry)
        {
            Debug.Log("Player is not looking at enemy.");
            countdown -= Time.deltaTime;

            // Check if the countdown for teleportation is complete
            if (countdown <= 0f)
            {
                // Teleport the Enderman to a new position relative to the player
                transform.position = target.transform.position + offset;
                // Reset the countdown
                countdown = TeleportationDelay;
            }
        }
    }

    // Check if the Enderman is being looked at by the player
    bool IsLookedAtByTarget()
    {
        Vector3 toEnderman = (this.transform.position - target.transform.position).normalized;
        // Calculate the dot product between the forward vector of the camera and the toEnderman vector
        float dot = Vector3.Dot(toEnderman, Camera.main.transform.forward);
        Debug.Log(dot);

        // Check if the dot product is above a certain threshold
        if (dot > 0.9f)
        {
            Debug.Log("Player is looking right at the enemy.");
            return true;
        }
        else
        {
            Debug.Log("Player is not looking at enemy.");
            return false;
        }
    }
}
