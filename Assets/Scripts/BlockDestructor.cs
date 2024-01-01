using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Class responsible for handling the destruction of blocks and detecting diamonds
public class BlockDestructor : MonoBehaviour
{
    public string DiamondTag = "diamond";

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
            Block block = selection.GetComponent<Block>();

            // If the selected object has a Block component, destroy it
            if (block)
                block.DestroyBlock();

            // Check if the selected object has the specified DiamondTag
            if (selection.CompareTag(DiamondTag))
            {
                Debug.Log("Diamond Found!");

                // Load the "PlayAgain" scene
                SceneManager.LoadScene("PlayAgain");
            }
        }
    }
}
