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
            //if (Geekplay.Instance.PlayerData.RunningMapIndex == 1)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
            //        }
            //    }
            //}

            //if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
            //        }
            //    }
            //}

            //if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
            //        }
            //    }
            //}

            //if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
            //        }
            //    }
            //}

            //if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
            //        }
            //    }
            //}
        }


        ////////////////////////////////////////////////////


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


            //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
            //        }
            //    }
            //}

            //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
            //        }
            //    }
            //}

            //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
            //        }
            //    }
            //}

            //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
            //        }
            //    }
            //}

            //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
            //{
            //    if (Minutes < 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
            //        }
            //    }
            //    if (Minutes >= 10)
            //    {
            //        if (Seconds < 10)
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
            //        }
            //        else
            //        {
            //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
            //        }
            //    }
            //}
        }

        ///////////////////////////////////////////////////////////////////


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
            //    if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
            //    {
            //        if (Minutes < 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
            //            }
            //        }
            //        if (Minutes >= 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
            //            }
            //        }
            //    }

            //    if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
            //    {
            //        if (Minutes < 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
            //            }
            //        }
            //        if (Minutes >= 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
            //            }
            //        }
            //    }

            //    if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
            //    {
            //        if (Minutes < 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
            //            }
            //        }
            //        if (Minutes >= 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
            //            }
            //        }
            //    }

            //    if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
            //    {
            //        if (Minutes < 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
            //            }
            //        }
            //        if (Minutes >= 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
            //            }
            //        }
            //    }

            //    if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
            //    {
            //        if (Minutes < 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
            //            }
            //        }
            //        if (Minutes >= 10)
            //        {
            //            if (Seconds < 10)
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
            //            }
            //            else
            //            {
            //                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
            //            }
            //        }
            //    }
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
                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 1)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1;
                //}
                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel2;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel2;
                //}
                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel3;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel3;
                //}
                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel4;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel4;
                //}
                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel5;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel5;
                //}
            }
        }

        //////////////////////////////////////////////////


        if (bicycleMode)
        {
            if (MainMenuUI.Instance.ContinueBicycle)
            {
                Minutes = Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
                Seconds = Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevels[Geekplay.Instance.PlayerData.BicycleMapIndex];
                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1;
                //}
                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel2;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel2;
                //}
                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel3;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel3;
                //}
                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel4;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel4;
                //}
                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel5;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel5;
                //}
            }
        }


        //////////////////////////////////////////////////////////


        if (carMode)
        {
            if (MainMenuUI.Instance.ContinueCar)
            {
                Minutes = Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevels[Geekplay.Instance.PlayerData.CarMapIndex];
                Seconds = Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevels[Geekplay.Instance.PlayerData.CarMapIndex];
                //if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1;
                //}
                //if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel2;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel2;
                //}
                //if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel3;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel3;
                //}
                //if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel4;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel4;
                //}
                //if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
                //{
                //    Minutes = Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel5;
                //    Seconds = Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel5;
                //}
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


                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 1)
                //{
                //    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel1 = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1;
                //    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel1 = Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1 > Seconds)
                //        {

                //            Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1 == 0 && Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1 == 0)
                //    {
                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel1.ToString("F2", culture);
                //        }
                //    }
                //}

                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 2)
                //{
                //    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel2 = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2;
                //    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel2 = Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2 == 0 && Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel2.ToString("F2", culture);
                //        }
                //    }
                //}

                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 3)
                //{
                //    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel3 = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3;
                //    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel3 = Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3 == 0 && Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel3.ToString("F2", culture);
                //        }
                //    }
                //}

                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 4)
                //{
                //    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel4 = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4;
                //    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel4 = Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4 == 0 && Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel4.ToString("F2", culture);
                //        }
                //    }
                //}

                //if (Geekplay.Instance.PlayerData.RunningMapIndex == 5)
                //{
                //    Geekplay.Instance.PlayerData.CurrentRunningMapMinutesLevel5 = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5;
                //    Geekplay.Instance.PlayerData.CurrentRunningMapSecondsLevel5 = Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5 == 0 && Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5 = Minutes;
                //        Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestRunningMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestRunningMapSecondsLevel5.ToString("F2", culture);
                //        }
                //    }
                //}
            }
        }


        /////////////////////////////////////////////////////////
        
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



                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 1)
                //{
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel1 = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1;
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel1 = Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1 == 0 && Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel1.ToString("F2", culture);
                //        }
                //    }
                //}

                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 2)
                //{
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel2 = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2;
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel2 = Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2 == 0 && Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel2.ToString("F2", culture);
                //        }
                //    }
                //}

                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 3)
                //{
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel3 = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3;
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel3 = Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3 == 0 && Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel3.ToString("F2", culture);
                //        }
                //    }
                //}

                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 4)
                //{
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel4 = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4;
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel4 = Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4 == 0 && Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel4.ToString("F2", culture);
                //        }
                //    }
                //}

                //if (Geekplay.Instance.PlayerData.BicycleMapIndex == 5)
                //{
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapMinutesLevel5 = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5;
                //    Geekplay.Instance.PlayerData.CurrentBicycleMapSecondsLevel5 = Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5;
                //    var culture = new CultureInfo("en-EN");
                //    stopCounter = 1;
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5 > Minutes)
                //    {
                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5 = Seconds;
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5 == Minutes)
                //    {
                //        if (Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5 > Seconds)
                //        {
                //            Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5 = Seconds;
                //        }
                //    }
                //    if (Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5 == 0 && Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5 == 0)
                //    {

                //        Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5 = Minutes;
                //        Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5 = Seconds;
                //    }
                //    Geekplay.Instance.Save();
                //    if (Minutes < 10)
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
                //        }
                //    }
                //    else
                //    {
                //        if (Seconds < 10)
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
                //        }
                //        else
                //        {
                //            finalBestTimerText.text = Geekplay.Instance.PlayerData.BestBicycleMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestBicycleMapSecondsLevel5.ToString("F2", culture);
                //        }
                //    }
                //}
            }
        }

        //////////////////////////////////////////////



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
                //    if (StopTimer && stopCounter == 0)
                //    {
                //        if (Geekplay.Instance.PlayerData.CarMapIndex == 1)
                //        {
                //            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel1 = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1;
                //            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel1 = Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1;
                //            var culture = new CultureInfo("en-EN");
                //            stopCounter = 1;
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1 > Minutes)
                //            {
                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1 = Seconds;
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1 == Minutes)
                //            {
                //                if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1 > Seconds)
                //                {
                //                    Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1 = Seconds;
                //                }
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1 == 0 && Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1 == 0)
                //            {

                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1 = Seconds;
                //            }
                //            Geekplay.Instance.Save();
                //            if (Minutes < 10)
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
                //                }
                //            }
                //            else
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel1.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel1.ToString("F2", culture);
                //                }
                //            }
                //        }

                //        if (Geekplay.Instance.PlayerData.CarMapIndex == 2)
                //        {
                //            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel2 = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2;
                //            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel2 = Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2;
                //            var culture = new CultureInfo("en-EN");
                //            stopCounter = 1;
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2 > Minutes)
                //            {
                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2 = Seconds;
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2 == Minutes)
                //            {
                //                if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2 > Seconds)
                //                {
                //                    Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2 = Seconds;
                //                }
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2 == 0 && Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2 == 0)
                //            {

                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2 = Seconds;
                //            }
                //            Geekplay.Instance.Save();
                //            if (Minutes < 10)
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
                //                }
                //            }
                //            else
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel2.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel2.ToString("F2", culture);
                //                }
                //            }
                //        }

                //        if (Geekplay.Instance.PlayerData.CarMapIndex == 3)
                //        {
                //            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel3 = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3;
                //            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel3 = Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3;
                //            var culture = new CultureInfo("en-EN");
                //            stopCounter = 1;
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3 > Minutes)
                //            {
                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3 = Seconds;
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3 == Minutes)
                //            {
                //                if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3 > Seconds)
                //                {
                //                    Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3 = Seconds;
                //                }
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3 == 0 && Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3 == 0)
                //            {

                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3 = Seconds;
                //            }
                //            Geekplay.Instance.Save();
                //            if (Minutes < 10)
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
                //                }
                //            }
                //            else
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel3.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel3.ToString("F2", culture);
                //                }
                //            }
                //        }

                //        if (Geekplay.Instance.PlayerData.CarMapIndex == 4)
                //        {
                //            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel4 = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4;
                //            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel4 = Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4;
                //            var culture = new CultureInfo("en-EN");
                //            stopCounter = 1;
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4 > Minutes)
                //            {
                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4 = Seconds;
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4 == Minutes)
                //            {
                //                if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4 > Seconds)
                //                {
                //                    Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4 = Seconds;
                //                }
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4 == 0 && Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4 == 0)
                //            {

                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4 = Seconds;
                //            }
                //            Geekplay.Instance.Save();
                //            if (Minutes < 10)
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
                //                }
                //            }
                //            else
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel4.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel4.ToString("F2", culture);
                //                }
                //            }
                //        }

                //        if (Geekplay.Instance.PlayerData.CarMapIndex == 5)
                //        {
                //            Geekplay.Instance.PlayerData.CurrentCarMapMinutesLevel5 = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5;
                //            Geekplay.Instance.PlayerData.CurrentCarMapSecondsLevel5 = Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5;
                //            var culture = new CultureInfo("en-EN");
                //            stopCounter = 1;
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5 > Minutes)
                //            {
                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5 = Seconds;
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5 == Minutes)
                //            {
                //                if (Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5 > Seconds)
                //                {
                //                    Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5 = Seconds;
                //                }
                //            }
                //            if (Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5 == 0 && Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5 == 0)
                //            {

                //                Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5 = Minutes;
                //                Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5 = Seconds;
                //            }
                //            Geekplay.Instance.Save();
                //            if (Minutes < 10)
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
                //                }
                //            }
                //            else
                //            {
                //                if (Seconds < 10)
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
                //                }
                //                else
                //                {
                //                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestCarMapMinutesLevel5.ToString() + "." + Geekplay.Instance.PlayerData.BestCarMapSecondsLevel5.ToString("F2", culture);
                //                }
                //            }
                //        }
                //    }
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






















//private void Start()
//{
//    StartTime = Time.time;
//}



//private void Update()
//{
//    if (!StopTimer)
//    {
//        CurrentTime = Time.time - StartTime;
//        minutes = Mathf.Floor(CurrentTime / 60F);
//        seconds = Mathf.RoundToInt(CurrentTime % 60);
//        milliseconds = (int)(Time.timeSinceLevelLoad * 100f) % 100;
//        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
//        Geekplay.Instance.PlayerData.CurrentRunningMapMinutes = minutes;
//        Geekplay.Instance.PlayerData.CurrentRunningMapSeconds = seconds;
//        Geekplay.Instance.PlayerData.CurrentRunningMapMiliseconds = milliseconds;
//    }
//    if (StopTimer)
//    {
//        if (runningMode)
//        {
//            if (Geekplay.Instance.PlayerData.BestRunningMapMinutes >= minutes)
//            {
//                Geekplay.Instance.PlayerData.BestRunningMapMinutes = minutes;
//                Geekplay.Instance.PlayerData.BestRunningMapSeconds = seconds;
//                Geekplay.Instance.PlayerData.BestRunningMapMiliseconds = milliseconds;
//            }
//            if (Geekplay.Instance.PlayerData.BestRunningMapMinutes == minutes)
//            {
//                if (Geekplay.Instance.PlayerData.BestRunningMapSeconds >= seconds)
//                {
//                    Geekplay.Instance.PlayerData.BestRunningMapSeconds = seconds;
//                    Geekplay.Instance.PlayerData.BestRunningMapMiliseconds = milliseconds;
//                }
//            }
//            if (Geekplay.Instance.PlayerData.BestRunningMapMinutes == minutes)
//            {
//                if (Geekplay.Instance.PlayerData.BestRunningMapSeconds == seconds)
//                {
//                    if (Geekplay.Instance.PlayerData.BestRunningMapMiliseconds >= milliseconds)
//                    {
//                        Geekplay.Instance.PlayerData.BestRunningMapMiliseconds = milliseconds;
//                    }
//                }
//            }

//            finalBestTimerText.text = string.Format("{0:00}:{1:00}:{2:00}", Geekplay.Instance.PlayerData.BestRunningMapMinutes, Geekplay.Instance.PlayerData.BestRunningMapSeconds, Geekplay.Instance.PlayerData.BestRunningMapMiliseconds);
//        }
//    }
//}