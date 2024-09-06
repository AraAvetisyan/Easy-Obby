using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance;
    [SerializeField] private GameObject  shopPanel;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI diamondsText;
    public bool ContinueRun, ContinueBicycle, ContinueCar;
    [SerializeField] private GameObject runGamePanel, bicycleGamePanel, carGamePanel;


    [SerializeField] private GameObject runMenu, bicycleMenu, carMenu;



    [SerializeField] private TextMeshProUGUI[] bicycleTimerLevels;
    [SerializeField] private TextMeshProUGUI[] bicycleProgressPercentLevels;
    [SerializeField] private Image[] bicycleProgressLevels;

    [SerializeField] private TextMeshProUGUI[] runningTimerLevels;
    [SerializeField] private Image[] runningProgressLevels;
    [SerializeField] private TextMeshProUGUI[] runningProgressPercentLevels;


    [SerializeField] private TextMeshProUGUI[] carTimerLevels;
    [SerializeField] private Image[] carProgressLevels;
    [SerializeField] private TextMeshProUGUI[] carProgressPercentLevels;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
        StartCoroutine(WaitFrame());
    }
    public IEnumerator WaitFrame()
    {
        yield return new WaitForFixedUpdate();
        if (Geekplay.Instance.PlayerData.RunningSaveProgressLevels == null)
        {
            Geekplay.Instance.PlayerData.RunningSaveProgressLevels = new int[5];

        }
        if (Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevels == null)
        {
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevels = new int[5];

        }
        if (Geekplay.Instance.PlayerData.RunningFillAmountLevels == null)
        {
            Geekplay.Instance.PlayerData.RunningFillAmountLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevels = new float[5];

        }



        if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevels == null)
        {
            Geekplay.Instance.PlayerData.BicycleSaveProgressLevels = new int[5];

        }
        if (Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevels == null)
        {
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevels = new int[5];

        }
        if (Geekplay.Instance.PlayerData.BicycleFillAmountLevels == null)
        {
            Geekplay.Instance.PlayerData.BicycleFillAmountLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels = new float[5];

        }


        if (Geekplay.Instance.PlayerData.CarSaveProgressLevels == null)
        {
            Geekplay.Instance.PlayerData.CarSaveProgressLevels = new int[5];

        }
        if (Geekplay.Instance.PlayerData.CarSaveProgressMenuLevels == null)
        {
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevels = new int[5];

        }
        if (Geekplay.Instance.PlayerData.CarFillAmountLevels == null)
        {
            Geekplay.Instance.PlayerData.CarFillAmountLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.BestCarMapMinutesLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.BestCarMapSecondsLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels = new float[5];

        }
        if (Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels == null)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels = new float[5];

        }
        Geekplay.Instance.Save();
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


    public void PressedRunMenu()
    {
        runGamePanel.SetActive(true);
        for (int i = 0; i < Geekplay.Instance.PlayerData.RunningFillAmountLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevels[i] >= 100)
            {
                Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevels[i] = 100;
            }
            runningProgressLevels[i].fillAmount = Geekplay.Instance.PlayerData.RunningFillAmountLevels[i];
            runningProgressPercentLevels[i].text = Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevels[i].ToString() + "%";
        }

        var culture = new CultureInfo("en-EN");
        for (int i = 0; i < Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[i] < 10)
            {
                if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[i] < 10)
                {
                    runningTimerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[i].ToString("F2", culture);
                }
                else
                {
                    runningTimerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[i].ToString("F2", culture);
                }
            }
            if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] >= 10)
            {
                if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] < 10)
                {
                    runningTimerLevels[i].text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[i].ToString("F2", culture);
                }
                else
                {
                    runningTimerLevels[i].text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[i].ToString("F2", culture);
                }
            }
        }
    }
    public void PressedBicycleMenu()
    {       
        bicycleGamePanel.SetActive(true);
        for (int i = 0; i < Geekplay.Instance.PlayerData.BicycleFillAmountLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevels[i] >= 100)
            {
                Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevels[i] = 100;
            }
            bicycleProgressLevels[i].fillAmount = Geekplay.Instance.PlayerData.BicycleFillAmountLevels[i];
            bicycleProgressPercentLevels[i].text = Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevels[i].ToString() + "%";
        }
       
        var culture = new CultureInfo("en-EN");

        for (int i = 0; i < Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels.Length; i++) {
            if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[i] < 10)
            {
                if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[i] < 10)
                {
                    bicycleTimerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[i].ToString("F2", culture);
                }
                else
                {
                    bicycleTimerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[i].ToString("F2", culture);
                }
            }
            if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] >= 10)
            {
                if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] < 10)
                {
                    bicycleTimerLevels[i].text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[i].ToString("F2", culture);
                }
                else
                {
                    bicycleTimerLevels[i].text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[i].ToString("F2", culture);
                }
            } 
        }
       
    }
    public void PressedCarMenu()
    {
        carGamePanel.SetActive(true);
        for (int i = 0; i < Geekplay.Instance.PlayerData.CarFillAmountLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.CarSaveProgressMenuLevels[i] >= 100)
            {
                Geekplay.Instance.PlayerData.CarSaveProgressMenuLevels[i] = 100;
            }
            carProgressLevels[i].fillAmount = Geekplay.Instance.PlayerData.CarFillAmountLevels[i];
            carProgressPercentLevels[i].text = Geekplay.Instance.PlayerData.CarSaveProgressMenuLevels[i].ToString() + "%";
           
        }
      

        var culture = new CultureInfo("en-EN");

        for (int i = 0; i < Geekplay.Instance.PlayerData.BestCarMapMinutesLevels.Length; i++)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[i] < 10)
            {
                if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[i] < 10)
                {
                    carTimerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[i].ToString("F2", culture);
                }
                else
                {
                    carTimerLevels[i].text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[i].ToString("F2", culture);
                }
            }
            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] >= 10)
            {
                if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] < 10)
                {
                    carTimerLevels[i].text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[i].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[i].ToString("F2", culture);
                }
                else
                {
                    carTimerLevels[i].text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[i].ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[i].ToString("F2", culture);
                }
            }
        }

      
    }

    public void PressedShopMenu()
    {
        shopPanel.SetActive(true);
    }
    public void PressedBack()
    {
        runMenu.SetActive(false);
        runGamePanel.SetActive(false);
        bicycleMenu.SetActive(false);
        bicycleGamePanel.SetActive(false);
        carMenu.SetActive(false);
        carGamePanel.SetActive(false);
        shopPanel.SetActive(false);
    }


    public void PressedContinueRun()
    {
        ContinueRun = true; 
        Geekplay.Instance.PlayerData.IsFirstTry = 1;

        if (Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex] >= 100)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
            Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
            Geekplay.Instance.PlayerData.RunningFillAmountLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
        }
        Analytics.instance.SendEvent("SampleSceneRunning " + (Geekplay.Instance.PlayerData.RunningMapIndex + 1) + " Continue_Game");

        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneRunning " + (Geekplay.Instance.PlayerData.RunningMapIndex + 1));
      
    }   
    public void PressedContinueBicycle()
    {
        ContinueBicycle = true;
        Geekplay.Instance.PlayerData.IsFirstTry = 1;

        if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] >= 100)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
            Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
            Geekplay.Instance.PlayerData.BicycleFillAmountLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
        }
        Analytics.instance.SendEvent("SampleSceneBicycle " + (Geekplay.Instance.PlayerData.BicycleMapIndex + 1) + " Continue_Game");

        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneBicycle " + (Geekplay.Instance.PlayerData.BicycleMapIndex + 1));


        
    }
    public void PressedContinueCar()
    {
        ContinueCar = true;
        Geekplay.Instance.PlayerData.IsFirstTry = 1;

        if (Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex] >= 100)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
            Geekplay.Instance.PlayerData.CarFillAmountLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
        }
        Analytics.instance.SendEvent("SampleSceneCar " + (Geekplay.Instance.PlayerData.CarMapIndex + 1) + " Continue_Game");

        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneCar " + (Geekplay.Instance.PlayerData.CarMapIndex + 1));
       
    }

    public void PressedNewGameRun()
    {
        Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
        Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
        Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
        Geekplay.Instance.PlayerData.RunningFillAmountLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
        Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
        Geekplay.Instance.Save();
        Analytics.instance.SendEvent("SampleSceneRunning " + (Geekplay.Instance.PlayerData.RunningMapIndex + 1) + " Start_New_Game");
        SceneManager.LoadScene("SampleSceneRunning " + (Geekplay.Instance.PlayerData.RunningMapIndex + 1));

       
    }
    public void PressedNewGameBicycle()
    {
        Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
        Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
        Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
        Geekplay.Instance.PlayerData.BicycleFillAmountLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
        Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
        Geekplay.Instance.Save();
        Analytics.instance.SendEvent("SampleSceneBicycle " + (Geekplay.Instance.PlayerData.BicycleMapIndex+1) +  " Start_New_Game");
        SceneManager.LoadScene("SampleSceneBicycle " + (Geekplay.Instance.PlayerData.BicycleMapIndex + 1));

      
    }
    public void PressedNewGameCar()
    {
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
        Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
        Geekplay.Instance.PlayerData.CarSaveProgressMenuLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
        Geekplay.Instance.PlayerData.CarFillAmountLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
        Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
        Geekplay.Instance.Save();
        Analytics.instance.SendEvent("SampleSceneCar " + (Geekplay.Instance.PlayerData.CarMapIndex+1) +  " Start_New_Game");
        SceneManager.LoadScene("SampleSceneCar " + (Geekplay.Instance.PlayerData.CarMapIndex + 1));
       
    }
    public void RungGameMenu(int LevelIndex)
    {
        Geekplay.Instance.PlayerData.RunningMapIndex = LevelIndex;
        Geekplay.Instance.Save();
        runMenu.SetActive(true);
    }
    public void BicycleGameMenu(int LevelIndex)
    {
        Geekplay.Instance.PlayerData.BicycleMapIndex = LevelIndex;
        Geekplay.Instance.Save();
        bicycleMenu.SetActive(true);
    }
    public void CarGameMenu(int LevelIndex)
    {
        Geekplay.Instance.PlayerData.CarMapIndex = LevelIndex;
        Geekplay.Instance.Save();
        carMenu.SetActive(true);
    }
    //public void RunGameLevel1()
    //{        
    //    Geekplay.Instance.PlayerData.RunningMapIndex = 0;
    //    Geekplay.Instance.Save();
    //    runMenu.SetActive(true);
    //}
    //public void RunGameLevel2()
    //{
    //    Geekplay.Instance.PlayerData.RunningMapIndex = 1;
    //    Geekplay.Instance.Save();
    //    runMenu.SetActive(true);
    //}
    //public void RunGameLevel3()
    //{
    //    Geekplay.Instance.PlayerData.RunningMapIndex = 2;
    //    Geekplay.Instance.Save();
    //    runMenu.SetActive(true);
    //}
    //public void RunGameLevel4()
    //{
    //    Geekplay.Instance.PlayerData.RunningMapIndex = 3;
    //    Geekplay.Instance.Save();
    //    runMenu.SetActive(true);
    //}
    //public void RunGameLevel5()
    //{
    //    Geekplay.Instance.PlayerData.RunningMapIndex = 4;
    //    Geekplay.Instance.Save();
    //    runMenu.SetActive(true);
    //}


    //public void BicycleGameLevel1()
    //{
    //    Geekplay.Instance.PlayerData.BicycleMapIndex = 0;
    //    Geekplay.Instance.Save();
    //    bicycleMenu.SetActive(true);        
    //}
    //public void BicycleGameLevel2()
    //{
    //    Geekplay.Instance.PlayerData.BicycleMapIndex = 1;
    //    Geekplay.Instance.Save();
    //    bicycleMenu.SetActive(true);
    //}
    //public void BicycleGameLevel3()
    //{
    //    Geekplay.Instance.PlayerData.BicycleMapIndex = 2;
    //    Geekplay.Instance.Save();
    //    bicycleMenu.SetActive(true);
    //}
    //public void BicycleGameLevel4()
    //{
    //    Geekplay.Instance.PlayerData.BicycleMapIndex = 3;
    //    Geekplay.Instance.Save();
    //    bicycleMenu.SetActive(true);
    //}
    //public void BicycleGameLevel5()
    //{
    //    Geekplay.Instance.PlayerData.BicycleMapIndex = 4;
    //    Geekplay.Instance.Save();
    //    bicycleMenu.SetActive(true);
    //}


    //public void CarGameLevel1()
    //{
    //    Geekplay.Instance.PlayerData.CarMapIndex = 0;
    //    Geekplay.Instance.Save();
    //    carMenu.SetActive(true);
    //}
    //public void CarGameLevel2()
    //{
    //    Geekplay.Instance.PlayerData.CarMapIndex = 1;
    //    Geekplay.Instance.Save();
    //    carMenu.SetActive(true);
    //}
    //public void CarGameLevel3()
    //{
    //    Geekplay.Instance.PlayerData.CarMapIndex = 2;
    //    Geekplay.Instance.Save();
    //    carMenu.SetActive(true);
    //}
    //public void CarGameLevel4()
    //{
    //    Geekplay.Instance.PlayerData.CarMapIndex = 3;
    //    Geekplay.Instance.Save();
    //    carMenu.SetActive(true);
    //}
    //public void CarGameLevel5()
    //{
    //    Geekplay.Instance.PlayerData.CarMapIndex = 4;
    //    Geekplay.Instance.Save();
    //    carMenu.SetActive(true);
    //}
    //public void CarLevelTest()
    //{
    //    SceneManager.LoadScene("SampleSceneCar Test");
    //}

    //public void Reset()
    //{
    //    PlayerPrefs.DeleteAll();
    //}
}
