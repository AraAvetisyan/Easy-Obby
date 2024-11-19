using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    public bool NewGame;
    public bool ContinueGame;
    public static MainMenuUI Instance;
    [SerializeField] private GameObject inappShopPanel;
    [SerializeField] private GameObject inappButtonObject;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI diamondsText;
    public bool Continue;
    [SerializeField] private GameObject runMenu, bicycleMenu, carMenu;
    [SerializeField] private GameObject runPanel, bicyclePanel, carPanel;
    [SerializeField] private TextMeshProUGUI[] timerLevels;
    //[SerializeField] private Image[] progressLevels;
    [SerializeField] private UnityEngine.UI.Slider[] progressLevels;
    [SerializeField] private GameObject[] progressLevelsObjects;
    [SerializeField] private TextMeshProUGUI[] progressPercentLevels;
    [SerializeField] private AudioSource uiAudio;
    [SerializeField] private TextMeshProUGUI runPercent, bicyclePercet, carPercent;
    private int runPercentCount, bicyclePercentCount, carPercentCount;
    [SerializeField] private GameObject runContinue, bicycleContinue, carContinue;

    [Header("ShowAd")]
    [SerializeField] private AudioSource music;

    [Header("SkinShop")]
    [SerializeField] private GameObject skinShop;
    [SerializeField] private GameObject runButton, bicycleButton, carButton;
    [SerializeField] private GameObject shopButton;
    [SerializeField] private UnityEngine.UI.Image canvasPanel;
    [SerializeField] private SkinShop _skinShop;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Geekplay.Instance.GameStart();
        Geekplay.Instance.GameStop();
        Geekplay.Instance.ShowInterstitialAd();
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
        Geekplay.Instance.PlayerData.IsMenu = true;
        StartCoroutine(WaitFrame());
    }
    public IEnumerator WaitFrame()
    {
        yield return new WaitForFixedUpdate();
      
        if (Geekplay.Instance.PlayerData.SaveProgressLevels == null)
        {
            Geekplay.Instance.PlayerData.SaveProgressLevels = new int[15];
        }
        if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels == null)
        {
            Geekplay.Instance.PlayerData.SaveProgressMenuLevels = new int[15];
        }
        if (Geekplay.Instance.PlayerData.FillAmountLevels == null)
        {
            Geekplay.Instance.PlayerData.FillAmountLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.BestMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.BestMapMinutesLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.BestMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.BestMapSecondsLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.BestMapMilisecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.BestMapMilisecondsLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.CurrentMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentMapMinutesLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.CurrentMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentMapSecondsLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels = new float[15];
        }
        if (Geekplay.Instance.PlayerData.Rotation == null)
        {
            Geekplay.Instance.PlayerData.Rotation = new int[15];
        }
        if (Geekplay.Instance.PlayerData.IsContinue == null)
        {
            Geekplay.Instance.PlayerData.IsContinue = new bool[15];
        }

        if (Geekplay.Instance.PlayerData.HeadBoght == null)
        {
            Geekplay.Instance.PlayerData.HeadBoght = new bool[24];

            Geekplay.Instance.PlayerData.HeadBoght[0] = true;
        }
        if (Geekplay.Instance.PlayerData.BodyBoght == null)
        {
            Geekplay.Instance.PlayerData.BodyBoght = new bool[24]
                ;
            Geekplay.Instance.PlayerData.BodyBoght[3] = true;
        }
        if (Geekplay.Instance.PlayerData.LegBoght == null)
        {
            Geekplay.Instance.PlayerData.LegBoght = new bool[24]
                ;
            Geekplay.Instance.PlayerData.LegBoght[4] = true;
        }
        if (Geekplay.Instance.PlayerData.FootBoght == null)
        {
            Geekplay.Instance.PlayerData.FootBoght = new bool[24];

            Geekplay.Instance.PlayerData.FootBoght[9] = true;
        }
        if (Geekplay.Instance.PlayerData.CapBoght == null)
        {
            Geekplay.Instance.PlayerData.CapBoght = new bool[24];

            Geekplay.Instance.PlayerData.CapBoght[0] = true;
        }
        if (Geekplay.Instance.PlayerData.AccessoryBoght == null)
        {
            Geekplay.Instance.PlayerData.AccessoryBoght = new bool[11];

            Geekplay.Instance.PlayerData.AccessoryBoght[0] = true;
        }
        if (Geekplay.Instance.PlayerData.FaceBoght == null)
        {
            Geekplay.Instance.PlayerData.FaceBoght = new bool[24];

            Geekplay.Instance.PlayerData.FaceBoght[0] = true;
        }
        if (Geekplay.Instance.PlayerData.HeadEquiped == null)
        {
            Geekplay.Instance.PlayerData.HeadEquiped = new bool[24];

            Geekplay.Instance.PlayerData.HeadEquiped[0] = true;
        }
        if (Geekplay.Instance.PlayerData.BodyEquiped == null)
        {
            Geekplay.Instance.PlayerData.BodyEquiped = new bool[24];

            Geekplay.Instance.PlayerData.BodyEquiped[3] = true;
        }
        if (Geekplay.Instance.PlayerData.LegEquiped == null)
        {
            Geekplay.Instance.PlayerData.LegEquiped = new bool[24];

            Geekplay.Instance.PlayerData.LegEquiped[4] = true;
        }
        if (Geekplay.Instance.PlayerData.FootEquiped == null)
        {
            Geekplay.Instance.PlayerData.FootEquiped = new bool[24];

            Geekplay.Instance.PlayerData.FootEquiped[9] = true;
        }
        if(Geekplay.Instance.PlayerData.LeaderboardTimer == null)
        {
            Geekplay.Instance.PlayerData.LeaderboardTimer = new float[15];
        }
        if (Geekplay.Instance.PlayerData.CapEquiped == null)
        {
            Geekplay.Instance.PlayerData.CapEquiped = new bool[24];

            Geekplay.Instance.PlayerData.CapEquiped[0] = true;
        }
        if (Geekplay.Instance.PlayerData.AccessoryEquiped == null)
        {
            Geekplay.Instance.PlayerData.AccessoryEquiped = new bool[24];

            Geekplay.Instance.PlayerData.AccessoryEquiped[0] = true;
        }
        if (Geekplay.Instance.PlayerData.FaceEquiped == null)
        {
            Geekplay.Instance.PlayerData.FaceEquiped = new bool[24];

            Geekplay.Instance.PlayerData.FaceEquiped[0] = true;
        }

        for (int i = 0; i < progressLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressLevels[i] == 0)
            {
                progressLevelsObjects[i].gameObject.SetActive(false);
            }
        }
        Geekplay.Instance.Save();
        for (int i = 0; i < Geekplay.Instance.PlayerData.SaveProgressMenuLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i] > 100)
            {
                Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i] = 100;
            }
            if (i >= 0 && i < 5)
            {
                runPercentCount += Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i];
            }
            if (i >= 5 && i < 10)
            {
                bicyclePercentCount += Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i];
            }
            if (i >= 10 && i < 15)
            {
                carPercentCount += Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i];
            }
        }
        runPercent.text = runPercentCount.ToString() + "/200%";
        bicyclePercet.text = bicyclePercentCount.ToString() + "/200%";
        carPercent.text = carPercentCount.ToString() + "/200%";
    }
    private void OnEnable()
    {
        Rewarder.ChangeDiamond += ChangeDimondsText;
        Rewarder.ChangeCoin += ChangeDimondsText;
    }
    private void OnDisable()
    {
        Rewarder.ChangeDiamond -= ChangeDimondsText;
        Rewarder.ChangeCoin -= ChangeDimondsText;

    }
    public void ChangeDimondsText(bool bb)
    {
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
    }
    public void PressedMenu(GameObject panel)
    {
        uiAudio.Play();
        panel.SetActive(true);
        if (AdsTimerScript.Instance.CanShow)
        {
            StartShowAdCoroutine();            
        }

        for (int i = 0; i < Geekplay.Instance.PlayerData.FillAmountLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i] >= 100)
            {
                Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i] = 100;
            }
            progressLevels[i].value = Geekplay.Instance.PlayerData.FillAmountLevels[i];
            progressPercentLevels[i].text = Geekplay.Instance.PlayerData.SaveProgressMenuLevels[i].ToString() + "%";
        }

        var culture = new CultureInfo("en-EN");

        for (int i = 0; i < Geekplay.Instance.PlayerData.BestMapMinutesLevels.Length; i++)
        {
            timerLevels[i].text = string.Format("{0:00}:{1:00}:{2:00}", Geekplay.Instance.PlayerData.BestMapMinutesLevels[i], Geekplay.Instance.PlayerData.BestMapSecondsLevels[i], Geekplay.Instance.PlayerData.BestMapMilisecondsLevels[i]);
            //if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[i] < 10)
            //{
            //    if (Geekplay.Instance.PlayerData.BestMapSecondsLevels[i] < 10)
            //    {
            //        timerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestMapSecondsLevels[i].ToString("F2", culture);
            //    }
            //    else
            //    {
            //        timerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestMapSecondsLevels[i].ToString("F2", culture);
            //    }
            //}
            //if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] >= 10)
            //{
            //    if (Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] < 10)
            //    {
            //        timerLevels[i].text = Geekplay.Instance.PlayerData.BestMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestMapSecondsLevels[i].ToString("F2", culture);
            //    }
            //    else
            //    {
            //        timerLevels[i].text = Geekplay.Instance.PlayerData.BestMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestMapSecondsLevels[i].ToString("F2", culture);
            //    }
            //}
        }
    }

    public void PressedShopMenu()
    {
        if (AdsTimerScript.Instance.CanShow)
        {
            StartShowAdCoroutine();
        }
        uiAudio.Play();
        inappShopPanel.SetActive(true);
    }
    public void PressedBack()
    {
        if (AdsTimerScript.Instance.CanShow)
        {
            StartShowAdCoroutine();
        }
        uiAudio.Play();
        runMenu.SetActive(false);
        bicycleMenu.SetActive(false);
        carMenu.SetActive(false);
        inappShopPanel.SetActive(false);
        runPanel.SetActive(false);
        bicyclePanel.SetActive(false);
        carPanel.SetActive(false);
    }

    public void PressedContinue()
    {
      
        uiAudio.Play();
        Continue = true;
        Geekplay.Instance.PlayerData.IsContinue[Geekplay.Instance.PlayerData.MapIndex] = true;

        if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] >= 100)
        {
            Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
            Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] = 0;
        }
        ContinueGame = true;
        StartCoroutine(LoadScene());
    }
    public void PressedNewGame()
    {
        uiAudio.Play();
        Continue = false;
        Geekplay.Instance.PlayerData.IsContinue[Geekplay.Instance.PlayerData.MapIndex] = false;
        Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.PlayerData.LeaderboardTimer[Geekplay.Instance.PlayerData.MapIndex] = 0;
        Geekplay.Instance.Save();
        NewGame = true;
        StartCoroutine(LoadScene());

    }
    public void GameMenu(int LevelIndex)
    {
        if (AdsTimerScript.Instance.CanShow)
        {
            StartShowAdCoroutine();
        }
        uiAudio.Play();
        Geekplay.Instance.PlayerData.MapIndex = LevelIndex;
        Geekplay.Instance.Save();
        if (LevelIndex >= 0 && LevelIndex <= 4)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[LevelIndex] <= 0)
            {
                runContinue.SetActive(false);
            }
            else if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[LevelIndex] >= 100)
            {
                runContinue.SetActive(false);
            }
            else
            {
                runContinue.SetActive(true);
            }
            runMenu.SetActive(true);

        }
        else if (LevelIndex >= 5 && LevelIndex <= 9)
        {
            if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[LevelIndex] <= 0)
            {
                bicycleContinue.SetActive(false);
            }
            else if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[LevelIndex] >= 100)
            {
                bicycleContinue.SetActive(false);
            }
            else
            {
                bicycleContinue.SetActive(true);
            }
            bicycleMenu.SetActive(true);
        }
        else
        {
            if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[LevelIndex] <= 0)
            {
                carContinue.SetActive(false);
            }
            else if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[LevelIndex] >= 100)
            {
                carContinue.SetActive(false);
            }
            else
            {
                carContinue.SetActive(true);
            }
            carMenu.SetActive(true);
        }

    }
    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(Geekplay.Instance.PlayerData.MapIndex + 1);
    }



    public void StartShowAdCoroutine()
    {
        if (AdsTimerScript.Instance.CanShow)
        {
            ShowAd();
        }
    }



    public void ShowAd()
    {
        Geekplay.Instance.GameStoped = false;
        Geekplay.Instance.ShowInterstitialAd();

        music.volume = 0.35f;
        music.Play();
        Geekplay.Instance.PlayerData.Coins += 50;
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
        Geekplay.Instance.Save();
        AdsTimerScript.Instance.StopMinutesCoroutine();
    }

    public void PressedSkinShop()
    {
        if (AdsTimerScript.Instance.CanShow)
        {
            StartShowAdCoroutine();
        }
        skinShop.SetActive(true);
        inappButtonObject.SetActive(false);
        runButton.SetActive(false);
        bicycleButton.SetActive(false);
        carButton.SetActive(false);
        shopButton.SetActive(false);
        canvasPanel.enabled = false;
        _skinShop.StartShop();
        _skinShop.PutOnItems();
    }

    public void PressedSkinSopBack()
    {
        if (AdsTimerScript.Instance.CanShow)
        {
            StartShowAdCoroutine();
        }
        skinShop.SetActive(false);
        runButton.SetActive(true);
        bicycleButton.SetActive(true);
        inappButtonObject.SetActive(true);
        carButton.SetActive(true);
        shopButton.SetActive(true);
        canvasPanel.enabled = true;
    }
}
