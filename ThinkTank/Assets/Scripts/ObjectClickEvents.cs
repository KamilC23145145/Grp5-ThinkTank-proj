using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class ObjectClickEvents : MonoBehaviour
{
    bool is_mouse = false;
    float mouse_in = 0.0f;
    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseEnter()
    {
        is_mouse = true;
        mouse_in = Time.time;
    }

    private void OnMouseExit()
    {
        is_mouse = false;
        mouse_in = Time.time;
    }

    private void OnMouseOver()
    {
        if (Time.time - mouse_in > 1.0f && is_mouse) { 
            print("RAAH");
            is_mouse = false;
        }
    }
}
