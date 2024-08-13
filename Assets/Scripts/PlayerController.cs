using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Rigidbody rb;
    private float currentVelocity;
    private float speedVelocity;
    public float CurrentSpeed;
    [SerializeField] private float smootRotationTimer;
    [SerializeField] private float smootSpeedTimer;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform camera;
    [SerializeField] private SprintButtonScript _sprintButtonScript;
    [SerializeField] private bool gamemodeRunning;
    [SerializeField] private bool gamemodeBicycle;
    [SerializeField] private bool isMobile;
    public bool Jumping;
    [SerializeField] private List<GameObject> graundObjects;
    public bool IsGrounded;
    public Animator Animator;

    public void FixedUpdate()
    {
        Vector2 input = Vector2.zero;
        if (isMobile)
        {
            input = new Vector2(_floatingJoystick.Horizontal, _floatingJoystick.Vertical);
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
        float targertSpeed = moveSpeed * inputDir.magnitude * _sprintButtonScript.SprintSpeed;
        CurrentSpeed = Mathf.SmoothDamp(CurrentSpeed, targertSpeed, ref speedVelocity, smootSpeedTimer);
        if (gamemodeRunning)
        {
            if (CurrentSpeed > 0)
            {
                Animator.SetBool("IsRunning", true);
            }
            if (CurrentSpeed == 0)
            {
                Animator.SetBool("IsRunning", false);
            }
        }
        if (gamemodeBicycle)
        {
            if (targertSpeed != 0)
            {
                Animator.SetBool("OnMove", true);
            }
            if(targertSpeed == 0)
            {
                Animator.SetBool("OnMove", false);
            }
        }
        transform.Translate(transform.forward * CurrentSpeed * Time.deltaTime, Space.World);
        if (IsGrounded && rb.velocity != Vector3.zero && !Jumping)
        {
            rb.velocity = Vector3.zero;
        }
        if(graundObjects.Count > 0)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }
   
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        
    }
    public void OnCollisionExit(Collision collision)
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            graundObjects.Add(other.gameObject);
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            graundObjects.Remove(other.gameObject);
        }
    }
}
