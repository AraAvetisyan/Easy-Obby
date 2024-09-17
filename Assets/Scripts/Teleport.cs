using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{ 
    [SerializeField] private TimerScript _timerScript;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private Transform tp;
    [SerializeField] private Transform[] allTP;
    [SerializeField] private Image fillImage;
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
    [SerializeField] private MeshRenderer[] coinMeshes;
    [SerializeField] private MeshRenderer[] startLines;
    [SerializeField] private MeshRenderer[] flagMeshes, cloatMeshes;
    [SerializeField] private int coinMeshCounter;

    [SerializeField] private bool front, back, left, right;

    [SerializeField] private GameObject carObject;
    private Coroutine enumerator;
    public bool mustBrake;
    private void Start()
    {

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
        fillImage.fillAmount = fillAmount;
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
    }
    private void OnEnable()
    {
        Rewarder.ChangeDiamond += ChangeDimondsText;


    }
    private void OnDisable()
    {
        Rewarder.ChangeDiamond -= ChangeDimondsText;
        //HelicopterButton.StopBrake -= EndBrake;

    }
   
    public void ChangeDimondsText(bool bb)
    {
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
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
        if (other.CompareTag("Teleport"))
        {
            if (gamemodeRunning)
            {
                _playerController.IsFalling = false;
            }
            transform.position = tp.position;
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
            }
        }

        if (other.CompareTag("TeleportPoint"))
        {
            if (gamemodeBicycle)
            {
                coinMeshCounter++;
                flagMeshes[coinMeshCounter].enabled = false;
                cloatMeshes[coinMeshCounter].enabled = false;
                teleportParticles[coinMeshCounter].SetActive(true);
            }
            if (gamemodeCar)
            {
                coinMeshCounter++;
                startLines[coinMeshCounter].enabled = false;
                teleportParticles[coinMeshCounter].SetActive(true);
            }


            tp = other.gameObject.transform;

            fillCount += fillCountTest;
            fillImage.fillAmount += fillAmountTest;
            fillText.text = fillCount.ToString() + "%";
            if (fillCount >= 100)
            {
                Geekplay.Instance.PlayerData.Coins += 100;
                _timerScript.StopTimer();
                _timerScript.FinishTime();
            }
            Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] += 1;
            Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] += progressCountTest;
            Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] += fillAmountTest;
            Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = _timerScript.Minutes;
            Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = _timerScript.Seconds;
            Geekplay.Instance.Save();


            Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + "Checkpoint" + Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex]);


            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
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
        for(int i = 0; i < _vehicleControl.wheels.Length; i++)
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
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Teleport"))
        {
            transform.position = tp.position;
           
        }
    }   
}