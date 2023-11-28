using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public Transform player;
    public float mouseSensitivity = 100f; 
    private float cameraVerticalRotation = 0f;
    private bool unlock = true;
    

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
    }

    public void UnlockCursor()
    {
        unlock = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void lockCursor()
    {
        unlock = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if(unlock)
        {
            float inputX = Input.GetAxis("Mouse X") * mouseSensitivity ;
            float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity ;

            cameraVerticalRotation -= inputY;
            cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
            transform.localEulerAngles = Vector3.right * cameraVerticalRotation;

            player.Rotate(Vector3.up * inputX);

        }

    }

}
