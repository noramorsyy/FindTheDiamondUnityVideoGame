using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    // Health of the enemy
    public int health = 5;

    // Update is called once per frame
    private void Update()
    {
        // Create a ray from the camera to the mouse position
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the left mouse button is clicked and the ray hits an object
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            // Check if the selected object has the "creeper" tag
            if (selection.gameObject.CompareTag("creeper"))
            {
                // Decrease the enemy's health
                health -= 1;
                Debug.Log("Hit");

                // Check if the enemy's health is depleted
                if (health == 0)
                {
                    // Destroy the enemy GameObject
                    Destroy(gameObject);
                }
            }
        }
    }
}
