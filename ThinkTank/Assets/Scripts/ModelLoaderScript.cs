using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ModelLoader : MonoBehaviour
{
    public void loadBike()
    {
        SceneManager.LoadScene("BikeScene");
    }

    public void loadCrane()
    {
        SceneManager.LoadScene("CraneScene");
    }

    public void loadPlane()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
