using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIContoller : MonoBehaviour
{
    public void PressedRun()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void PressedBicycle()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
