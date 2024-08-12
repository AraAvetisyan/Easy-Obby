using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject runMenu, bicycleMenu, carPanel;



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
    public void PressedBack()
    {
        runMenu.SetActive(false);
        bicycleMenu.SetActive(false);
    }
    public void PressedContinueRun()
    {
        SceneManager.LoadScene("SampleSceneRunning");
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.Save();
    }
   
    public void PressedContinueBicycle() 
    {
        SceneManager.LoadScene("SampleSceneBicycle");
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.Save();
    }
    public void PressedContinueCar()
    {
        SceneManager.LoadScene("SampleSceneCar");
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.Save();
    }
    public void PressedNewGameRun()
    {
        Geekplay.Instance.PlayerData.RunningSaveProgress = 0;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneRunning");
    }

    public void PressedNewGameBicycle()
    {
        Geekplay.Instance.PlayerData.BikeSaveProgress = 0;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneBicycle");
    }
    public void PressedNewGameCar()
    {
        Geekplay.Instance.PlayerData.CarSaveProgress = 0;
        Geekplay.Instance.Save();
        SceneManager.LoadScene("SampleSceneBicycle");
    }

}
