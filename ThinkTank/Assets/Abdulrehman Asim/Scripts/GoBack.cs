using UnityEngine.SceneManagement;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    public void ToMainMenu()
    {
        // Loads Main Menu Scene
        SceneManager.LoadScene("Main-Menu");
    }
}
