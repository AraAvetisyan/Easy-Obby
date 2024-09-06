using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private ReverseButtonScript _reverseButtonScript;
    [SerializeField] private ForwardButtonScript _forwardButtonScript;
    [SerializeField] private Rigidbody rb;
    private float currentVelocity;
    private float speedVelocity;
    public float CurrentSpeed;
    [SerializeField] private float smootRotationTimer;
    [SerializeField] private float smootSpeedTimer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform camera;
    [SerializeField] private bool isMobile;
    [SerializeField] private List<GameObject> graundObjects;
    public bool IsGrounded;
    private int stopCounter;
    [SerializeField] private GameObject finalPanel;

    public float HorizontalAxes, VerticalAxes;
    public float VerticalSpeed;

    private void Update()
    {
        //if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
        //{
        //    if (Geekplay.Instance.PlayerData.CarSaveProgressLevel1 == 100 && stopCounter == 0)
        //    {
        //        stopCounter = 1;
        //        moveSpeed = 0;
        //        finalPanel.SetActive(true);
        //    }
        //}
        //if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
        //{
        //    if (Geekplay.Instance.PlayerData.CarSaveProgressLevel2 == 100 && stopCounter == 0)
        //    {
        //        stopCounter = 1;
        //        moveSpeed = 0;
        //        finalPanel.SetActive(true);
        //    }
        //}
        //if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
        //{
        //    if (Geekplay.Instance.PlayerData.CarSaveProgressLevel3 == 100 && stopCounter == 0)
        //    {
        //        stopCounter = 1;
        //        moveSpeed = 0;
        //        finalPanel.SetActive(true);
        //    }
        //}
        //if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
        //{
        //    if (Geekplay.Instance.PlayerData.CarSaveProgressLevel4 == 100 && stopCounter == 0)
        //    {
        //        stopCounter = 1;
        //        moveSpeed = 0;
        //        finalPanel.SetActive(true);
        //    }
        //}
        //if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
        //{
        //    if (Geekplay.Instance.PlayerData.CarSaveProgressLevel5 == 100 && stopCounter == 0)
        //    {
        //        stopCounter = 1;
        //        moveSpeed = 0;
        //        finalPanel.SetActive(true);
        //    }
        //}

    }
    public void FixedUpdate()
    {
        Vector2 input = Vector2.zero;
        if (isMobile)
        {
            if (_forwardButtonScript.ForwardPressed)
            {
                input = new Vector2(HorizontalAxes, VerticalAxes);
            }
            if (_reverseButtonScript.ReversePressed)
            {
                input = new Vector2(-HorizontalAxes, VerticalAxes);
            }
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
        Vector2 inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smootRotationTimer);
        }
        float targertSpeed = moveSpeed * inputDir.magnitude;
        CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, targertSpeed, ref speedVelocity, smootSpeedTimer);
       
       // transform.Translate(transform.forward * VerticalSpeed * CurrentSpeed * Time.deltaTime, Space.World);
      
        
        if (_forwardButtonScript.ForwardPressed)
        {
           
            if (inputDir.magnitude != 0)
            {
                targertSpeed = moveSpeed * _forwardButtonScript.Speed * inputDir.magnitude;
            }
            else
            {
                targertSpeed = moveSpeed * _forwardButtonScript.Speed;
            }
        }

        if (_reverseButtonScript.ReversePressed)
        {
            
            if (inputDir.magnitude != 0)
            {
                targertSpeed = moveSpeed * _reverseButtonScript.Speed * inputDir.magnitude;
            }
            else
            {
                targertSpeed = moveSpeed * _reverseButtonScript.Speed;
            }
        }
        if (!_forwardButtonScript.ForwardPressed && !_reverseButtonScript.ReversePressed)
        {
            targertSpeed = moveSpeed * 0;
          
        }
        CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, targertSpeed, ref speedVelocity, smootSpeedTimer);

        transform.Translate(transform.forward * CurrentSpeed * Time.deltaTime, Space.World);
        if (CurrentSpeed == 0)
        {
            rb.velocity = Vector3.zero;
        }
    }
}



















//Vector2 input = Vector2.zero;
//if (isMobile)
//{
//    input = new Vector2(_floatingJoystick.Horizontal, 0);
//}
//else
//{
//    input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
//}
//Vector2 inputDir = input.normalized;

//if (inputDir != Vector2.zero)
//{
//    float rotation = Mathf.Atan2(inputDir.x, 0) * Mathf.Rad2Deg + camera.eulerAngles.y;
//    transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smootRotationTimer);
//}
//float targertSpeed = moveSpeed * _forwardButtonScript.Speed * _reverseButtonScript.Speed;
//currentSpeed = Mathf.SmoothDamp(currentSpeed, targertSpeed, ref speedVelocity, smootSpeedTimer);
//transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
//if (currentSpeed == 0)
//{
//    rb.velocity = Vector3.zero;
//}










//public IEnumerator WaitSpeedZero()
//{
//    yield return new WaitForSeconds(0.1f);
//    smootSpeedTimer = 0;
//    notFirstMove = true;
//}








//[SerializeField] private FloatingJoystick _floatingJoystick;
//[SerializeField] private ForwardButtonScript _forwardButtonScript;
//[SerializeField] private ReverseButtonScript _reverseButtonScript;
//[SerializeField] private Rigidbody rb;
//private float currentVelocity;
//private float speedVelocity;
//public float CurrentSpeed;
//[SerializeField] private float smootRotationTimer;
//[SerializeField] private float smootSpeedTimer;
//public float moveSpeed;
//[SerializeField] private Transform camera;
//[SerializeField] private bool isMobile;
//private float targertSpeed;
//private int speedCounter;
//private bool notFirstMove;
//Vector2 inputDir;
//public float Rotation;
//public void FixedUpdate()
//{
//    rb.angularVelocity = Vector3.zero;
//    rb.velocity = Vector3.zero;
//    Vector2 input = Vector2.zero;
//    if (isMobile)
//    {
//        input = new Vector2(_floatingJoystick.Horizontal, 0);
//    }
//    else
//    {
//        input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
//    }

//    if (_floatingJoystick.Vertical > 0)
//    {
//        _forwardButtonScript.Speed = _floatingJoystick.Vertical;
//        _forwardButtonScript.ForwardPressed = true;
//        _reverseButtonScript.ReversePressed = false;
//    }
//    if (_floatingJoystick.Vertical < 0)
//    {
//        _reverseButtonScript.Speed = _floatingJoystick.Vertical;
//        _reverseButtonScript.ReversePressed = true;
//        _forwardButtonScript.ForwardPressed = false;
//    }
//    if (_floatingJoystick.Vertical == 0)
//    {
//        _forwardButtonScript.ForwardPressed = false;
//        _reverseButtonScript.ReversePressed = false;
//    }
//    inputDir = input.normalized;

//    if (inputDir != Vector2.zero)
//    {
//        Rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
//        //if(inputDir.y < 0)
//        //{
//        //    inputDir.x = -inputDir.x;
//        //}
//        if (_floatingJoystick.Vertical != 0)
//        {
//            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, Rotation, ref currentVelocity, smootRotationTimer);
//        }
//        if (_floatingJoystick.Vertical < 0)
//        {
//            //  transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, -Rotation, ref currentVelocity, smootRotationTimer);
//        }
//    }
//    //
//   
//    if (!_forwardButtonScript.ForwardPressed && !_reverseButtonScript.ReversePressed)
//    {
//        targertSpeed = moveSpeed * 0;
//        if (speedCounter == 1)
//        {
//            // StartCoroutine(WaitSpeedZero());
//            speedCounter = 2;
//        }
//    }
//    CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, targertSpeed, ref speedVelocity, smootSpeedTimer);

//    transform.Translate(transform.forward * CurrentSpeed * Time.deltaTime, Space.World);
//    if (CurrentSpeed == 0)
//    {
//        rb.velocity = Vector3.zero;
//    }
//}






















//[SerializeField] private FloatingJoystick _floatingJoystick;
//private float horizontal, vertical;

//[SerializeField] private WheelCollider frontLeftCollider, frontRightCollider, backLeftCollider, backRightCollider;
//[SerializeField] private Transform frontLeftTransform, frontRightTransform, backLeftTransform, backRightTransform;
//[SerializeField] private float motorForce;
//[SerializeField] private float currentSteerAngle;
//[SerializeField] private float maxSteerAngle;
//private void FixedUpdate()
//{
//    GetInput();
//    HandleMotor();
//    HandleSteering();
//    UpdateWheels();
//}
//private void GetInput()
//{
//    horizontal = _floatingJoystick.Horizontal;
//    vertical = _floatingJoystick.Vertical;
//}
//public void HandleMotor()
//{
//    frontLeftCollider.motorTorque = vertical * motorForce;
//    frontRightCollider.motorTorque = vertical * motorForce;
//}
//public void HandleSteering()
//{
//    currentSteerAngle = maxSteerAngle * horizontal;
//    frontLeftCollider.steerAngle = currentSteerAngle;
//    frontRightCollider.steerAngle = currentSteerAngle;
//}
//public void UpdateWheels()
//{
//    UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
//    UpdateSingleWheel(frontRightCollider, frontRightTransform);
//    UpdateSingleWheel(backLeftCollider, backLeftTransform);
//    UpdateSingleWheel(backRightCollider, backRightTransform);
//}

//private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
//{
//    Vector3 pos;
//    Quaternion rot;
//    wheelCollider.GetWorldPose(out pos, out rot);
//    wheelTransform.rotation = rot;
//    wheelTransform.position = pos;
//}






































//    //////////////////////////////////////////// Fizichni controller
//    ///


//    [SerializeField] private FloatingJoystick _floatingJoystick;
//    [SerializeField] private float horizontal;
//    [SerializeField] private float maxSpeedToTurn = 0.25f;

//    [SerializeField] private Transform frontLeftWheel;
//    [SerializeField] private Transform frontRightWheel;
//    [SerializeField] private Transform rearLeftWheel;
//    [SerializeField] private Transform rearRightWheel;

//    [SerializeField] private Transform LFWheelTransform;
//    [SerializeField] private Transform RFWheelTransform;

//    [SerializeField] private float mySpeed;

//    [SerializeField] private float power = 1200f;
//    [SerializeField] private float maxSpeed = 50f;
//    [SerializeField] private float carGrip = 70f;
//    [SerializeField] private float turnSpeed = 0.5f;


//    private float slideSpeed;
//    private Vector3 carRight;
//    private Vector3 carFwd;
//    private Vector3 tempVec;
//    private Vector3 rotationAmount;
//    private Vector3 accel;
//    private float throttle;
//    private Vector3 myRight;
//    private Vector3 velo;
//    private Vector3 flatVelo;
//    private Vector3 relativeVelocity;
//    private Vector3 dir;
//    private Vector3 flatDir;
//    private Vector3 carUp;
//    private Transform carTransform;
//    private Rigidbody thisRigidbody;
//    private Vector3 engineForce;
//    private float actualGrip;
//    private Vector3 turnVec;
//    private Vector3 imp;
//    private float rev;
//    private float actualTurn;
//    private float carMass;
//    private Transform[] wheelTransform = new Transform[4];


//    [SerializeField] private bool canTurn;
//    [SerializeField] private bool slowDown;
//    [SerializeField] private float slowDownSpeed;
//    [SerializeField] private float slowDownAngularSpeed;



//    private int stopCounter;
//    [SerializeField] private GameObject finalPanel;
//    private void Start()
//    {
//        InitializeCar();
//    }
//    private void InitializeCar()
//    {
//        carTransform = GetComponent<Transform>();
//        thisRigidbody = GetComponent<Rigidbody>();
//        carUp = carTransform.up;
//        carMass = thisRigidbody.mass;
//        carFwd = Vector3.forward;
//        carRight = Vector3.right;
//        SetUpWheels();
//        thisRigidbody.centerOfMass = new Vector3(0, -1f, 0);
//    }
//    private void Update()
//    {
//        CarPhysicsUpdate();
//        CheckInput();

//        if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
//        {
//            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel1 == 100 && stopCounter == 0)
//            {
//                stopCounter = 1;
//                maxSpeed = 0;
//                finalPanel.SetActive(true);
//            }
//        }
//        if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
//        {
//            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel2 == 100 && stopCounter == 0)
//            {
//                stopCounter = 1;
//                maxSpeed = 0;
//                finalPanel.SetActive(true);
//            }
//        }
//        if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
//        {
//            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel3 == 100 && stopCounter == 0)
//            {
//                stopCounter = 1;
//                maxSpeed = 0;
//                finalPanel.SetActive(true);
//            }
//        }
//        if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
//        {
//            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel4 == 100 && stopCounter == 0)
//            {
//                stopCounter = 1;
//                maxSpeed = 0;
//                finalPanel.SetActive(true);
//            }
//        }
//        if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
//        {
//            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel5 == 100 && stopCounter == 0)
//            {
//                stopCounter = 1;
//                maxSpeed = 0;
//                finalPanel.SetActive(true);
//            }
//        }


//    }
//    private void LateUpdate()
//    {
//        RotateVisualWheels();
//    }
//    private void SetUpWheels()
//    {
//        if ((null == frontLeftWheel || null == frontRightWheel || null == rearLeftWheel || null == rearRightWheel))
//        {
//            Debug.Log("Error");
//        }
//        else
//        {
//            wheelTransform[0] = frontLeftWheel;
//            wheelTransform[1] = rearLeftWheel;
//            wheelTransform[2] = frontRightWheel;
//            wheelTransform[3] = rearRightWheel;
//        }
//    }
//    private void RotateVisualWheels()
//    {
//        Vector3 tmpEulerAngels = LFWheelTransform.localEulerAngles;
//        tmpEulerAngels.y = horizontal * 30; // 30

//        LFWheelTransform.localEulerAngles = tmpEulerAngels;
//        RFWheelTransform.localEulerAngles = tmpEulerAngels;

//        rotationAmount = carRight * (relativeVelocity.z * 1.6f * Time.deltaTime * Mathf.Rad2Deg);
//        wheelTransform[0].Rotate(rotationAmount);
//        wheelTransform[1].Rotate(rotationAmount);
//        wheelTransform[2].Rotate(rotationAmount);
//        wheelTransform[3].Rotate(rotationAmount);
//    }
//    private void CheckInput()
//    {
//        if (_floatingJoystick.Horizontal > 0)
//        {
//            horizontal = 1;
//        }
//        if (_floatingJoystick.Horizontal < 0)
//        {
//            horizontal = -1;
//        }
//        if (_floatingJoystick.Vertical > 0)
//        {
//            throttle = 1;
//            slowDown = false;
//        }
//        if (_floatingJoystick.Vertical < 0)
//        {
//            throttle = -1;
//            slowDown = false;
//        }
//        if (_floatingJoystick.Horizontal == 0)
//        {
//            horizontal = 0;
//        }
//        if (_floatingJoystick.Vertical == 0)
//        {
//            throttle = 0;
//            slowDown = true;
//        }
//        // horizontal = _floatingJoystick.Horizontal;
//        //  throttle = _floatingJoystick.Vertical;
//        //   horizontal = Input.GetAxisRaw("Horizontal");
//        //   throttle = Input.GetAxisRaw("Vertical");
//    }
//    private void CarPhysicsUpdate()
//    {
//        myRight = carTransform.right;
//        velo = thisRigidbody.velocity;
//        tempVec = new Vector3(velo.x, 0f, velo.z);
//        flatVelo = tempVec;
//        dir = transform.TransformDirection(carFwd);
//        tempVec = new Vector3(dir.x, 0, dir.z);
//        flatDir = Vector3.Normalize(tempVec);
//        relativeVelocity = carTransform.InverseTransformDirection(flatVelo);
//        slideSpeed = Vector3.Dot(myRight, flatVelo);
//        mySpeed = flatVelo.magnitude;
//        rev = Mathf.Sign(Vector3.Dot(flatVelo, flatDir));
//        engineForce = (flatDir * (power * throttle) * carMass);
//        if (mySpeed < 0.1f)
//        {
//            canTurn = false;
//        }
//        else
//        {
//            canTurn = true;
//        }
//        if (canTurn)
//        {
//            actualTurn = horizontal;
//            if (rev < 0.1f)
//            {
//                actualTurn = -actualTurn;
//            }

//            turnVec = (((carUp * turnSpeed) * actualTurn) * carMass) * 800f;
//            actualGrip = Mathf.Lerp(100f, carGrip, mySpeed * 0.02f);
//            imp = myRight * (-slideSpeed * carMass * actualGrip);
//        }

//    }
//    private void FixedUpdate()
//    {
//        if (mySpeed < maxSpeed)
//        {
//            thisRigidbody.AddForce(engineForce * Time.deltaTime);
//        }
//        if (mySpeed > maxSpeedToTurn)
//        {
//            thisRigidbody.AddTorque(turnVec * Time.deltaTime);
//        }
//        else if (mySpeed < maxSpeedToTurn)
//        {
//            return;
//        }
//        thisRigidbody.AddForce(imp * Time.deltaTime);

//        if (!canTurn)
//        {
//            thisRigidbody.angularVelocity = Vector3.Lerp(thisRigidbody.angularVelocity, Vector3.zero, slowDownAngularSpeed * Time.deltaTime);
//        }
//        if (slowDown)
//        {
//            thisRigidbody.velocity = Vector3.Lerp(thisRigidbody.velocity, Vector3.zero, slowDownSpeed * Time.deltaTime);
//        }
//    }



//}



