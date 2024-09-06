using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    public float Seconds;
    public float Minutes;

    public bool StopTimer;
    [SerializeField] private bool runningMode, bicycleMode, carMode;
    [SerializeField] private TextMeshProUGUI finalBestTimerText;
    private int stopCounter;
    private void Start()
    {
        Continue();
        StartCoroutine(UpdateTimer());


        var culture = new CultureInfo("en-EN");
        if (runningMode)
        {
            if (Minutes < 10)
            {
                if (Seconds < 10)
                {
                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString("F2", culture);
                }
                else
                {
                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString("F2", culture);
                }
            }
            if (Minutes >= 10)
            {
                if (Seconds < 10)
                {
                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString("F2", culture);
                }
                else
                {
                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString("F2", culture);
                }
            }
        }


        if (bicycleMode)
        {
            if (Minutes < 10)
            {
                if (Seconds < 10)
                {
                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString("F2", culture);
                }
                else
                {
                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString("F2", culture);
                }
            }
            if (Minutes >= 10)
            {
                if (Seconds < 10)
                {
                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString("F2", culture);
                }
                else
                {
                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString("F2", culture);
                }
            }
        }


        if (carMode)
        {
            if (Minutes < 10)
            {
                if (Seconds < 10)
                {
                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString("F2", culture);
                }
                else
                {
                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString("F2", culture);
                }
            }
            if (Minutes >= 10)
            {
                if (Seconds < 10)
                {
                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString("F2", culture);
                }
                else
                {
                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString("F2", culture);
                }
            }
        }
    }

   
    public void Continue()
    {
        if (runningMode)
        {
            if (MainMenuUI.Instance.ContinueRun)
            {
                Minutes = Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex];
                Seconds = Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex];
            }
        }


        if (bicycleMode)
        {
            if (MainMenuUI.Instance.ContinueBicycle)
            {
                Minutes = Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
                Seconds = Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
            }
        }


        if (carMode)
        {
            if (MainMenuUI.Instance.ContinueCar)
            {
                Minutes = Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex];
                Seconds = Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex];
            }
        }
    }
    private void Update()
    {
        if (runningMode)
        {
            if (StopTimer && stopCounter == 0)
            {

                Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex];
                Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex];
                var culture = new CultureInfo("en-EN");
                stopCounter = 1;
                if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] > Minutes)
                {
                    Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = Minutes;
                    Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = Seconds;
                }
                if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] == Minutes)
                {
                    if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] > Seconds)
                    {
                        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = Seconds;
                    }
                }
                if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] == 0 && Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] == 0)
                {

                    Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = Minutes;
                    Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex] = Seconds;
                }
                Geekplay.Instance.Save();
                if (Minutes < 10)
                {
                    if (Seconds < 10)
                    {
                        finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString("F2", culture);
                    }
                    else
                    {
                        finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString("F2", culture);
                    }
                }
                else
                {
                    if (Seconds < 10)
                    {
                        finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString("F2", culture);
                    }
                    else
                    {
                        finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevels[Geekplay.Instance.PlayerData.RunningMapIndex].ToString("F2", culture);
                    }
                }
            }
        }
        
        if (bicycleMode)
        {
            if (StopTimer && stopCounter == 0)
            {
                Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
                Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
                var culture = new CultureInfo("en-EN");
                stopCounter = 1;
                if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] > Minutes)
                {
                    Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = Minutes;
                    Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = Seconds;
                }
                if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] == Minutes)
                {
                    if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] > Seconds)
                    {
                        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = Seconds;
                    }
                }
                if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] == 0 && Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] == 0)
                {

                    Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = Minutes;
                    Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex] = Seconds;
                }
                Geekplay.Instance.Save();
                if (Minutes < 10)
                {
                    if (Seconds < 10)
                    {
                        finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString("F2", culture);
                    }
                    else
                    {
                        finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString("F2", culture);
                    }
                }
                else
                {
                    if (Seconds < 10)
                    {
                        finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString("F2", culture);
                    }
                    else
                    {
                        finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex].ToString("F2", culture);
                    }
                }
            }
        }



        if (carMode)
        {
            if (StopTimer && stopCounter == 0)
            {
                Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] = Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex];
                Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] = Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex];
                var culture = new CultureInfo("en-EN");
                stopCounter = 1;
                if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] > Minutes)
                {
                    Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] = Minutes;
                    Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] = Seconds;
                }
                if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] == Minutes)
                {
                    if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] > Seconds)
                    {
                        Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] = Seconds;
                    }
                }
                if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] == 0 && Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] == 0)
                {

                    Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex] = Minutes;
                    Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex] = Seconds;
                }
                Geekplay.Instance.Save();
                if (Minutes < 10)
                {
                    if (Seconds < 10)
                    {
                        finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString("F2", culture);
                    }
                    else
                    {
                        finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString("F2", culture);
                    }
                }
                else
                {
                    if (Seconds < 10)
                    {
                        finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString("F2", culture);
                    }
                    else
                    {
                        finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex].ToString("F2", culture);
                    }
                }
            }
        }
    }
    private IEnumerator UpdateTimer()
    {
        while (!StopTimer)
        {
            Seconds += 0.01f;
            UpdateTimer();
            yield return new WaitForSeconds(0.01f);

            if(Seconds >= 60)
            {
                Seconds = 0;
                Minutes++;
            }

            var culture = new CultureInfo("en-EN");
            if (Minutes < 10)
            {
                if (Seconds < 10)
                {
                    timerText.text = "0" + Minutes.ToString() + "." + "0" + Seconds.ToString("F2", culture);
                }
                else
                {
                    timerText.text = "0" + Minutes.ToString() + "." + Seconds.ToString("F2", culture);
                }
            }
            else
            {
                if (Seconds < 10)
                {
                    timerText.text = Minutes.ToString() + "." + "0" + Seconds.ToString("F2", culture);
                }
                else
                {
                    timerText.text = Minutes.ToString() + "." + Seconds.ToString("F2", culture);
                }
            }
           
        }

    }

}