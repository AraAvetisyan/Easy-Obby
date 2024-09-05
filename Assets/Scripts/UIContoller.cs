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
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 1)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneRunning 1 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel2 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel2 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneRunning 2 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel3 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel3 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneRunning 3 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel4 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel4 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneRunning 4 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel5 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel5 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneRunning 5 Exit Level");
            }
            Geekplay.Instance.Save();
        }
        if (isBicycleMode)
        {
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneBicycle 1 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel2 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel2 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneBicycle 2 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel3 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel3 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneBicycle 3 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel4 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel4 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneBicycle 4 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel5 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel5 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneBicycle 5 Exit Level");
            }
            Geekplay.Instance.Save();
        }
        if (isCarMode)
        {
            if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneCar 1 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel2 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel2 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneCar 2 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel3 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel3 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneCar 3 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel4 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel4 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneCar 4 Exit Level");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel5 = _timerScript.Minutes;
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel5 = _timerScript.Seconds;
                Analytics.instance.SendEvent("SampleSceneCar 5 Exit Level");
            }
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
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 1 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 2;
                if(Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel2 = 0;
                    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel2 = 0;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel2 = 0;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 2");

            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 2 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 3;
                if(Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel3 = 0;
                    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel3 = 0;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel3 = 0;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 3");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 3 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 4;
                if(Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel4 = 0;
                    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel4 = 0;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel4 = 0;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 4");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 4 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 5;
                if(Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel5 = 0;
                    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel5 = 0;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel5 = 0;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneRunning 5");
            }
            if (Geekplay.Instance.PlayerData.RunningMapIndex == 5 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.RunningMapIndex = 1;
                if(Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = 0;
                    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = 0;
                    Geekplay.Instance.PlayerData.RunningFillAmountLevel1 = 0;
                    Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 = 0;
                }
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
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel2 = 0;
                    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel2 = 0;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel2 = 0;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 2");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 3;
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel3 = 0;
                    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel3 = 0;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel3 = 0;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 3");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 4;
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel4 = 0;
                    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel4 = 0;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel4 = 0;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 4");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 5;
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel5 = 0;
                    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel5 = 0;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel5 = 0;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneBicycle 5");
            }
            if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.BicycleMapIndex = 1;
                if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = 0;
                    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = 0;
                    Geekplay.Instance.PlayerData.BicycleFillAmountLevel1 = 0;
                    Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 = 0;
                }
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
                if(Geekplay.Instance.PlayerData.CarSaveProgressLevel2  >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel2 = 0;
                    Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel2 = 0;
                    Geekplay.Instance.PlayerData.CarFillAmountLevel2 = 0;
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel2 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 2");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 2 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 3;
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel3 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel3 = 0;
                    Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel3 = 0;
                    Geekplay.Instance.PlayerData.CarFillAmountLevel3 = 0;
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel3 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 3");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 3 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 4;
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel4 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel4 = 0;
                    Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel4 = 0;
                    Geekplay.Instance.PlayerData.CarFillAmountLevel4 = 0;
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel4 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 4");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 4 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 5;
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel5 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel5 = 0;
                    Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel5 = 0;
                    Geekplay.Instance.PlayerData.CarFillAmountLevel5 = 0;
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel5 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 5");
            }
            if (Geekplay.Instance.PlayerData.CarMapIndex == 5 && nextCount == 0)
            {
                nextCount = 1;
                Geekplay.Instance.PlayerData.CarMapIndex = 1;
                if (Geekplay.Instance.PlayerData.CarSaveProgressLevel1 >= 100)
                {
                    Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = 0;
                    Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = 0;
                    Geekplay.Instance.PlayerData.CarFillAmountLevel1 = 0;
                    Geekplay.Instance.PlayerData.CarSaveProgressLevel1 = 0;
                }
                Geekplay.Instance.Save();
                SceneManager.LoadScene("SampleSceneCar 1");
            }
        }
    }
}
