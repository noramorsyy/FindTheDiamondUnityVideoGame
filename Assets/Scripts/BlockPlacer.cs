using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Class to place blocks down
public class BlockPlacer : MonoBehaviour
{
    // Reference to various block prefabs
    public GameObject Block;
    public GameObject DarkBlock;
    public GameObject Grass;
    public GameObject Diamond;
    public GameObject Wood;
    public GameObject Sand;
    public GameObject Emerald;

    // Update is called once per frame
    private void Update()
    {
        // Create a ray from the camera to the mouse position
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check for key presses to instantiate different blocks
        if (Input.GetKeyDown(KeyCode.H) && Physics.Raycast(ray, out hit))
        {
            var selection = hit.point;
            Instantiate(Block, selection, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.I) && Physics.Raycast(ray, out hit))
        {
            var selection = hit.point;
            Instantiate(DarkBlock, selection, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.J) && Physics.Raycast(ray, out hit))
        {
            var selection = hit.point;
            Instantiate(Grass, selection, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.K) && Physics.Raycast(ray, out hit))
        {
            var selection = hit.point;
            Instantiate(Diamond, selection, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.L) && Physics.Raycast(ray, out hit))
        {
            var selection = hit.point;
            Instantiate(Wood, selection, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.M) && Physics.Raycast(ray, out hit))
        {
            var selection = hit.point;
            Instantiate(Sand, selection, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.N) && Physics.Raycast(ray, out hit))
        {
            var selection = hit.point;
            Instantiate(Emerald, selection, Quaternion.identity);
        }
    }
}
