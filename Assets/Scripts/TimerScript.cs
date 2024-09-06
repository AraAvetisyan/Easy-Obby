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
        if (Minutes < 10)
        {
            if (Seconds < 10)
            {
                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex].ToString("F2", culture);
            }
            else
            {
                finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex].ToString("F2", culture);
            }
        }
        if (Minutes >= 10)
        {
            if (Seconds < 10)
            {
                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex].ToString("F2", culture);
            }
            else
            {
                finalBestTimerText.text = Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex].ToString("F2", culture);
            }
        }
    }
    public void Continue()
    {
        if (MainMenuUI.Instance.Continue)
        {
            Minutes = Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex];
            Seconds = Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
        }
    }
    private void Update()
    {
        if (StopTimer && stopCounter == 0)
        {
            Geekplay.Instance.PlayerData.CurrentMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex];
            Geekplay.Instance.PlayerData.CurrentMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex];
            var culture = new CultureInfo("en-EN");
            stopCounter = 1;
            if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] > Minutes)
            {
                Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = Minutes;
                Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Seconds;
            }
            if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] == Minutes)
            {
                if (Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] > Seconds)
                {
                    Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Seconds;
                }
            }
            if (Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] == 0 && Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] == 0)
            {
                Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex] = Minutes;
                Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex] = Seconds;
            }
            Geekplay.Instance.Save();
            if (Minutes < 10)
            {
                if (Seconds < 10)
                {
                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex].ToString("F2", culture);
                }
                else
                {
                    finalBestTimerText.text = "0" + Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex].ToString("F2", culture);
                }
            }
            else
            {
                if (Seconds < 10)
                {
                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex].ToString() + "." + "0" + Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex].ToString("F2", culture);
                }
                else
                {
                    finalBestTimerText.text = Geekplay.Instance.PlayerData.BestMapMinutesLevels[Geekplay.Instance.PlayerData.MapIndex].ToString() + "." + Geekplay.Instance.PlayerData.BestMapSecondsLevels[Geekplay.Instance.PlayerData.MapIndex].ToString("F2", culture);
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