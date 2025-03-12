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
        // Create a ray from the camera to the object under the mouse cursor
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Perform the raycast and check if it hits the object and it's not blocked
        if (Physics.Raycast(ray, out hit))
        {
            // Check if the ray hit the object this script is attached to
            if (hit.collider.gameObject == this.gameObject)
            {
                // You are over the object, and it isn't blocked by another object
                //MouseOver();
            }
        }
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
