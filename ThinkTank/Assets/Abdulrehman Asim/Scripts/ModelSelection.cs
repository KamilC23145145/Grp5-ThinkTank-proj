using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelSelection : MonoBehaviour
{
    public GameObject[] characters;
    public int selectedCharacter = 0;

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void ViewModel()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);

        if (selectedCharacter == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else if (selectedCharacter == 1)
        {
            SceneManager.LoadScene("BikeScene");
        }
        else if (selectedCharacter == 2)
        {
            SceneManager.LoadScene("CraneScene");
        }
    }
}
