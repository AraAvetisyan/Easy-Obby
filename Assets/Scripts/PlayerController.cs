using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private Rigidbody rb;
    private float currentVelocity;
    private float speedVelocity;
    private float currentSpeed;
    [SerializeField] private float smootRotationTimer = 0.25f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Transform camera;

    [SerializeField] private bool isMobile;

    [SerializeField] private float jumpForce;
    [SerializeField] private bool isGrounded;
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
        float targertSpeed = moveSpeed * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targertSpeed, ref speedVelocity, 0.1f);
        transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        if (Input.GetKeyDown(KeyCode.E))
        {
            JumpButtonPressed();
        }
    }
    public void JumpButtonPressed()
    {
        if (isGrounded)
        {
            isGrounded = false;
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }       
    }
    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
