using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContoller : MonoBehaviour
{
    [SerializeField] private bool isRunningMode, isBicycleMode, isCarMode;
    [SerializeField] private TimerScript _timerScript;
    int nextCount;
    public void PressedHome()
    {
        if(isRunningMode)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = _timerScript.Minutes;
            Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = _timerScript.Seconds;
            Analytics.instance.SendEvent("SampleSceneRunning " + (Geekplay.Instance.PlayerData.RunningMapIndex + 1) + " Exit Level");
            Geekplay.Instance.Save();
        }
        if (isBicycleMode)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = _timerScript.Minutes;
            Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = _timerScript.Seconds;
            Analytics.instance.SendEvent("SampleSceneBicycle "+ (Geekplay.Instance.PlayerData.BicycleMapIndex + 1)+ " Exit Level");
            Geekplay.Instance.Save();
        }
        if (isCarMode)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] = _timerScript.Minutes;
            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] = _timerScript.Seconds;
            Analytics.instance.SendEvent("SampleSceneCar " + (Geekplay.Instance.PlayerData.CarMapIndex + 1) + " Exit Level");
            Geekplay.Instance.Save();
        }
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedHomeFinal()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedNext()
    {
        if (isRunningMode)
        {
            if (nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex += 1;
                if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
                {
                    Geekplay.Instance.PlayerData.RunningMapIndex = 0;
                }
                if (Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex] >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
                    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning " + (Geekplay.Instance.PlayerData.RunningMapIndex + 1));

            }           
        }
        if (isBicycleMode)
        {
            if(nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex += 1;
                if(Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
                {
                    Geekplay.Instance.PlayerData.BicycleMapIndex = 0;
                }
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
                    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle " + (Geekplay.Instance.PlayerData.BicycleMapIndex + 1));

            }
           
        }
        if (isCarMode)
        {
            if (nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex += 1;
                if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
                {
                    Geekplay.Instance.PlayerData.CarMapIndex = 0;
                }
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex] >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
                    Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
                    Geekplay.Instance.PlayerData.CarFillAmountLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
                    Geekplay.Instance.PlayerData.CarSaveProgressLevels[Geekplay.Instance.PlayerData.CarMapIndex] = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar " + (Geekplay.Instance.PlayerData.CarMapIndex + 1));

            }
           
        }
    }
}
