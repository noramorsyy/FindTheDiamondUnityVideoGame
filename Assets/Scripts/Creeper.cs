using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creeper : MonoBehaviour
{
    // Radius within which the Creeper explodes
    public int radius;

    // Called when another collider enters the trigger collider attached to this object
    void OnTriggerEnter(Collider playerDetected)
    {
        // Check if the entering collider is the player
        if (playerDetected.CompareTag("Player"))
        {
            // Find all colliders within the specified radius
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

            // Destroy the Creeper GameObject
            Destroy(this.gameObject);

            // Loop through all colliders in the radius
            foreach (Collider collider in hitColliders)
            {
                Block block = collider.GetComponent<Block>();

                // If the collider has a Block component, destroy it
                if (block)
                    block.DestroyBlock();
            }
        }
    }
}
