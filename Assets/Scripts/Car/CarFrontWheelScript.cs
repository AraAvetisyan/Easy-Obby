using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarFrontWheelScript : MonoBehaviour
{
    private Vector3 targetRotation;
    private Vector3 currentVel;
    private float yAxis;
    private float xAxis;
    [SerializeField] private float smoothTime;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    private bool isRotating;
    private void FixedUpdate()
    {
        if (_floatingJoystick.Horizontal != 0)
        {
            isRotating = true;
        }
        else
        {
            isRotating = false;
        }
        if (isRotating)
        {
            yAxis = _floatingJoystick.Horizontal;
            xAxis = 0;
            targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(xAxis, yAxis), ref currentVel, smoothTime);
            transform.eulerAngles = new Vector3(transform.rotation.x, targetRotation.y * 20, 0);
        }
        if (!isRotating)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, 0, 0);
        }
    }       
}
