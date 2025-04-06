using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeoutMenu : MonoBehaviour
{
    float seconds;
    float limit;

    void Start()
    {
        limit = 30;
    }


    void Update()
    {
        seconds += Time.deltaTime;

        //print(seconds);

        if (seconds > limit)
        {
            SceneManager.LoadScene("Main-Menu");
        }
    }

    //when input is detected, reset the timer.
    public void resetTimer()
    {
        seconds = 0;
    }
}
