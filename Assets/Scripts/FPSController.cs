using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    public CharacterController playerController;
    public Transform playerCamera;
    public float mouseSensitivity = 2;
    public float speed = 5;
    public float sprintFactor = 1.8f;

    float xRotation = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        //looking around
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation = Mathf.Clamp(xRotation - mouseY, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerController.transform.Rotate(Vector3.up * mouseX);

        //moving around
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        bool sprinting = Input.GetKey(KeyCode.R);

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        if (sprinting) playerController.Move(move * speed * sprintFactor * Time.deltaTime);
        else playerController.Move(move * speed * Time.deltaTime);
    }
}
