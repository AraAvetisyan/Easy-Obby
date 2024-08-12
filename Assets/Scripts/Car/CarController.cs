using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.AudioSettings;

public class CarController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private ForwardButtonScript _forwardButtonScript;
    [SerializeField] private ReverseButtonScript _reverseButtonScript;
    [SerializeField] private Rigidbody rb;
    private float currentVelocity;
    private float speedVelocity;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float smootRotationTimer;
    [SerializeField] private float smootSpeedTimer;
    public float moveSpeed;
    [SerializeField] private Transform camera;
    [SerializeField] private bool isMobile;
    private float targertSpeed;
    private int speedCounter;
    private bool notFirstMove;
    Vector2 inputDir;
    public void FixedUpdate()
    {

        Vector2 input = Vector2.zero;
        if (isMobile)
        {
            input = new Vector2(_floatingJoystick.Horizontal, 0);
        }
        else
        {
            input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        }
        inputDir = input.normalized;

        if (inputDir != Vector2.zero)
        {
            if (currentSpeed!=0)
            {
                float rotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + camera.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, rotation, ref currentVelocity, smootRotationTimer);
            }
        }
        if (_forwardButtonScript.ForwardPressed)
        {
            speedCounter = 1;
            if (notFirstMove)
            {
                smootSpeedTimer = 0.3f;
            }
            if(inputDir.magnitude != 0)
            {
                targertSpeed = moveSpeed * _forwardButtonScript.Speed * inputDir.magnitude;
            }
            else
            {
                targertSpeed = moveSpeed * _forwardButtonScript.Speed;
            }
        }
        
        if(_reverseButtonScript.ReversePressed)
        {
            speedCounter = 1;
            if (notFirstMove)
            {
                smootSpeedTimer = 0.3f;
            }
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
            if(speedCounter == 1)
            {
                StartCoroutine(WaitSpeedZero());
                speedCounter = 2;
            }
        }
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targertSpeed, ref speedVelocity, smootSpeedTimer);
        
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);
        if (currentSpeed == 0)
        {
            rb.velocity = Vector3.zero;
        }
    }

    public IEnumerator WaitSpeedZero()
    {
        yield return new WaitForSeconds(0.1f);
        smootSpeedTimer = 0;
        notFirstMove = true;
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
