using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContoller : MonoBehaviour
{
    [SerializeField] private bool isRunningMode, isBicycleMode, isCarMode;
    [SerializeField] private TimerScript _timerScript;
    public void PressedHome()
    {
        _timerScript.SaveTime();
        Analytics.instance.SendEvent(SceneManager.GetActiveScene().name + "Exit Level");
        Geekplay.Instance.Save();
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedHomeFinal()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedNext()
    {
        if (Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex+1] >= 100)
        {
            Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.CurrentMapMilisecondsLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.SaveProgressMenuLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.FillAmountLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.SaveProgressLevels[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
            Geekplay.Instance.PlayerData.Rotation[Geekplay.Instance.PlayerData.MapIndex + 1] = 0;
        }
        Geekplay.Instance.PlayerData.MapIndex += 1;

        Geekplay.Instance.Save();

        SceneManager.LoadScene(Geekplay.Instance.PlayerData.MapIndex + 1);
    }
}
