using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mapMenu;
  

    public void PressedNewMap()
    {
        mapMenu.SetActive(true);
    }
    public void PressedBack()
    {
        mapMenu.SetActive(false);
    }
    public void PressedRun()
    {
        SceneManager.LoadScene("SampleSceneRunning");
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.PlayerData.RunningMap = true;
        Geekplay.Instance.Save();
    }
    public void PressedBicycle() 
    {
        SceneManager.LoadScene("SampleSceneBicycle");
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.PlayerData.RunningMap = false;
        Geekplay.Instance.Save();
    }
    public void PressedContinue()
    {

        if (Geekplay.Instance.PlayerData.IsFirstTry != 0)
        {
            if (Geekplay.Instance.PlayerData.RunningMap)
            {
                SceneManager.LoadScene("SampleSceneRunning");
            }
            else
            {
                SceneManager.LoadScene("SampleSceneBicycle");
            }
        }
    }
}
