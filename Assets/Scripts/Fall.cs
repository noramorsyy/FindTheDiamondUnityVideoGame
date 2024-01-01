using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fall : MonoBehaviour
{
    // Called when another collider enters the trigger collider attached to this object
    void OnTriggerEnter(Collider playerDetected)
    {
        // Check if the entering collider has the "Player" tag
        if (playerDetected.CompareTag("Player"))
        {
            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
