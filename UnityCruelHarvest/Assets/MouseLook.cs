using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform orientation;
    public float mouseSensitivityX = 100f;
    public float mouseSensitivityY = 100f;
    float xRotation = 0f;
    float yRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible=false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX * Time. deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf. Clamp (xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.localRotation = Quaternion.Euler(0f, yRotation, 0f);
        
    }
}
