using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
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



        if (gamemodeRunning)
        {
            fillAmount = Geekplay.Instance.PlayerData.RunningFillAmountLevels[Geekplay.Instance.PlayerData.RunningMapIndex];
            fillCount = Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevels[Geekplay.Instance.PlayerData.RunningMapIndex];
            coinMeshCounter = Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex];
            fillImage.fillAmount = fillAmount;
            fillText.text = fillCount.ToString() + "%";
            if (Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex] < allTP.Length)
            {
                tp = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex]];
            }
            else
            {
                tp = allTP[allTP.Length - 1];
            }
            for (int i = 0; i < boxColliders.Length; i++)
            {
                if (i <= Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex])
                {
                    boxColliders[i].enabled = false;
                    coinMeshes[i].enabled = false;
                }
            }
            transform.position = tp.position;
           
        }


        if(gamemodeBicycle)
        {
            fillAmount = Geekplay.Instance.PlayerData.BicycleFillAmountLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
            fillCount = Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
            coinMeshCounter = Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
            fillImage.fillAmount = fillAmount;
            fillText.text = fillCount.ToString() + "%";
            if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] < allTP.Length)
            {
                tp = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex]];
            }
            else
            {
                tp = allTP[allTP.Length - 1];
            }
            for (int i = 0; i < boxColliders.Length; i++)
            {
                if (i <= Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex])
                {
                    boxColliders[i].enabled = false;
                    flagMeshes[i].enabled = false;
                    cloatMeshes[i].enabled = false;
                }
            }
            transform.position = tp.position;


           
        }
        if (gamemodeCar)
        {
            fillAmount = Geekplay.Instance.PlayerData.CarFillAmountLevels[Geekplay.Instance.PlayerData.CarMapIndex];
            fillCount = Geekplay.Instance.PlayerData.CarSaveProgressMenuLevels[Geekplay.Instance.PlayerData.CarMapIndex];
            coinMeshCounter = Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex];
            fillImage.fillAmount = fillAmount;
            fillText.text = fillCount.ToString() + "%";
            if (Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex] < allTP.Length)
            {
                tp = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex]];
            }
            else
            {
                tp = allTP[allTP.Length - 1];
            }
            for (int i = 0; i < boxColliders.Length; i++)
            {
                if (i <= Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex])
                {
                    boxColliders[i].enabled = false;
                    startLines[i].enabled = false;
                }
            }
            transform.position = tp.position;
           
        }

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
            if(fillCount >= 100)
            {
                Geekplay.Instance.PlayerData.Coins += 100;
                _timerScript.StopTimer = true;
            }

            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            Geekplay.Instance.Save();
            if (gamemodeRunning)
            {
                Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex] += 1;
                Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevels[Geekplay.Instance.PlayerData.RunningMapIndex] += progressCountTest;
                Geekplay.Instance.PlayerData.RunningFillAmountLevels[Geekplay.Instance.PlayerData.RunningMapIndex] += fillAmountTest;
                Geekplay.Instance.Save();

                Analytics.instance.SendEvent("Reach SampleSceneRunning " + (Geekplay.Instance.PlayerData.RunningMapIndex + 1) + " Checkpoint " + Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex]);
               
            }
            if(gamemodeBicycle)
            {
                Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] += 1;
                Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] += progressCountTest;
                Geekplay.Instance.PlayerData.BicycleFillAmountLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] += fillAmountTest;
                Geekplay.Instance.Save();

                Analytics.instance.SendEvent("Reach SampleSceneBicycle " + (Geekplay.Instance.PlayerData.BicycleMapIndex + 1) + " Checkpoint " + Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex]);

            }
            if (gamemodeCar)
            {
                Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex] += 1;
                Geekplay.Instance.PlayerData.CarSaveProgressMenuLevels[Geekplay.Instance.PlayerData.CarMapIndex] += progressCountTest;
                Geekplay.Instance.PlayerData.CarFillAmountLevels[Geekplay.Instance.PlayerData.CarMapIndex] += fillAmountTest;
                Geekplay.Instance.Save();

                Analytics.instance.SendEvent("Reach SampleSceneCar " + (Geekplay.Instance.PlayerData.CarMapIndex + 1) + " Checkpoint " + Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex]);
              
            }
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
