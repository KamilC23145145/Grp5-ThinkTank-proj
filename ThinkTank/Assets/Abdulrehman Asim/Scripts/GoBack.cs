using UnityEngine.SceneManagement;
using UnityEngine;

public class GoBack : MonoBehaviour
{
    [SerializeField] bool is_main;
    public void ToMainMenu()
    {
        // Loads Main Menu Scene
        if (is_main)
        {
            SceneManager.LoadScene("Main-Menu");
        }
        else
        {
            SceneManager.LoadScene("SelectScreen");
        }
    }
}
