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
    public bool IsFalling;
    public bool IsSprint;
    public bool IsJumping;
    [SerializeField] private List<GameObject> graundObjects;
    public bool IsGrounded;
    public Animator Animator;
    private int stopCounter;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject[] trails;
    public bool CanOnTrail;
    float currentRotation;
    int anal;
    [SerializeField] private AudioSource walkSound;
    public bool CanPlaySound;
  

    private void Update()
    {
        if (anal == 0 && MainMenuUI.Instance.NewGame)
        {
            anal = 1;
            Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + "StartNewGame");
            Debug.Log(SceneManager.GetActiveScene().name + "StartNewGame");
        }
        if (anal == 0 && MainMenuUI.Instance.ContinueGame)
        {
            anal = 1;
            Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + "ContinueGame");
            Debug.Log(SceneManager.GetActiveScene().name + "ContinueGame");
        }

        if (Geekplay.Instance.PlayerData.MapIndex == 0 || Geekplay.Instance.PlayerData.MapIndex == 1 || Geekplay.Instance.PlayerData.MapIndex == 5 || Geekplay.Instance.PlayerData.MapIndex == 6)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] >= 34 && stopCounter == 0)
            {
                stopCounter = 1;
                Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] = 34;
                Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] = 1;
                Geekplay.Instance.Save();
                moveSpeed = 0;
                finalPanel.SetActive(true);
            }
        }

        if (Geekplay.Instance.PlayerData.MapIndex == 2 || Geekplay.Instance.PlayerData.MapIndex == 3 || Geekplay.Instance.PlayerData.MapIndex == 7 || Geekplay.Instance.PlayerData.MapIndex == 8)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] >= 50 && stopCounter == 0)
            {
                stopCounter = 1;
                Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] = 50;
                Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] = 1;
                Geekplay.Instance.Save();
                moveSpeed = 0;
                finalPanel.SetActive(true);
            }
        }


        if (Geekplay.Instance.PlayerData.MapIndex == 4 || Geekplay.Instance.PlayerData.MapIndex == 9)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] >= 100 && stopCounter == 0 || Geekplay.Instance.PlayerData.MapIndex == 10)
            {
                stopCounter = 1;
                Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] = 100;
                Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] = 1;
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
        if (IsGrounded && rb.velocity != Vector3.zero && !IsJumping)
        {
            rb.velocity = Vector3.zero;
        }
        if (graundObjects.Count > 0)
        {
            IsGrounded = true;
            IsFalling = false;
        }
        else
        {
            IsGrounded = false;
        }
        if (gamemodeBicycle)
        {
            if (IsSprint && CurrentSpeed > 0 && !IsFalling)
            {
                for (int i = 0; i < trails.Length; i++)
                {

                    trails[i].SetActive(true);

                }
            }
            if (!IsSprint || CurrentSpeed == 0)
            {
                for (int i = 0; i < trails.Length; i++)
                {
                    trails[i].SetActive(false);
                }
            }

        }
        if (gamemodeRunning)
        {
            if (CurrentSpeed > 0 && !IsSprint && !IsFalling)
            {
                walkSound.pitch = 1.5f;
                Animator.SetBool("IsRunning", true);
                CanPlaySound = true;
            }
            if (CurrentSpeed == 0 && !IsFalling)
            {
                CanPlaySound = false;
                Animator.SetBool("IsRunning", false);
            }

            if (IsSprint && CurrentSpeed > 0 && !IsFalling)
            {

                if (!CanOnTrail)
                {
                    StartCoroutine(CanTrail());
                }
                walkSound.pitch = 1.75f;
                Animator.SetBool("IsSprint", true);
                Animator.SetBool("IsRunning", false);
                CanPlaySound = true;
                for (int i = 0; i < trails.Length; i++)
                {
                    if (CanOnTrail)
                    {
                        trails[i].SetActive(true);
                    }
                }
            }
            if (!IsSprint || CurrentSpeed == 0)
            {
                Animator.SetBool("IsSprint", false);
                for (int i = 0; i < trails.Length; i++)
                {
                    trails[i].SetActive(false);
                }
                CanOnTrail = false;
            }

            if (IsFalling)
            {
                CanPlaySound = false;
                
                Animator.SetBool("IsFalling", true);
            }
            else
            {
                Animator.SetBool("IsFalling", false);
            }
            if (IsJumping)
            {
                CanPlaySound = false;
            }
            if (CanPlaySound)
            {
                walkSound.volume = 1;
            }
            if (!CanPlaySound)
            {
                walkSound.volume = 0;
            }
        }
       

    }
    public IEnumerator CanTrail()
    {
        yield return new WaitForSeconds(0.25f);
        CanOnTrail = true;
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