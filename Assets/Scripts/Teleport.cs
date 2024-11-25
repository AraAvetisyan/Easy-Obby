﻿using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VehicleBehaviour;

public class Teleport : MonoBehaviour
{ 
    public static Teleport Instance;
    [SerializeField] private TimerScript _timerScript;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform tp;
    [SerializeField] private Transform[] allTP;
    [SerializeField] private Slider fillImage;
    [SerializeField] private GameObject fillImageObject;
    [SerializeField] private int fillCount;
    [SerializeField] private TextMeshProUGUI fillText;
    [SerializeField] private bool gamemodeRunning;
    [SerializeField] private bool gamemodeCar;
    [SerializeField] private bool gamemodeBicycle;
    [SerializeField] private BoxCollider[] boxColliders;
    [SerializeField] private int coins;
    float fillAmount;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI diamondsText;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private VehicleControl _vehicleControl;


    [SerializeField] private bool isTest;
    [SerializeField] private float fillAmountTest;
    [SerializeField] private int fillCountTest;
    [SerializeField] private int progressCountTest;

    [SerializeField] private GameObject[] teleportParticles;
    [SerializeField] private GameObject[] coinParticles;
    [SerializeField] private GameObject[] teleportObjects;
    [SerializeField] private MeshRenderer[] coinMeshes;
    [SerializeField] private MeshRenderer[] startLines;
    [SerializeField] private MeshRenderer[] flagMeshes, cloatMeshes;
    [SerializeField] private int coinMeshCounter;

    [SerializeField] private bool front, back, left, right;

    [SerializeField] private GameObject carObject;
    private Coroutine enumerator;
    public bool mustBrake;

    [SerializeField] private GameObject[] parts;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject bicycleObject;
    [SerializeField] private Transform[] meshTransforms;
    private Coroutine endEnumerator;
    private bool isDead;

    [SerializeField] private AudioSource checkpointAudio;
    [SerializeField] private AudioSource deadAudio;
    [SerializeField] private AudioSource finishAudio;


    public AudioSource[] carSounds;
    int deadAudioCount;

    [Header("ShowAd")]
    [SerializeField] private GameObject showAdPanel;
    [SerializeField] private TextMeshProUGUI showAdText;
    [SerializeField] private AudioSource music;
    private Coroutine showAdCoroutine;
    [SerializeField] private Button toMenuButton;
    public bool CanMove;
    public bool CanSoundOn;
    private Coroutine startShowCoroutine;
    private Coroutine finishCoroutine;
    [SerializeField] private SprintButtonScript _sprintButtonScript;

    public bool CanJump;

    [Header("Sounds")]
    [SerializeField] private GameObject carSoundsObject;
    [SerializeField] private GameObject runSoundObject;

    [Header("DoubleJump")]
    [SerializeField] private int checkpointCounter;
    [SerializeField] private GameObject[] rewardObjects;
    [SerializeField] private TextMeshProUGUI[] doubleJumpText;
    private IEnumerator rewardCoroutine;
    private Coroutine doubleCoroutine;
    public bool DoubleJump;
    [SerializeField] private Image doubleJumpImage;
    [SerializeField] private GameObject doubleJumpActiveObject;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        Geekplay.Instance.PlayerData.IsMenu = false;
        CanMove = true;
        CanSoundOn = true;
        CanJump = true;
        music = GameObject.Find("AudioSourceMusic").GetComponent<AudioSource>();
        for(int i = 0; i < parts.Length; i++)
        {
            meshTransforms[i].position = parts[i].transform.position;
            meshTransforms[i].rotation = parts[i].transform.rotation;
        }
        if (isTest)
        {
            fillAmountTest = 0.25f;
            fillCountTest = 25;
            progressCountTest = 25;
        }

        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();

        fillAmount = Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex];
        fillCount = Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex];
        coinMeshCounter = Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex];
        fillImage.value = fillAmount;
        if(fillAmount == 0)
        {
            fillImageObject.SetActive(false);
        }
        fillText.text = fillCount.ToString() + "%";
        if (Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] < allTP.Length)
        {
            tp = allTP[Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex]];
        }
        else
        {
            tp = allTP[allTP.Length - 1];
        }
        for (int i = 0; i < boxColliders.Length; i++)
        {
            if (i <= Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex])
            {
                boxColliders[i].enabled = false;
                if (gamemodeRunning)
                {
                    coinMeshes[i].enabled = false;
                    coinParticles[i].SetActive(false);
                }
                if (gamemodeBicycle)
                {
                    flagMeshes[i].enabled = false;
                    cloatMeshes[i].enabled = false;
                }
                if (gamemodeCar)
                {
                    startLines[i].enabled = false;
                }
            }
        }
        transform.position = tp.position;
        if (Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] == 0)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
            transform.rotation = targetRotation;
        }
        if (Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] == 1)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
            transform.rotation = targetRotation;
        }
        if (Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] == 2)
        {
            Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
            transform.rotation = targetRotation;
        }
        if (Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] == 3)
        {
            Quaternion targetRotation = Quaternion.Euler(0, -90, 0);
            transform.rotation = targetRotation;
        }
        StartCoroutine(tpcor());
        IEnumerator tpcor()
        {
            yield return new WaitForFixedUpdate();
            transform.position = tp.position;
        }


        if (Geekplay.Instance.language == "en")
        {
            for (int i = 0; i < doubleJumpText.Length; i++)
            {
                doubleJumpText[i].text = "Double jump for a minute";
            }
        }
        else if (Geekplay.Instance.language == "ru")
        {
            for (int i = 0; i < doubleJumpText.Length; i++)
            {
                doubleJumpText[i].text = "Двойной прыжок на минуту";
            }
        }
        else if (Geekplay.Instance.language == "tr")
        {
            for (int i = 0; i < doubleJumpText.Length; i++)
            {
                doubleJumpText[i].text = "Bir dakikalığına çift zıplama";
            }
        }
        else if (Geekplay.Instance.language == "ar")
        {
            for (int i = 0; i < doubleJumpText.Length; i++)
            {
                doubleJumpText[i].text = "قفزة مزدوجة لمدة دقيقة";
            }
        }
        else if (Geekplay.Instance.language == "es")
        {
            for (int i = 0; i < doubleJumpText.Length; i++)
            {
                doubleJumpText[i].text = "Doble salto durante un minuto";
            }
        }
        else if (Geekplay.Instance.language == "de")
        {
            for (int i = 0; i < doubleJumpText.Length; i++)
            {
                doubleJumpText[i].text = "Doppelsprung für eine Minute";
            }
        }
    }
   
   
    private void OnEnable()
    {
        Rewarder.ChangeDiamond += ChangeDimondsText;
    }
    private void OnDisable()
    {
        Rewarder.ChangeDiamond -= ChangeDimondsText;
    }
    private void Update()
    {
        if (Geekplay.Instance.adOpen)
        {
            if (gamemodeCar)
            {
                for (int j = 0; j < carSounds.Length; j++)
                {
                    carSounds[j].enabled = false;
                }
            }
        }
        else
        {
            if (gamemodeCar)
            {
                for (int j = 0; j < carSounds.Length; j++)
                {
                    carSounds[j].enabled = true;
                }
            }
        }
    }

    public void ChangeDimondsText(bool bb)
    {
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
    }
    public void StartStartShow()
    {
        if(startShowCoroutine == null)
        {
            startShowCoroutine = StartCoroutine(StartShow());
        }
    }
    public void StopStartShow()
    {
        if(startShowCoroutine != null)
        {
            StopCoroutine(startShowCoroutine);
            startShowCoroutine = null;
        }
    }
    public IEnumerator StartShow()
    {
        yield return new WaitForSeconds(0.1f);

        StartShowAdCoroutine();
        StopStartShow();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Front"))
        {
            Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] = 0;
            front = true;
            back = false;
            right = false;
            left = false;
        }
        if (other.CompareTag("Back"))
        {

            Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] = 1;
            front = false;
            back = true;
            right = false;
            left = false;
        }
        if (other.CompareTag("Right"))
        {
            Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] = 2;
            front = false;
            back = false;
            right = true;
            left = false;
        }
        if (other.CompareTag("Left"))
        {
            Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] = 3;
            front = false;
            back = false;
            right = false;
            left = true;
        }

        if (other.gameObject.CompareTag("ToTeleport"))
        {
            if (gamemodeRunning)
            {
                _playerController.IsFalling = true;
            }
        }
        if (other.CompareTag("TeleportFalling"))
        {
            if (gamemodeRunning)
            {
                _playerController.IsFalling = false;
            }
            if (front)
            {
                Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = targetRotation;
            }
            if (back)
            {
                Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = targetRotation;
            }
            if (right)
            {
                Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                transform.rotation = targetRotation;
            }
            if (left)
            {
                Quaternion targetRotation = Quaternion.Euler(0, -90, 0);
                transform.rotation = targetRotation;
            }
            rb.velocity = Vector3.zero;
           

            transform.position = tp.position;
            deadAudio.Play();
            if (gamemodeCar)
            {
                StartCorutine();
            }
            else
            {
                StartStartShow();
            }
        }
        if (other.CompareTag("Teleport"))
        {
            
            if (!gamemodeCar)
            {
                CanJump = false;
                if (!isDead)
                {
                    Destroy();
                }
            }
            if (gamemodeRunning)
            {
                _playerController.IsFalling = false;
            }
            if (front)
            {
                Quaternion targetRotation = Quaternion.Euler(0, 0, 0);
                transform.rotation = targetRotation;
            }
            if (back)
            {
                Quaternion targetRotation = Quaternion.Euler(0, 180, 0);
                transform.rotation = targetRotation;
            }
            if (right)
            {
                Quaternion targetRotation = Quaternion.Euler(0, 90, 0);
                transform.rotation = targetRotation;
            }
            if (left)
            {
                Quaternion targetRotation = Quaternion.Euler(0, -90, 0);
                transform.rotation = targetRotation;
            }
            rb.velocity = Vector3.zero;
            if (gamemodeCar)
            {
                StartCorutine();
                transform.position = tp.position;
            }
            if (deadAudioCount == 0)
            {
                deadAudioCount = 1;
                deadAudio.Play();
            }
        }
        if (other.CompareTag("ADS"))
        {
            for (int i = 0; i < rewardObjects.Length; i++)
            {
                rewardObjects[i].SetActive(false);
            }
            Geekplay.Instance.ShowRewardedAd("DoubleJump");
          
        }
        if (other.CompareTag("TeleportPoint"))
        {
            for (int i = 0; i < teleportObjects.Length; i++)
            {
                if (other.name == teleportObjects[i].name)
                {
                    if (gamemodeRunning)
                    {
                        coinMeshes[i].enabled = false;
                        coinParticles[i].SetActive(false);
                    }
                    if (gamemodeBicycle)
                    {
                        flagMeshes[i].enabled = false;
                        cloatMeshes[i].enabled = false;
                        teleportParticles[i].SetActive(true);
                    }
                    if (gamemodeCar)
                    {
                        startLines[i].enabled = false;
                        teleportParticles[i].SetActive(true);
                    }
                    other.GetComponent<BoxCollider>().enabled = false;
                    teleportParticles[i].SetActive(true);
                    if (fillCount == 30)
                    {
                        Geekplay.Instance.RateGameFunc();
                    }
                    else if (fillCount == 60)
                    {
                        Geekplay.Instance.RateGameFunc();
                    }
                    else if (fillCount == 90)
                    {
                        Geekplay.Instance.RateGameFunc();
                    }
                    if (fillCount < 100)
                    {
                        checkpointAudio.Play();
                    }
                    if (Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] < i)
                    {

                        tp = other.gameObject.transform;
                        fillCount = i * fillCountTest;
                        fillImageObject.SetActive(true);
                        fillImage.value = i * fillAmountTest;
                        Geekplay.Instance.PlayerData.Coins += progressCountTest;
                        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
                        Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] = i;
                        Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] = fillCount;
                        Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] = fillImage.value;
                        Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = _timerScript.Minutes;
                        Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = _timerScript.Seconds;
                        Geekplay.Instance.Save();
                        Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + "Checkpoint" + Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex]);
                        Debug.Log(SceneManager.GetActiveScene().name + "Checkpoint" + Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex]);


                        if (fillCount >= 100)
                        {

                            StartFinishCoroutine();

                        }


                        fillText.text = fillCount.ToString() + "%";
                    }
                }
            }
            if (fillCount < 100)
            {
                StartStartShow();
            }

            
        }
    }
    
    public void DoubleJumpReward()
    {
        DoubleJump = true;
       
        StartDoubleJumpCoroutine();
        if (rewardCoroutine != null)
            StopCoroutine(rewardCoroutine);
    }
    public void StartDoubleJumpCoroutine()
    {
        if(doubleCoroutine != null)
        {
            StopCoroutine(doubleCoroutine);
            doubleCoroutine = null;
        }
        if(doubleCoroutine == null)
        {
            doubleCoroutine = StartCoroutine(DoubleTimer());
          
        }
    }
    public void StopDoubleJumpCoroutine()
    {
        if(doubleCoroutine != null)
        {
            StopCoroutine(doubleCoroutine);
            doubleCoroutine = null;
        }
    }
    public IEnumerator DoubleTimer()
    {
        doubleJumpActiveObject.SetActive(true);
        float duration = 60f;
        float elapsed = 0f;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            doubleJumpImage.fillAmount = (elapsed / duration);
            yield return null;
        }
        for(int i = 0; i < rewardObjects.Length; i++)
        {
            rewardObjects[i].SetActive(true);
        }
        DoubleJump = false;
        doubleJumpActiveObject.SetActive(false);
        doubleJumpImage.fillAmount = 0;
        StopDoubleJumpCoroutine();
    }
    public void ShowAd()
    {
        Geekplay.Instance.GameStoped = false;
        Geekplay.Instance.ShowInterstitialAd();            
        
        CanMove = true;
        showAdPanel.SetActive(false);


        music.volume = 0.35f;
        music.Play();       


        toMenuButton.interactable = true;
        
        if (!gamemodeCar)
        {
            if(gamemodeRunning)
                runSoundObject.SetActive(true);
            _playerController.jumpButton.GetComponent<Button>().interactable = true;
            _playerController.sptintButton.GetComponent<Button>().interactable = true;
            _playerController._floatingJoystick.gameObject.SetActive(true);
        }
        if (gamemodeCar)
        {
            carSoundsObject.SetActive(true);
            for (int i = 0; i < _vehicleControl.controllerButtons.Length; i++)
            {
                _vehicleControl.controllerButtons[i].interactable = true;
            }
        }

        Geekplay.Instance.PlayerData.Coins += 50;
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();

        Geekplay.Instance.Save();
        CanSoundOn = true;

       
        AdsTimerScript.Instance.StopMinutesCoroutine();
    }
    public void StartFinishCoroutine()
    {
        if(finishCoroutine == null)
        {
            finishCoroutine = StartCoroutine(StartFinish());
        }
    }
    public void StopFinishCoroutine()
    {
        if(finishCoroutine != null)
        {
            StopCoroutine(finishCoroutine);
            finishCoroutine = null;
        }
    }
    IEnumerator StartFinish()
    {
        yield return new WaitForSeconds(0.25f);
        if (gamemodeCar)
        {
            carSoundsObject.SetActive(false);
            for (int j = 0; j < carSounds.Length; j++)
            {
                carSounds[j].enabled = false;
            }
        }
        if (Geekplay.Instance.PlayerData.MapIndex == 0 || Geekplay.Instance.PlayerData.MapIndex == 5 || Geekplay.Instance.PlayerData.MapIndex == 10)
        {
            Geekplay.Instance.PlayerData.Coins += 50;
        }
        if (Geekplay.Instance.PlayerData.MapIndex == 1 || Geekplay.Instance.PlayerData.MapIndex == 6 || Geekplay.Instance.PlayerData.MapIndex == 11)
        {
            Geekplay.Instance.PlayerData.Coins += 100;
        }
        _timerScript.StopTimer();
        _timerScript.FinishTime();
        finishAudio.Play();
        StopFinishCoroutine();


      
    }
    public void StartShowAdCoroutine()
    {
        if (AdsTimerScript.Instance.CanShow)
        {
            if (showAdCoroutine == null)
            {
                showAdCoroutine = StartCoroutine(SecondsCoroutine());
            }
        }
    }
    public void StopShowAdCoroutine()
    {
        if (showAdCoroutine != null)
        {
            StopCoroutine(showAdCoroutine);
            showAdCoroutine = null;
        }
    }
    public IEnumerator SecondsCoroutine()
    {

        CanMove = false;

        CanSoundOn = false;
  
        showAdPanel.SetActive(true);
        toMenuButton.interactable = false;
        if (!gamemodeCar)
        {
            _sprintButtonScript.StopSprint();

            if (gamemodeRunning)
                runSoundObject.SetActive(false);
            _playerController.jumpButton.GetComponent<Button>().interactable = false;
            _playerController.sptintButton.GetComponent<Button>().interactable = false;
            _playerController._floatingJoystick.gameObject.SetActive(false);
        }
        if (gamemodeCar)
        {
            carSoundsObject.SetActive(false);
            for (int i = 0; i < _vehicleControl.controllerButtons.Length; i++)
            {
                _vehicleControl.controllerButtons[i].interactable = false;
            }
        }



        Geekplay.Instance.GameStoped = true;
        Time.timeScale = 0;
        music.volume = 0;
        music.Pause();
        
        if (Geekplay.Instance.language == "en")
            showAdText.text = "AD AFTER: 2";
        if (Geekplay.Instance.language == "ru")
            showAdText.text = "РЕКЛАМА ЧЕРЕЗ: 2";
        if (Geekplay.Instance.language == "de")
            showAdText.text = "WERBUNG NACH: 2";
        if (Geekplay.Instance.language == "es")
            showAdText.text = "ANUNCIO DESPUÉS: 2";
        if (Geekplay.Instance.language == "tr")
            showAdText.text = "REKLAMDAN SONRA: 2";
        if (Geekplay.Instance.language == "ar")
            showAdText.text = "الإعلان بعد: 2";
        yield return new WaitForSecondsRealtime(1);
        if (Geekplay.Instance.language == "en")
            showAdText.text = "AD AFTER: 1";
        if (Geekplay.Instance.language == "ru")
            showAdText.text = "РЕКЛАМА ЧЕРЕЗ: 1";
        if (Geekplay.Instance.language == "de")
            showAdText.text = "WERBUNG NACH: 1";
        if (Geekplay.Instance.language == "es")
            showAdText.text = "ANUNCIO DESPUÉS: 1";
        if (Geekplay.Instance.language == "tr")
            showAdText.text = "REKLAMDAN SONRA: 1";
        if (Geekplay.Instance.language == "ar")
            showAdText.text = "الإعلان بعد: 1";

        yield return new WaitForSecondsRealtime(1);

        if (fillCount < 100)
        {
            ShowAd();
        }
        StopShowAdCoroutine();
    }
    public void EndBrake()
    {
        mustBrake = false;
    }
    public void StartCorutine()
    {
        enumerator = StartCoroutine(StopCar());
    }
    public void StopCorutine()
    {


        StartStartShow();
        if (enumerator != null)
        {
            StopCoroutine(enumerator);
            enumerator = null;
        }
        _vehicleControl.carSetting.carPower = 120;
        _vehicleControl.carSetting.shiftPower = 150;
        _vehicleControl.carSetting.LimitForwardSpeed = 80;
        _vehicleControl.carSetting.LimitBackwardSpeed = 30;
        _vehicleControl.carSetting.automaticGear = true;
        _vehicleControl.curTorque = 100;
        _vehicleControl.carSetting.maxSteerAngle = 25;

        rb.constraints = RigidbodyConstraints.None;

    }
    public IEnumerator StopCar()
    {
        mustBrake = true;
        _vehicleControl.carSetting.carPower = 0;
        _vehicleControl.carSetting.shiftPower = 0;
        _vehicleControl.carSetting.LimitForwardSpeed = 0;
        _vehicleControl.carSetting.LimitBackwardSpeed = 0;
        _vehicleControl.carSetting.automaticGear = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.constraints = RigidbodyConstraints.FreezePosition;
        _vehicleControl.accel = 0;
        _vehicleControl.steer = 0;
        _vehicleControl.carSetting.maxSteerAngle = 0;
        for (int i = 0; i < _vehicleControl.wheels.Length; i++)
        {

            _vehicleControl.wheels[i].rotation = 0;
            _vehicleControl.wheels[i].rotation2 = 0;

        }
        _vehicleControl.curTorque = 0;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        yield return new WaitForSeconds(0.01f);
        StopCorutine();
    }
    public void Destroy()
    {
        isDead = true;
        _playerController.enabled = false;

        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].transform.position = meshTransforms[i].position;
            parts[i].transform.rotation = meshTransforms[i].rotation;            
            parts[i].SetActive(true);
            if (gamemodeRunning)
            {
                int rand1 = UnityEngine.Random.Range(100, 300);
                int rand2 = UnityEngine.Random.Range(100, 150);

                int rM = UnityEngine.Random.Range(0, 2);
                parts[i].GetComponent<Rigidbody>().AddForce(rand1 * parts[i].transform.up);
                if (rM == 0)
                    parts[i].GetComponent<Rigidbody>().AddForce(rand2 * parts[i].transform.right);
                else
                    parts[i].GetComponent<Rigidbody>().AddForce(-rand2 * parts[i].transform.right);
            }
        }
        playerObject.SetActive(false);
        if (gamemodeBicycle)
        {
            bicycleObject.SetActive(false);
        }

       endEnumerator = StartCoroutine(Wait());
    }
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        EndCorutine();
    }
    public void EndCorutine()
    {

        StartStartShow();
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].SetActive(false);
            parts[i].transform.position = meshTransforms[i].position;
            parts[i].transform.rotation = meshTransforms[i].rotation;
        }
        playerObject.SetActive(true);
        if (gamemodeBicycle)
        {
            bicycleObject.SetActive(true);
        }
        _playerController.enabled = true;
        transform.position = tp.position;
        isDead = false;
        if (endEnumerator != null)
        {
            StopCoroutine(endEnumerator);
            endEnumerator = null;
        }
        CanJump = true;
        deadAudioCount = 0;
    }
}