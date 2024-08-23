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


    [SerializeField] private Image runningProgressLevel1, runningProgressLevel2, runningProgressLevel3, runningProgressLevel4, runningProgressLevel5;
    [SerializeField] private Image bicycleProgressLevel1, bicycleProgressLevel2, bicycleProgressLevel3, bicycleProgressLevel4, bicycleProgressLevel5;
    [SerializeField] private Image carProgressLevel1, carProgressLevel2, carProgressLevel3, carProgressLevel4, carProgressLevel5;

    [SerializeField] private TextMeshProUGUI runningTimerLevel1, runningTimerLevel2, runningTimerLevel3, runningTimerLevel4, runningTimerLevel5; 
    [SerializeField] private TextMeshProUGUI bicycleTimerLevel1, bicycleTimerLevel2, bicycleTimerLevel3, bicycleTimerLevel4, bicycleTimerLevel5; 
    [SerializeField] private TextMeshProUGUI carTimerLevel1, carTimerLevel2, carTimerLevel3, carTimerLevel4, carTimerLevel5;

    [SerializeField] private GameObject runMenu, bicycleMenu, carMenu;

    [SerializeField] private TextMeshProUGUI runningProgressPercentLevel1, runningProgressPercentLevel2, runningProgressPercentLevel3, runningProgressPercentLevel4, runningProgressPercentLevel5;
    [SerializeField] private TextMeshProUGUI bicycleProgressPercentLevel1, bicycleProgressPercentLevel2, bicycleProgressPercentLevel3, bicycleProgressPercentLevel4, bicycleProgressPercentLevel5;
    [SerializeField] private TextMeshProUGUI carProgressPercentLevel1, carProgressPercentLevel2, carProgressPercentLevel3, carProgressPercentLevel4, carProgressPercentLevel5;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinsText.text = Geekplay.Instance.PlayerData.Coins.ToString();
        diamondsText.text = Geekplay.Instance.PlayerData.Diamond.ToString();

        if (Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel1 >= 100)
        {
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel1 = 100;
        }
        if (Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel2 >= 100)
        {
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel2 = 100;
        }
        if (Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel3 >= 100)
        {
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel3 = 100;
        }
        if (Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel4 >= 100)
        {
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel4 = 100;
        }
        if (Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel5 >= 100)
        {
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel5 = 100;
        }

        if (Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel1 >= 100)
        {
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel1 = 100;
        }
        if (Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel2 >= 100)
        {
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel2 = 100;
        }
        if (Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel3 >= 100)
        {
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel3 = 100;
        }
        if (Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel4 >= 100)
        {
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel4 = 100;
        }
        if (Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel5 >= 100)
        {
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel5 = 100;
        }

        if (Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel1 >= 100)
        {
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel1 = 100;
        }
        if (Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel2 >= 100)
        {
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel2 = 100;
        }
        if (Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel3 >= 100)
        {
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel3 = 100;
        }
        if (Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel4 >= 100)
        {
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel4 = 100;
        }
        if (Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel5 >= 100)
        {
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel5 = 100;
        }
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
        runningProgressLevel1.fillAmount = Geekplay.Instance.PlayerData.RunningFillAmountLevel1;
        runningProgressLevel2.fillAmount = Geekplay.Instance.PlayerData.RunningFillAmountLevel2;
        runningProgressLevel3.fillAmount = Geekplay.Instance.PlayerData.RunningFillAmountLevel3;
        runningProgressLevel4.fillAmount = Geekplay.Instance.PlayerData.RunningFillAmountLevel4;
        runningProgressLevel5.fillAmount = Geekplay.Instance.PlayerData.RunningFillAmountLevel5;

        runningProgressPercentLevel1.text = Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel1.ToString() + "%";
        runningProgressPercentLevel2.text = Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel2.ToString() + "%";
        runningProgressPercentLevel3.text = Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel3.ToString() + "%";
        runningProgressPercentLevel4.text = Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel4.ToString() + "%";
        runningProgressPercentLevel5.text = Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel5.ToString() + "%";

        var culture = new CultureInfo("en-EN");

        ///// Level 1 
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1 < 10)
            {
                runningTimerLevel1.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel1.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1 < 10)
            {
                runningTimerLevel1.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel1.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
            }
        }

        ///// Level 2 
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2 < 10)
            {
                runningTimerLevel2.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel2.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2 < 10)
            {
                runningTimerLevel2.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel2.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
            }
        }

        ///// Level 3
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3 < 10)
            {
                runningTimerLevel3.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel3.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3 < 10)
            {
                runningTimerLevel3.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel3.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
            }
        }

        ///// Level 4 
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4 < 10)
            {
                runningTimerLevel4.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel4.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4 < 10)
            {
                runningTimerLevel4.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel4.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
            }
        }

        ///// Level 5 
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5 < 10)
            {
                runningTimerLevel5.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel5.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5 < 10)
            {
                runningTimerLevel5.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
            }
            else
            {
                runningTimerLevel5.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
            }
        }
    }
    public void PressedBicycleMenu()
    {
        bicycleGamePanel.SetActive(true);
        bicycleProgressLevel1.fillAmount = Geekplay.Instance.PlayerData.BicycleFillAmountLevel1;
        bicycleProgressLevel2.fillAmount = Geekplay.Instance.PlayerData.BicycleFillAmountLevel2;
        bicycleProgressLevel3.fillAmount = Geekplay.Instance.PlayerData.BicycleFillAmountLevel3;
        bicycleProgressLevel4.fillAmount = Geekplay.Instance.PlayerData.BicycleFillAmountLevel4;
        bicycleProgressLevel5.fillAmount = Geekplay.Instance.PlayerData.BicycleFillAmountLevel5;

        bicycleProgressPercentLevel1.text = Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel1.ToString() + "%";
        bicycleProgressPercentLevel2.text = Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel2.ToString() + "%";
        bicycleProgressPercentLevel3.text = Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel3.ToString() + "%";
        bicycleProgressPercentLevel4.text = Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel4.ToString() + "%";
        bicycleProgressPercentLevel5.text = Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel5.ToString() + "%";

        var culture = new CultureInfo("en-EN");

        //// Level 1

        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1 < 10)
            {
                bicycleTimerLevel1.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel1.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1 < 10)
            {
                bicycleTimerLevel1.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel1.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
            }
        }


        //// Level 2

        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2 < 10)
            {
                bicycleTimerLevel2.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel2.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2 < 10)
            {
                bicycleTimerLevel2.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel2.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
            }
        }

        /////Level 3


        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3 < 10)
            {
                bicycleTimerLevel3.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel3.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3 < 10)
            {
                bicycleTimerLevel3.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel3.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
            }
        }

        /////// Level 4

        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4 < 10)
            {
                bicycleTimerLevel4.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel4.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4 < 10)
            {
                bicycleTimerLevel4.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel4.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
            }
        }

        ////////// Level 5

        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5 < 10)
            {
                bicycleTimerLevel5.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel5.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5 < 10)
            {
                bicycleTimerLevel5.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
            }
            else
            {
                bicycleTimerLevel5.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
            }
        }

    }
    public void PressedCarMenu()
    {
        carGamePanel.SetActive(true);
        carProgressLevel1.fillAmount = Geekplay.Instance.PlayerData.CarFillAmountLevel1;
        carProgressLevel2.fillAmount = Geekplay.Instance.PlayerData.CarFillAmountLevel2;
        carProgressLevel3.fillAmount = Geekplay.Instance.PlayerData.CarFillAmountLevel3;
        carProgressLevel4.fillAmount = Geekplay.Instance.PlayerData.CarFillAmountLevel4;
        carProgressLevel5.fillAmount = Geekplay.Instance.PlayerData.CarFillAmountLevel5;

        carProgressPercentLevel1.text = Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel1.ToString() + "%";
        carProgressPercentLevel2.text = Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel2.ToString() + "%";
        carProgressPercentLevel3.text = Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel3.ToString() + "%";
        carProgressPercentLevel4.text = Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel4.ToString() + "%";
        carProgressPercentLevel5.text = Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel5.ToString() + "%";

        var culture = new CultureInfo("en-EN");

        /////////// Level 1

        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1 < 10)
            {
                carTimerLevel1.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
            }
            else
            {
                carTimerLevel1.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1 < 10)
            {
                carTimerLevel1.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
            }
            else
            {
                carTimerLevel1.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
            }
        }

        /////// Level 2

        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2 < 10)
            {
                carTimerLevel2.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
            }
            else
            {
                carTimerLevel2.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2 < 10)
            {
                carTimerLevel2.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
            }
            else
            {
                carTimerLevel2.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
            }
        }

        //////// Level 3

        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3 < 10)
            {
                carTimerLevel3.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
            }
            else
            {
                carTimerLevel3.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3 < 10)
            {
                carTimerLevel3.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
            }
            else
            {
                carTimerLevel3.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
            }
        }

        //// Level 4

        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4 < 10)
            {
                carTimerLevel4.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
            }
            else
            {
                carTimerLevel4.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4 < 10)
            {
                carTimerLevel4.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
            }
            else
            {
                carTimerLevel4.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
            }
        }

        ///// Level 5

        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5 < 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5 < 10)
            {
                carTimerLevel5.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
            }
            else
            {
                carTimerLevel5.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
            }
        }
        if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5 >= 10)
        {
            if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5 < 10)
            {
                carTimerLevel5.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
            }
            else
            {
                carTimerLevel5.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
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
        Geekplay.Instance.Save();
        if(Geekplay.Instance.PlayerData.RunningMapIndex == 1)
        {
            if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = 0;
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = 0;
                Geekplay.Instance.PlayerData.RunningFillAmountLevel1 = 0;
                Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneRunning 1");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
        {
            if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel2 = 0;
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel2 = 0;
                Geekplay.Instance.PlayerData.RunningFillAmountLevel2 = 0;
                Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneRunning 2");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
        {
            if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel3 = 0;
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel3 = 0;
                Geekplay.Instance.PlayerData.RunningFillAmountLevel3 = 0;
                Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneRunning 3");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
        {
            if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel4 = 0;
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel4 = 0;
                Geekplay.Instance.PlayerData.RunningFillAmountLevel4 = 0;
                Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneRunning 4");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
        {
            if (Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel5 = 0;
                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel5 = 0;
                Geekplay.Instance.PlayerData.RunningFillAmountLevel5 = 0;
                Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 = 0;
                Geekplay.Instance.Save();
            }
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
            if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = 0;
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = 0;
                Geekplay.Instance.PlayerData.BicycleFillAmountLevel1 = 0;
                Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneBicycle 1");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
        {
            if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel2 = 0;
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel2 = 0;
                Geekplay.Instance.PlayerData.BicycleFillAmountLevel2 = 0;
                Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneBicycle 2");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
        {
            if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel3 = 0;
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel3 = 0;
                Geekplay.Instance.PlayerData.BicycleFillAmountLevel3 = 0;
                Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneBicycle 3");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
        {
            if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel4 = 0;
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel4 = 0;
                Geekplay.Instance.PlayerData.BicycleFillAmountLevel4 = 0;
                Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneBicycle 4");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
        {
            if (Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel5 = 0;
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel5 = 0;
                Geekplay.Instance.PlayerData.BicycleFillAmountLevel5 = 0;
                Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneBicycle 5");
        }
    }
    public void PressedContinueCar()
    {
        ContinueCar = true;
        Geekplay.Instance.PlayerData.IsFirstTry = 1;
        Geekplay.Instance.Save();
        if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
        {
            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel1 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = 0;
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = 0;
                Geekplay.Instance.PlayerData.CarFillAmountLevel1 = 0;
                Geekplay.Instance.PlayerData.CarSaveProgressLevel1 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneCar 1");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
        {
            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel2 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel2 = 0;
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel2 = 0;
                Geekplay.Instance.PlayerData.CarFillAmountLevel2 = 0;
                Geekplay.Instance.PlayerData.CarSaveProgressLevel2 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneCar 2");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
        {
            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel3 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel3 = 0;
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel3 = 0;
                Geekplay.Instance.PlayerData.CarFillAmountLevel3 = 0;
                Geekplay.Instance.PlayerData.CarSaveProgressLevel3 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneCar 3");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
        {
            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel4 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel4 = 0;
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel4 = 0;
                Geekplay.Instance.PlayerData.CarFillAmountLevel4 = 0;
                Geekplay.Instance.PlayerData.CarSaveProgressLevel4 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneCar 4");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
        {
            if (Geekplay.Instance.PlayerData.CarSaveProgressLevel5 >= 100)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel5 = 0;
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel5 = 0;
                Geekplay.Instance.PlayerData.CarFillAmountLevel5 = 0;
                Geekplay.Instance.PlayerData.CarSaveProgressLevel5 = 0;
                Geekplay.Instance.Save();
            }
            SceneManager.LoadScene("SampleSceneCar 5");
        }
        //ContinueCar = true;
        //Geekplay.Instance.PlayerData.IsFirstTry = 1;
        //Geekplay.Instance.Save();
        //SceneManager.LoadScene("SampleSceneCar");
    }

    public void PressedNewGameRun()
    {
        if(Geekplay.Instance.PlayerData.RunningMapIndex == 1)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = 0;
            Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel1 = 0;
            Geekplay.Instance.PlayerData.RunningFillAmountLevel1 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressLevel1 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneRunning 1");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel2 = 0;
            Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel2 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel2 = 0;
            Geekplay.Instance.PlayerData.RunningFillAmountLevel2 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressLevel2 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneRunning 2");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel3 = 0;
            Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel3 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel3 = 0;
            Geekplay.Instance.PlayerData.RunningFillAmountLevel3 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressLevel3 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneRunning 3");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel4 = 0;
            Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel4 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel4 = 0;
            Geekplay.Instance.PlayerData.RunningFillAmountLevel4 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressLevel4 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneRunning 4");
        }
        if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
        {
            Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel5 = 0;
            Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel5 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressMenuLevel5 = 0;
            Geekplay.Instance.PlayerData.RunningFillAmountLevel5 = 0;
            Geekplay.Instance.PlayerData.RunningSaveProgressLevel5 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneRunning 1");
        }
    }
    public void PressedNewGameBicycle()
    {
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = 0;
            Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel1 = 0;
            Geekplay.Instance.PlayerData.BicycleFillAmountLevel1 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressLevel1 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneBicycle 1");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel2 = 0;
            Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel2 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel2 = 0;
            Geekplay.Instance.PlayerData.BicycleFillAmountLevel2 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressLevel2 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneBicycle 2");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel3 = 0;
            Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel3 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel3 = 0;
            Geekplay.Instance.PlayerData.BicycleFillAmountLevel3 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressLevel3 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneBicycle 3");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel4 = 0;
            Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel4 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel4 = 0;
            Geekplay.Instance.PlayerData.BicycleFillAmountLevel4 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressLevel4 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneBicycle 4");
        }
        if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
        {
            Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel5 = 0;
            Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel5 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressMenuLevel5 = 0;
            Geekplay.Instance.PlayerData.BicycleFillAmountLevel5 = 0;
            Geekplay.Instance.PlayerData.BicycleSaveProgressLevel5 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneBicycle 5");
        }
    }
    public void PressedNewGameCar()
    {
        if(Geekplay.Instance.PlayerData.CarMapIndex == 1)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = 0;
            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel1 = 0;
            Geekplay.Instance.PlayerData.CarFillAmountLevel1 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressLevel1 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneCar 1");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel2 = 0;
            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel2 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel2 = 0;
            Geekplay.Instance.PlayerData.CarFillAmountLevel2 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressLevel2 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneCar 2");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel3 = 0;
            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel3 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel3 = 0;
            Geekplay.Instance.PlayerData.CarFillAmountLevel3 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressLevel3 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneCar 3");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel4 = 0;
            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel4 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel4 = 0;
            Geekplay.Instance.PlayerData.CarFillAmountLevel4 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressLevel4 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneCar 4");
        }
        if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
        {
            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel5 = 0;
            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel5 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressMenuLevel5 = 0;
            Geekplay.Instance.PlayerData.CarFillAmountLevel5 = 0;
            Geekplay.Instance.PlayerData.CarSaveProgressLevel5 = 0;
            Geekplay.Instance.Save();
            SceneManager.LoadScene("SampleSceneCar 5");
        }
    }

    public void RunGameLevel1()
    {        
        Geekplay.Instance.PlayerData.RunningMapIndex = 1;
        Geekplay.Instance.Save();
        runMenu.SetActive(true);
    }
    public void RunGameLevel2()
    {
        Geekplay.Instance.PlayerData.RunningMapIndex = 2;
        Geekplay.Instance.Save();
        runMenu.SetActive(true);
    }
    public void RunGameLevel3()
    {
        Geekplay.Instance.PlayerData.RunningMapIndex = 3;
        Geekplay.Instance.Save();
        runMenu.SetActive(true);
    }
    public void RunGameLevel4()
    {
        Geekplay.Instance.PlayerData.RunningMapIndex = 4;
        Geekplay.Instance.Save();
        runMenu.SetActive(true);
    }
    public void RunGameLevel5()
    {
        Geekplay.Instance.PlayerData.RunningMapIndex = 5;
        Geekplay.Instance.Save();
        runMenu.SetActive(true);
    }


    public void BicycleGameLevel1()
    {
        Geekplay.Instance.PlayerData.BicycleMapIndex = 1;
        Geekplay.Instance.Save();
        bicycleMenu.SetActive(true);        
    }
    public void BicycleGameLevel2()
    {
        Geekplay.Instance.PlayerData.BicycleMapIndex = 2;
        Geekplay.Instance.Save();
        bicycleMenu.SetActive(true);
    }
    public void BicycleGameLevel3()
    {
        Geekplay.Instance.PlayerData.BicycleMapIndex = 3;
        Geekplay.Instance.Save();
        bicycleMenu.SetActive(true);
    }
    public void BicycleGameLevel4()
    {
        Geekplay.Instance.PlayerData.BicycleMapIndex = 4;
        Geekplay.Instance.Save();
        bicycleMenu.SetActive(true);
    }
    public void BicycleGameLevel5()
    {
        Geekplay.Instance.PlayerData.BicycleMapIndex = 5;
        Geekplay.Instance.Save();
        bicycleMenu.SetActive(true);
    }


    public void CarGameLevel1()
    {
        Geekplay.Instance.PlayerData.CarMapIndex = 1;
        Geekplay.Instance.Save();
        carMenu.SetActive(true);
    }
    public void CarGameLevel2()
    {
        Geekplay.Instance.PlayerData.CarMapIndex = 2;
        Geekplay.Instance.Save();
        carMenu.SetActive(true);
    }
    public void CarGameLevel3()
    {
        Geekplay.Instance.PlayerData.CarMapIndex = 3;
        Geekplay.Instance.Save();
        carMenu.SetActive(true);
    }
    public void CarGameLevel4()
    {
        Geekplay.Instance.PlayerData.CarMapIndex = 4;
        Geekplay.Instance.Save();
        carMenu.SetActive(true);
    }
    public void CarGameLevel5()
    {
        Geekplay.Instance.PlayerData.CarMapIndex = 5;
        Geekplay.Instance.Save();
        carMenu.SetActive(true);
    }
    public void CarLevelTest()
    {
        SceneManager.LoadScene("SampleSceneCar Test");
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
