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
    private int stopCounter;
    [SerializeField] private GameObject finalPanel;
    

    private void Update()
    {
        if (gamemodeRunning)
        {
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 1)
            {
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 = 100;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel1 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
            {
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 = 100;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel2 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
            {
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 = 100;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel3 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
            {
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 = 100;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel4 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
            {
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 = 100;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel5 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
        }

        if (gamemodeBicycle)
        {
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
            {
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 = 100;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel1 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
            {
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 = 100;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel2 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
            {
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 = 100;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel3 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
            {
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 = 100;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel4 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
            {
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 >= 100 && stopCounter == 0)
                {
                    stopCounter = 1;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 = 100;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel5 = 1;
                    Geekplay.Instance.Save();
                    moveSpeed = 0;
                    finalPanel.SetActive(true);
                }
            }
        }
    }
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
