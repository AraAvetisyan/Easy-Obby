using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWheelScript : MonoBehaviour
{

}















//[SerializeField] private CarController _carController;
//[SerializeField] private float rotationSpeed;
//[SerializeField] private float currentRotationSpeed;
//[SerializeField] private bool frontWheel;
//Vector3 targetRotation;
//Vector3 currentVel;
//[SerializeField] private float smoothTime;
//[SerializeField] private FloatingJoystick _floatingJoystick;

//[SerializeField] private float yAxis;
//[SerializeField] private float xAxis;
//[SerializeField] private float addRotationSpeed;
//private void Update()
//{
//    currentRotationSpeed = rotationSpeed * _carController.CurrentSpeed * Time.deltaTime * addRotationSpeed;
//    transform.Rotate(currentRotationSpeed, 0, 0);
//}
//private void FixedUpdate()
//{
//    yAxis = _floatingJoystick.Horizontal;
//    xAxis = 0;
//    if (frontWheel)
//    {
//        targetRotation = Vector3.SmoothDamp(targetRotation, new Vector3(xAxis, yAxis), ref currentVel, smoothTime);
//        transform.eulerAngles = new Vector3(targetRotation.x, targetRotation.y * 20, targetRotation.z);
//    }

//}