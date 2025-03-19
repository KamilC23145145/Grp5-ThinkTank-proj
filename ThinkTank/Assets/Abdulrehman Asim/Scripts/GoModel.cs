using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoModel : MonoBehaviour
{
    public void GoToModel()
    {
        SceneManager.LoadScene("SelectScreen");
    }
}
