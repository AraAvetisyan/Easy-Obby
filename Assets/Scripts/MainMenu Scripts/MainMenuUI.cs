using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject runMenu, bicycleMenu, carPanel, shopPanel;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI diamondsText;

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
