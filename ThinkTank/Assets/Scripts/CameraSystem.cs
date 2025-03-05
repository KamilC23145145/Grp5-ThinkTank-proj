using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Vector2 mouse_rotation;
    public float sens;
    void Start()
    {
        sens = 5.0f;
    }

    void Update()
    {
        if (Input.GetMouseButton(0)) {
            mouse_rotation.x = (mouse_rotation.x + Input.GetAxis("Mouse X") * sens) % 360;
            mouse_rotation.y = Mathf.Clamp((mouse_rotation.y + Input.GetAxis("Mouse Y") * sens), -90.0f, 90.0f); ;
            transform.rotation = Quaternion.Euler(-mouse_rotation.y, mouse_rotation.x, 0);
        }
    }
}
