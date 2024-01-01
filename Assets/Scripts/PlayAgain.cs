using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    // Function to play the game again
    public void Again()
    {
        // Load the "DiamondGame" scene
        SceneManager.LoadScene("DiamondGame");
    }
}
