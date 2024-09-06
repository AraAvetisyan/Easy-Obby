using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    float currentRotation;
    private void OnEnable()
    {
        MainMenuUI.NewGame += NewGameAnal;
        MainMenuUI.ContinueGame += ContinueGameAnal;
        Teleport.GameEnds += GameEnds;
    }
    private void OnDisable()
    {
        MainMenuUI.NewGame -= NewGameAnal;
        MainMenuUI.ContinueGame -= ContinueGameAnal;
        Teleport.GameEnds -= GameEnds;
    }
    public void NewGameAnal(bool bb)
    {
        Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + " Start_New_Game");
    }
    public void ContinueGameAnal(bool bb)
    {
        Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + " Continue_Game");
    }
    public void GameEnds(bool bb)
    {
        Debug.Log("NU");
        if (Geekplay.Instance.PlayerData.MapIndex == 0 || Geekplay.Instance.PlayerData.MapIndex == 1 || Geekplay.Instance.PlayerData.MapIndex == 5 || Geekplay.Instance.PlayerData.MapIndex == 6)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressLevels[0] >= 34 && stopCounter == 0)
            {
                stopCounter = 1;
                Geekplay.Instance.PlayerData.SaveProgressLevels[0] = 34;
                Geekplay.Instance.PlayerData.FillAmountLevels[0] = 1;
                Geekplay.Instance.Save();
                moveSpeed = 0;
                finalPanel.SetActive(true);

            }
        }
        if (Geekplay.Instance.PlayerData.MapIndex == 2 || Geekplay.Instance.PlayerData.MapIndex == 3 || Geekplay.Instance.PlayerData.MapIndex == 7 || Geekplay.Instance.PlayerData.MapIndex == 8)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressLevels[2] >= 50 && stopCounter == 0)
            {
                stopCounter = 1;
                Geekplay.Instance.PlayerData.SaveProgressLevels[2] = 50;
                Geekplay.Instance.PlayerData.FillAmountLevels[2] = 1;
                Geekplay.Instance.Save();
                moveSpeed = 0;
                finalPanel.SetActive(true);
            }
        }
        if (Geekplay.Instance.PlayerData.MapIndex == 4 || Geekplay.Instance.PlayerData.MapIndex == 9)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressLevels[5] >= 100 && stopCounter == 0 || Geekplay.Instance.PlayerData.MapIndex == 10)
            {
                stopCounter = 1;
                Geekplay.Instance.PlayerData.SaveProgressLevels[5] = 100;
                Geekplay.Instance.PlayerData.FillAmountLevels[5] = 1;
                Geekplay.Instance.Save();
                moveSpeed = 0;
                finalPanel.SetActive(true);
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

        transform.Translate(transform.forward * CurrentSpeed * Time.deltaTime, Space.World);
        if (IsGrounded && rb.velocity != Vector3.zero && !Jumping)
        {
            rb.velocity = Vector3.zero;
        }
        if (graundObjects.Count > 0)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
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
