using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Credits : MonoBehaviour
{

    [SerializeField] GameObject credits;
    private bool showing;

    // Start is called before the first frame update
    void Start()
    {
        showing = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreditsOff()
    {
        print("credit off");
        if (showing)
        {
            credits.SetActive(false);
        }
    }

    public void ToggleCredits()
    {
        print("toggle credits");
        if (!credits.activeInHierarchy)
        {
            credits.SetActive(true);
            showing = true;
        }
        else if (credits.activeInHierarchy)
        {
            credits.SetActive(false);
            showing = false;
        }
    }
}
