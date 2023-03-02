using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sus_CameraRot : MonoBehaviour
{

    public float sensX , sensY;
    public Transform Orientation;
    float xRot, yRot;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update() {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRot += mouseX;
        xRot -= mouseY;

        xRot = Mathf.Clamp(xRot , -90f, 90f);

        transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        Orientation.rotation = Quaternion.Euler(0, yRot, 0);

    }
}
