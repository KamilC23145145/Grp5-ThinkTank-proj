using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeoutMenu : MonoBehaviour
{
    float seconds;
    float limit;
    // Start is called before the first frame update
    void Start()
    {
        limit = 30;
    }

    // Update is called once per frame
    void Update()
    {
        seconds += Time.deltaTime;

        print(seconds);

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
