using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class CameraSystem : MonoBehaviour
{
    public NewControls playerControls;
    public Vector2 mouse_rotation;
    public float sens;

    private Vector2 move_direction;
    private float mouse_click;

    public TimeoutMenu timeout;
    public Camera mainCam;
    RaycastHit hit;

    private void Awake()
    {
        sens = 1.0f;
        playerControls = new NewControls();

        timeout = FindObjectOfType<TimeoutMenu>();
        mainCam = FindObjectOfType<Camera>();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Update()
    {
        // get input values.
        move_direction = playerControls.ActionMap1.Mouse.ReadValue<Vector2>();
        mouse_click = playerControls.ActionMap1.MouseClick.ReadValue<float>();

        // if clicking... (as this checks every frame this also is effectively checking for a hold click).
        if (mouse_click == 1.0f) {
            //if click, reset timeout timer.
            timeout.resetTimer();
            // get mouse position deltas to rotate around. Clamp the Y direction to not go upside down.
            mouse_rotation.x = mouse_rotation.x + move_direction.x * sens % 360;
            mouse_rotation.y = Mathf.Clamp((mouse_rotation.y + move_direction.y * sens), -90.0f, 90.0f);

            // update the rotation.
            transform.rotation = Quaternion.Euler(-mouse_rotation.y, mouse_rotation.x, 0);
        }
        // scale moves the camera closer to the pivot point based on mouse scroll.
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 
            Mathf.Clamp(transform.localScale.z - playerControls.ActionMap1.MouseScroll.ReadValue<float>() / 1200.0f, 0.2f, 2.0f)); // subtract the scroll distance to the scale and clamp.

        Ray ray = new Ray(mainCam.transform.position, mainCam.transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            print(hit.collider.gameObject.name + " HIT");
        }

        //Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * 100.0f, Color.yellow);
    }
}
