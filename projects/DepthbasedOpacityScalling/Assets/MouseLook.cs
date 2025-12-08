using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;          // assign your Player transform
    public float mouseSensitivity = 250f;
    public bool lockCursor = true;

    // initial rotation (deg)
    public float initialPitch = 0f;       // x
    public float initialYaw   = 255f;     // y

    // limits
    
    // y축 최소\최대
    public float minPitch = 999f;
    public float maxPitch =  999f;
    
    // x축 최소\최대
    public float minYaw = 999f;
    public float maxYaw = 999f;

    float pitch;
    float yaw;

    void Start()
    {
        if (lockCursor) Cursor.lockState = CursorLockMode.Locked;

        // set initial yaw to body and pitch to camera
        yaw   = initialYaw;
        pitch = initialPitch;

        if (playerBody != null)
            playerBody.rotation = Quaternion.Euler(0f, yaw, 0f);

        // pitch only on camera local
        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        yaw   += mouseX;
        pitch -= mouseY;
        yaw    = Mathf.Clamp(yaw, minYaw, maxYaw);
        pitch  = Mathf.Clamp(pitch, minPitch, maxPitch);
        

        transform.localRotation = Quaternion.Euler(pitch, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, yaw, 0f);
    }
}


