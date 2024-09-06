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
    public static Action<bool> GameEnds; 
    [SerializeField] private TimerScript _timerScript;
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
    public bool mustBreak;
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

        StartCoroutine(tpcor());
        IEnumerator tpcor()
        {
            yield return new WaitForFixedUpdate();
            transform.position = tp.position;
        }
    }
    private void Update()
    {
        if (mustBreak)
        {
            _vehicleControl.brake = true;
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
   
    public void ChangeDimondsText(bool bb)
    {
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Front"))
        {
            front = true;
            back = false;
            right = false;
            left = false;
        }
        if (other.CompareTag("Back"))
        {
            front = false;
            back = true;
            right = false;
            left = false;
        }
        if (other.CompareTag("Right"))
        {
            front = false;
            back = false;
            right = true;
            left = false;
        }
        if (other.CompareTag("Left"))
        {
            front = false;
            back = false;
            right = false;
            left = true;
        }
        if (other.CompareTag("Teleport"))
        {
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
        }

        if (other.CompareTag("TeleportPoint"))
        {
            if (gamemodeRunning)
            {
                coinMeshCounter++;
                coinMeshes[coinMeshCounter].enabled = false;
                teleportParticles[coinMeshCounter].SetActive(true);
            }
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
            Geekplay.Instance.PlayerData.Coins += 1;
            if (fillCount >= 100)
            {
                Geekplay.Instance.PlayerData.Coins += 100;
                GameEnds?.Invoke(true);
                _timerScript.StopTimer = true;
            }
            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] += 1;
            Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] += progressCountTest;
            Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] += fillAmountTest;
            Geekplay.Instance.Save();


            Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + " Checkpoint " + Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex]);


            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Teleport"))
        {
            transform.position = tp.position;
        }
    }   
}