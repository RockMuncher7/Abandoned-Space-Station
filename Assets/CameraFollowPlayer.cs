using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform target;
    public float mouseSens = 5f;

    private float xRotation = 0f;

    private void Start()
    {
        bool cursorLocked = false;

        if(cursorLocked == false)
        {
            Cursor.lockState = CursorLockMode.Locked;

            cursorLocked = true;
        } else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        LookFunctionality();
    }

    void LookFunctionality()
    {
        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        target.Rotate(Vector3.up * mouseX);
    }
}
