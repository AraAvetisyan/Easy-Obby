using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    private void Start()
    {
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
        


        if (gamemodeRunning)
        {
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 1)
            {
                fillAmount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel1;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel1].position;
                    tp = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel1];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.RunningSaveProgressLevel1)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
            {
                fillAmount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel2;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel2].position;
                    tp = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel2];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    Debug.Log("Stexa qaqy");
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.RunningSaveProgressLevel2)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
            {
                fillAmount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel3;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel3].position;
                    tp = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel3];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.RunningSaveProgressLevel3)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
            {
                fillAmount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel4;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel4].position;
                    tp = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel4];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.RunningSaveProgressLevel4)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
            {
                fillAmount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.RunningSaveProgressLevel5;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel5].position;
                    tp = allTP[Geekplay.Instance.PlayerData.RunningSaveProgressLevel5];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.RunningSaveProgressLevel5)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }
        }


        if(gamemodeBicycle)
        {
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
            {
                fillAmount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1].position;
                    tp = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
            {
                fillAmount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2].position;
                    tp = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
            {
                fillAmount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3].position;
                    tp = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
            {
                fillAmount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4].position;
                    tp = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
            {
                fillAmount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5].position;
                    tp = allTP[Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }
        }
        if (gamemodeCar)
        {
            if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
            {
                fillAmount = Geekplay.Instance.PlayerData.CarSaveProgressLevel1 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.CarSaveProgressLevel1;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel1 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel1].position;
                    tp = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel1];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.CarSaveProgressLevel1)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
            {
                fillAmount = Geekplay.Instance.PlayerData.CarSaveProgressLevel2 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.CarSaveProgressLevel2;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel2 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel2].position;
                    tp = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel2];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.CarSaveProgressLevel2)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
            {
                fillAmount = Geekplay.Instance.PlayerData.CarSaveProgressLevel3 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.CarSaveProgressLevel3;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel3 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel3].position;
                    tp = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel3];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.CarSaveProgressLevel3)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
            {
                fillAmount = Geekplay.Instance.PlayerData.CarSaveProgressLevel4 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.CarSaveProgressLevel4;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel4 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel4].position;
                    tp = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel4];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.CarSaveProgressLevel4)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
            }

            if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
            {
                fillAmount = Geekplay.Instance.PlayerData.CarSaveProgressLevel5 * 0.01f;
                fillCount = Geekplay.Instance.PlayerData.CarSaveProgressLevel5;
                fillImage.fillAmount = fillAmount;
                fillText.text = fillCount.ToString() + "%";
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel5 < allTP.Length)
                {
                    transform.position = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel5].position;
                    tp = allTP[Geekplay.Instance.PlayerData.CarSaveProgressLevel5];
                }
                else
                {
                    transform.position = allTP[allTP.Length - 1].position;
                    tp = allTP[allTP.Length - 1];
                }
                for (int i = 0; i < boxColliders.Length; i++)
                {
                    if (i <= Geekplay.Instance.PlayerData.CarSaveProgressLevel5)
                    {
                        boxColliders[i].enabled = false;
                    }
                }
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
   
    public void ChangeDimondsText(bool bb)
    {
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Teleport"))
        {
            transform.position = tp.position;
        }

        if (other.CompareTag("TeleportPoint"))
        {
            tp = other.gameObject.transform;
            fillCount += 1;
            fillImage.fillAmount += 0.01f;
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
                if (Geekplay.Instance.PlayerData.RunningMapIndex == 1)
                {
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 += 1;
                }
                if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
                {
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 += 1;
                }
                if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
                {
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 += 1;
                }
                if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
                {
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 += 1;
                }
                if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
                {
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 += 1;
                }
            }
            if(gamemodeBicycle)
            {
                if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
                {
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 += 1;
                }
                if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
                {
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 += 1;
                }
                if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
                {
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 += 1;
                }
                if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
                {
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 += 1;
                }
                if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
                {
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 += 1;
                }
            }
            if (gamemodeCar)
            {
                if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
                {
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel1 += 1;
                }
                if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
                {
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel2 += 1;
                }
                if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
                {
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel3 += 1;
                }
                if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
                {
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel4 += 1;
                }
                if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
                {
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel5 += 1;
                }
            }
            Geekplay.Instance.Save();
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
