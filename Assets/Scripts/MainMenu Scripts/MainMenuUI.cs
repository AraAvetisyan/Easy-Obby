using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public static MainMenuUI Instance;
    [SerializeField] private GameObject runMenu, bicycleMenu, carPanel, shopPanel;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI diamondsText;
    public bool ContinueRun, ContinueBicycle, ContinueCar;
    [SerializeField] private GameObject runNewGamePanel, bicycleNewGamePanel, carPanelNewGamePanel;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();
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
        runMenu.SetActive(true);
    }
    public void PressedBicycleMenu()
    {
        bicycleMenu.SetActive(true);
    }
    public void PressedCarMenu()
    {
        carPanel.SetActive(true);
    }
    public void PressedShopMenu()
    {
        shopPanel.SetActive(true);
    }
    public void PressedBack()
    {
        runMenu.SetActive(false);
        bicycleMenu.SetActive(false);
        carPanel.SetActive(false);
        shopPanel.SetActive(false);
        runNewGamePanel.SetActive(false);
        bicycleNewGamePanel.SetActive(false);
        carPanel.SetActive(false);
    }
    public void PressedContinueRun()
    {
        ContinueRun = true;
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.Save();
        if(Geekplay.Instance.PlayerData.RunningMapIndex == 1)
        {
            SceneManager.LoadScene("SampleSceneRunning 1");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
        {
            SceneManager.LoadScene("SampleSceneRunning 2");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
        {
            SceneManager.LoadScene("SampleSceneRunning 3");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
        {
            SceneManager.LoadScene("SampleSceneRunning 4");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
        {
            SceneManager.LoadScene("SampleSceneRunning 5");
        }
    }
   
    public void PressedContinueBicycle()
    {
        ContinueBicycle = true;
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.Save();
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
        {
            SceneManager.LoadScene("SampleSceneBicycle 1");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
        {
            SceneManager.LoadScene("SampleSceneBicycle 2");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
        {
            SceneManager.LoadScene("SampleSceneBicycle 3");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
        {
            SceneManager.LoadScene("SampleSceneBicycle 4");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
        {
            SceneManager.LoadScene("SampleSceneBicycle 5");
        }
        //ContinueBicycle = true;
        //Geekplay.Instance.PlayerData.IsFirstTry = 1;
        //Geekplay.Instance.Save();
        //SceneManager.LoadScene("SampleSceneBicycle");
    }
    public void PressedContinueCar()
    {
        ContinueCar = true;
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.Save();
        if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
        {
            SceneManager.LoadScene("SampleSceneCar 1");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
        {
            SceneManager.LoadScene("SampleSceneCar 2");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
        {
            SceneManager.LoadScene("SampleSceneCar 3");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
        {
            SceneManager.LoadScene("SampleSceneCar 4");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
        {
            SceneManager.LoadScene("SampleSceneCar 5");
        }
        //ContinueCar = true;
        //Geekplay.Instance.PlayerData.IsFirstTry = 1;
        //Geekplay.Instance.Save();
        //SceneManager.LoadScene("SampleSceneCar");
    }
    public void PressedNewGameRun()
    {
        runNewGamePanel.SetActive(true);       
    }
    public void PressedNewGameBicycle()
    {
        bicycleNewGamePanel.SetActive(true);
    }
    public void PressedNewGameCar()
    {
        carPanelNewGamePanel.SetActive(true);
    }

    public void NewGameRunLevel1()
    {
        Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 = 0;
        Geekplay.Instance.PlayerData.RunningMapIndex = 1;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneRunning 1");
    }
    public void NewGameRunLevel2()
    {
        Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 = 0;
        Geekplay.Instance.PlayerData.RunningMapIndex = 2;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneRunning 2");
    }
    public void NewGameRunLevel3()
    {
        Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 = 0;
        Geekplay.Instance.PlayerData.RunningMapIndex = 3;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneRunning 3");
    }
    public void NewGameRunLevel4()
    {
        Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 = 0;
        Geekplay.Instance.PlayerData.RunningMapIndex = 4;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneRunning 4");
    }
    public void NewGameRunLevel5()
    {
        Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 = 0;
        Geekplay.Instance.PlayerData.RunningMapIndex = 5;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneRunning 5");
    }


    public void NewGameBicycleLevel1()
    {
        Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 = 0;
        Geekplay.Instance.PlayerData.BicycleMapIndex = 1;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneBicycle 1");
    }
    public void NewGameBicycleLevel2()
    {
        Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 = 0;
        Geekplay.Instance.PlayerData.BicycleMapIndex = 2;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneBicycle 2");
    }
    public void NewGameBicycleLevel3()
    {
        Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 = 0;
        Geekplay.Instance.PlayerData.BicycleMapIndex = 3;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneBicycle 3");
    }
    public void NewGameBicycleLevel4()
    {
        Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 = 0;
        Geekplay.Instance.PlayerData.BicycleMapIndex = 4;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneBicycle 4");
    }
    public void NewGameBicycleLevel5()
    {
        Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 = 0;
        Geekplay.Instance.PlayerData.BicycleMapIndex = 5;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneBicycle 5");
    }


    public void NewGameCarLevel1()
    {
        Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.CarSaveProgressLevel1 = 0;
        Geekplay.Instance.PlayerData.CarMapIndex = 1;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneCar 1");
    }
    public void NewGameCarLevel2()
    {
        Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.CarSaveProgressLevel2 = 0;
        Geekplay.Instance.PlayerData.CarMapIndex = 2;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneCar 2");
    }
    public void NewGameCarLevel3()
    {
        Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.CarSaveProgressLevel3 = 0;
        Geekplay.Instance.PlayerData.CarMapIndex = 3;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneCar 3");
    }
    public void NewGameCarLevel4()
    {
        Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.CarSaveProgressLevel4 = 0;
        Geekplay.Instance.PlayerData.CarMapIndex = 4;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneCar 4");
    }
    public void NewGameCarLevel5()
    {
        Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = 0;
        Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = 0;
        Geekplay.Instance.PlayerData.CarSaveProgressLevel5 = 0;
        Geekplay.Instance.PlayerData.CarMapIndex = 5;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneCar 5");
    }
    public void CarLevelTest()
    {
        SceneManager.LoadScene("SampleSceneCar Test");
    }
}
