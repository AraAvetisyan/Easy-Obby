using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform tp;
    [SerializeField] private Transform[] allTP;
    [SerializeField] private Image fillImage;
    [SerializeField] private int fillCount;
    [SerializeField] private TextMeshProUGUI fillText;
    [SerializeField] private bool gamemodeRunning;
    [SerializeField] private BoxCollider[] boxColliders;
    float fillAmount;
    private void Start()
    {

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
        else
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
