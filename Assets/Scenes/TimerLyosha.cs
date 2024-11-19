using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
public class TimerLyosha : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    private float CurrentTime;
    private float StartTime;
    float minutes;
    float seconds;
    float milliseconds;
    private IEnumerator CountDownOnStart()
    {
        
        int Timer = 4;
        while (Timer != 1)
        {
            Timer--;
           
            yield return new WaitForSeconds(1f);

        }
        Geekplay.Instance.Save();     
        StartTime = Time.time;
    }
   
   
    private void Update()
    {
        CurrentTime = Time.time - StartTime;
        minutes = Mathf.Floor(CurrentTime / 60F);
        seconds = Mathf.RoundToInt(CurrentTime % 60);
        milliseconds = (int)(Time.timeSinceLevelLoad * 1000f) % 1000;
        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
}