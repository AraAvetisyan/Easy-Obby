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
        SceneManager.LoadScene("MainMenu");
        if(isRunningMode)
        {
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 1)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel2 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel2 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel3 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel3 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel4 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel4 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel5 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel5 = _timerScript.Seconds;
            }
            Geekplay.Instance.Save();
        }
        if (isBicycleMode)
        {
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel2 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel2 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel3 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel3 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel4 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel4 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel5 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel5 = _timerScript.Seconds;
            }
            Geekplay.Instance.Save();
        }
        if (isCarMode)
        {
            if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel2 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel2 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel3 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel3 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel4 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel4 = _timerScript.Seconds;
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel5 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel5 = _timerScript.Seconds;
            }
            Geekplay.Instance.Save();
        }
    }
    public void PressedHomeFinal()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedNext()
    {
        if (isRunningMode)
        {
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 1 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 2;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 2");

            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 2 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 3;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 3");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 3 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 4;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 4");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 4 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 5;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 5");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 5 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 1;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 1");
            }
        }
        if (isBicycleMode)
        {
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 2;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 2");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 3;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 3");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 4;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 4");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 5;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 5");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 1;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 1");
            }
        }
        if (isCarMode)
        {
            if (Geekplay.Instance.PlayerData.CarMapIndex == 1 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 2;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 2");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 2 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 3;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 3");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 3 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 4;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 4");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 4 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 5;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 5");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 5 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 1;
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 1");
            }
        }
    }
}
