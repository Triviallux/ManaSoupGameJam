using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    float mouseSensisivity = 100f;
    public Transform playerBody;

    float xRotation = 0;
    float yRotation = 0; 

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensisivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensisivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation,0, 0f);
        yRotation = yRotation + mouseX;
        //playerBody.Rotate(Vector3.up * mouseX);
        playerBody.Rotate(new Vector3(0, mouseX, 0));
        

        //transform.rotation = Quaternion.Euler(0f, RotateX, 0f);

    }
}
