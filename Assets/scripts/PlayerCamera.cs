using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensitivityX;
    public float sensitivityY;
    public Transform orientation;

    float yRotation;

    void Start()
    {
        sensitivityX = PlayerPrefs.GetFloat("sensitivityX", 1.0f);
        sensitivityY = PlayerPrefs.GetFloat("sensitivityY", 1.0f);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (Input.GetMouseButton(1)) // if we are holding right click
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;

            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensitivityX;

            yRotation += mouseX;

            // Apply rotation only around the y-axis
            transform.rotation = Quaternion.Euler(0, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
