using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Function to start the game
    public void StartGame()
    {
        // Load the "DiamondGame" scene
        SceneManager.LoadScene("DiamondGame");
    }
}
