using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
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
            fillAmount = Geekplay.Instance.PlayerData.RunningSaveProgress * 0.01f;
            fillCount = Geekplay.Instance.PlayerData.RunningSaveProgress;
            fillImage.fillAmount = fillAmount;
            fillText.text = fillCount.ToString() + "%";
            if (Geekplay.Instance.PlayerData.RunningSaveProgress < allTP.Length)
            {
                transform.position = allTP[Geekplay.Instance.PlayerData.RunningSaveProgress].position;
                tp = allTP[Geekplay.Instance.PlayerData.RunningSaveProgress];
            }
            else
            {
                transform.position = allTP[allTP.Length - 1].position;
                tp = allTP[allTP.Length - 1];
            }
            for(int i = 0; i < boxColliders.Length; i++)
            {
                if(i <= Geekplay.Instance.PlayerData.RunningSaveProgress)
                {
                    boxColliders[i].enabled = false;
                }
            }
        }
        if(gamemodeBicycle)
        {
            fillAmount = Geekplay.Instance.PlayerData.BikeSaveProgress * 0.01f;
            fillCount = Geekplay.Instance.PlayerData.BikeSaveProgress;
            fillImage.fillAmount = fillAmount;
            fillText.text = fillCount.ToString() + "%";
            if (Geekplay.Instance.PlayerData.BikeSaveProgress < allTP.Length)
            {
                transform.position = allTP[Geekplay.Instance.PlayerData.BikeSaveProgress].position;
                tp = allTP[Geekplay.Instance.PlayerData.BikeSaveProgress];
            }
            else
            {
                transform.position = allTP[allTP.Length - 1].position;
                tp = allTP[allTP.Length - 1];
            }
            for (int i = 0; i < boxColliders.Length; i++)
            {
                if (i <= Geekplay.Instance.PlayerData.BikeSaveProgress)
                {
                    boxColliders[i].enabled = false;
                }
            }
        }
        if (gamemodeCar)
        {
            fillAmount = Geekplay.Instance.PlayerData.CarSaveProgress * 0.01f;
            fillCount = Geekplay.Instance.PlayerData.CarSaveProgress;
            fillImage.fillAmount = fillAmount;
            fillText.text = fillCount.ToString() + "%";
            if (Geekplay.Instance.PlayerData.CarSaveProgress < allTP.Length)
            {
                transform.position = allTP[Geekplay.Instance.PlayerData.CarSaveProgress].position;
                tp = allTP[Geekplay.Instance.PlayerData.CarSaveProgress];
            }
            else
            {
                transform.position = allTP[allTP.Length - 1].position;
                tp = allTP[allTP.Length - 1];
            }
            for (int i = 0; i < boxColliders.Length; i++)
            {
                if (i <= Geekplay.Instance.PlayerData.CarSaveProgress)
                {
                    boxColliders[i].enabled = false;
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
            }

            coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
            Geekplay.Instance.Save();
            if (gamemodeRunning)
            {
                Geekplay.Instance.PlayerData.RunningSaveProgress += 1;
            }
            else
            {
                Geekplay.Instance.PlayerData.BikeSaveProgress += 1;
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
