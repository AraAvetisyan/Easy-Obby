using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public FloatingJoystick _floatingJoystick;
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
    public AudioSource walkSound;
    public bool CanPlaySound;



    [SerializeField]
    private CinemachineVirtualCamera connectedCamera;

    [SerializeField] private TouchDeltaInput touchDeltaInput;
    [SerializeField] private TouchDeltaInput touchDeltaInputPC;

    [SerializeField] private Transform mainCameraPoint;
    private CinemachinePOV cinemachinePOV;
    private CinemachineFramingTransposer framingTransposer;
    private float startFov;
    private float startDistance;
    private float targetFov;
    private float targetDistance;
    private Vector3 touchDeltaDir;
    public Vector2 inputVector { get; private set; }

    public bool IsCoyot;
    public bool isAngular;

    [Header("PC")]
    public GameObject jumpButton;
    public GameObject sptintButton;
    [SerializeField] private Transform buttonsPos;
    
    public Teleport _teleport;

    private Coroutine coyoteCoroutine;
    IEnumerator cor;
    [SerializeField] private JumpButtonScript _jumpButtonScript;
    private void Start()
    {
        if (Geekplay.Instance.mobile)
        {
            isMobile = true;
            touchDeltaInputPC.gameObject.SetActive(false);
        }
        else
        {
            isMobile = false;
            _floatingJoystick.gameObject.SetActive(false);
            jumpButton.transform.position = buttonsPos.position;
            sptintButton.transform.position = buttonsPos.position;
            touchDeltaInputPC.gameObject.SetActive(true);
            touchDeltaInput.gameObject.SetActive(false);
        }
        cinemachinePOV = connectedCamera.GetCinemachineComponent<CinemachinePOV>();
        framingTransposer = connectedCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        startFov = connectedCamera.m_Lens.FieldOfView;
        targetFov = startFov;
        connectedCamera.LookAt = mainCameraPoint;
        connectedCamera.Follow = mainCameraPoint;
        startDistance = framingTransposer.m_CameraDistance;
        targetDistance = startDistance;
    }

    private void Update()
    {
        Animator.SetBool("OnGround", IsGrounded);
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
    private void SetFov()
    {
        connectedCamera.m_Lens.FieldOfView = Mathf.Lerp(connectedCamera.m_Lens.FieldOfView, targetFov, 0.1f);
        framingTransposer.m_CameraDistance = Mathf.Lerp(framingTransposer.m_CameraDistance, targetDistance, 0.1f);
    }
    private void LateUpdate()
    {
        Vector3 startRotPoint = connectedCamera.transform.position;
        Vector3 endRotPoint = connectedCamera.LookAt.transform.position;
        startRotPoint.y = 0;
        endRotPoint.y = 0;
        Vector3 direction = (Quaternion.LookRotation((endRotPoint - startRotPoint).normalized, Vector3.up) * new Vector3(inputVector.x, 0, inputVector.y)).normalized;
    }
    public void LocomotionProcess()
    {
        Vector3 startRotPoint = connectedCamera.transform.position;
        Vector3 endRotPoint = connectedCamera.LookAt.transform.position;
        startRotPoint.y = 0;
        endRotPoint.y = 0;
        Vector3 direction = (Quaternion.LookRotation((endRotPoint - startRotPoint).normalized, Vector3.up) * new Vector3(inputVector.x, 0, inputVector.y)).normalized;
       
    }
    public void FixedUpdate()
    {
        if (isMobile)
        {
            touchDeltaDir = touchDeltaInput.TouchDelta * 0.25f;
            cinemachinePOV.m_HorizontalAxis.m_InputAxisValue = -touchDeltaDir.x;
            cinemachinePOV.m_VerticalAxis.m_InputAxisValue = -touchDeltaDir.y;
        }
        else
        {
            touchDeltaDir = touchDeltaInputPC.TouchDelta * 0.35f;
            cinemachinePOV.m_HorizontalAxis.m_InputAxisValue = touchDeltaDir.x;
            cinemachinePOV.m_VerticalAxis.m_InputAxisValue = touchDeltaDir.y;
        }
        SetFov();


        LocomotionProcess();

        Vector2 input = Vector2.zero;

        if (_teleport.CanMove)
        {
            if (isMobile)
            {
                input = new Vector2(_floatingJoystick.Horizontal, _floatingJoystick.Vertical);

            }
            else
            {
                input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            }
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
        if (IsGrounded && rb.velocity != Vector3.zero && !IsJumping && !isAngular)
        {
            isAngular = true;
            rb.velocity = Vector3.zero;
            
        }
        if (graundObjects.Count > 0 && _jumpButtonScript.jumpCounter == 0)
        {
            IsGrounded = true;
            IsFalling = false;
            IsCoyot = false;
            isAngular = false;
            _jumpButtonScript.DoubleJumpCounter = 0;
            if (_teleport.DoubleJump)
            {
                _jumpButtonScript.DoubleJump = 0;
            }
        }
        else if(graundObjects.Count <= 0 && !IsCoyot && !IsJumping)
        {
            //IsCoyot = true;
            // StartCoyoteCorutine();
            if (cor != null)
                StopCoroutine(cor);
            cor = CoyotTime();
            StartCoroutine(cor);
        }
        else if(graundObjects.Count <= 0 && IsJumping)
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
                if (_teleport.CanMove)
                {
                    if (_jumpButtonScript.DoubleJump == 0)
                    {
                        walkSound.pitch = 1.4f;
                        Animator.SetBool("IsRunning", true);
                        CanPlaySound = true;
                    }
                }
                else
                {
                    CanPlaySound = false;
                }
            }
            if (CurrentSpeed == 0 && !IsFalling)
            {
                CanPlaySound = false;
                Animator.SetBool("IsRunning", false);
            }
            //if(IsSprint && IsJumping)
            //{
            //   // CanOnTrail = false;
            //    for (int i = 0; i < trails.Length; i++)
            //    {
            //        trails[i].SetActive(false);                 
            //    }
            //}
            if (IsSprint && CurrentSpeed > 0 && !IsFalling)
            {
                if (_teleport.CanMove)
                {
                    if (!CanOnTrail)
                    {
                        StartCoroutine(CanTrail());
                    }
                    if (_jumpButtonScript.DoubleJump == 0)
                    {
                        walkSound.pitch = 1.55f;

                        Animator.SetBool("IsSprint", true);
                        Animator.SetBool("IsRunning", false);
                        CanPlaySound = true;
                    }
                    for (int i = 0; i < trails.Length; i++)
                    {
                        if (CanOnTrail)
                        {
                            trails[i].SetActive(true);
                        }
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
                if (_teleport.CanSoundOn)
                {
                    walkSound.volume = 0.65f;
                }
                else
                {
                    walkSound.volume = 0;
                }
            }
            if (!CanPlaySound)
            {
                walkSound.volume = 0;
            }
        }
    }
    public void StartCoyoteCorutine()
    {
        if(coyoteCoroutine == null)
        {
            coyoteCoroutine = StartCoroutine(CoyotTime());
        }
    }
    public void StopCoyoteCoroutine()
    {
        if(coyoteCoroutine != null)
        {
            StopCoroutine(coyoteCoroutine);
            coyoteCoroutine = null;
        }
    }
    public IEnumerator CoyotTime()
    {
        //yield return new WaitForSeconds(0.05f);
        IsCoyot = true;
        yield return new WaitForSeconds(3f);
        IsCoyot = false;
        isAngular = false;
        IsGrounded = false;
        StopCoyoteCoroutine();
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