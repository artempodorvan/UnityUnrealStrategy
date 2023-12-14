using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_controler : MonoBehaviour
{
    public float rotateSpeed = 10.0f, speed = 10.0f, zoomSpeed = 5.0f;

    private void Update()
    {
        float rotate = 0f;
        float mult = 1f;

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Q))
        {
            rotate = -2f;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            rotate = 2f;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            mult = 2f;
        }
        else
        {
            mult = 1f;
        }

        float xRotation = 0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            xRotation = Input.GetAxis("Mouse ScrollWheel") * rotateSpeed;
        }

        transform.eulerAngles += new Vector3(-xRotation * rotateSpeed, 0, 0);

        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * mult, Space.World);
        // Space.Self means that in Unity we did a camera inside camera view due to we need to control through this function like class in Python
        transform.Translate(new Vector3(hor, 0, ver) * Time.deltaTime * mult * speed, Space.Self);
        // Scrolling of mouse
        transform.position += transform.up * zoomSpeed * Time.deltaTime * (Input.GetAxis("Mouse ScrollWheel") * 40);
        // Min and max position of y of camera
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, 5f, 30f), transform.position.z);
    }
}
