using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PACPointerLook : MonoBehaviour
{
    public float _mouseSensitivity = 800f;
    public Transform _pointer;

    float _xRotation = 0f;
    float _yRotation = 0f;

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        _yRotation -= mouseX;
        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -_yRotation, 90f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        _pointer.Rotate(Vector3.up * mouseX);
    }
}
