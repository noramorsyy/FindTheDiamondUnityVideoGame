using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform target;
    public float MovementSpeed;

    // Called when the script is first initialized
    void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the target position
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);

        // Make the enemy look at the player
        transform.LookAt(targetPosition);

        // Move the enemy towards the player using a normalized direction and speed
        transform.position += (targetPosition - transform.position).normalized * MovementSpeed * Time.deltaTime;
    }
}
