using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define the Block class, which represents individual blocks in the game
public class Block : MonoBehaviour
{
    // Reference to the particle system for block destruction effects
    public GameObject DestroyBlockParticleSystem;

    // Method to destroy the block and trigger particle effects
    public void DestroyBlock()
    {
        Destroy(gameObject);
        Instantiate(DestroyBlockParticleSystem, transform.position, Quaternion.identity);
    }
}
