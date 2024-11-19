using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] namesInGame;
    [SerializeField] private TextMeshProUGUI[] time;
    [SerializeField] private TextMeshProUGUI remainingTimeView;
    private Coroutine timer;
    float minutes;
    float seconds;
    float milliseconds;
    void Start()
    {
        StartCoroutine(IETimer());
        //IETimer();
        //Запустить корутину, которая каждые 60 секунд будет заново запрашивать данные лидерборда ++
        //и заполнять их в твои тексты через Geekplay.Instance.lS и Geekplay.Instance.lN ++
    }
    public IEnumerator IETimer()
    {
        Geekplay.Instance.remainingTimeUntilUpdateLeaderboard = 60;
        Geekplay.Instance.leaderNumber = 0;
        Geekplay.Instance.leaderNumberN = 0;
        Utils.GetLeaderboard("score", 0, "TimerLid");
        Utils.GetLeaderboard("name", 0, "TimerLid");
        StartTimerCoroutine();
        //yield return new WaitForSeconds(1);
       
        yield return new WaitForSeconds(1);
        for (int i = 0; i < namesInGame.Length; i++)
        {

            namesInGame[i].text = Geekplay.Instance.lN[i];
            float lsTime = float.Parse(Geekplay.Instance.lS[i]);
            Debug.Log(lsTime);
            minutes = Mathf.FloorToInt(lsTime / 60);
            seconds = Mathf.FloorToInt(lsTime % 60);
            milliseconds = Mathf.FloorToInt((lsTime * 100) % 100);
            time[i].text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, (int)milliseconds);



        }
    }

    public void StartTimerCoroutine()
    {
        if (timer == null)
        {
            timer = StartCoroutine(RemainingTimer());
        }
    }
    public void StopTimerCoroutine()
    {
        if (timer != null)
        {
            StopCoroutine(timer);
            timer = null;
        }
        StartTimerCoroutine();
    }
    public IEnumerator RemainingTimer()
    {
        yield return new WaitForSeconds(60);
        Geekplay.Instance.leaderNumber = 0;
        Geekplay.Instance.leaderNumberN = 0;
        Utils.GetLeaderboard("score", 0, "TimerLid");
        Utils.GetLeaderboard("name", 0, "TimerLid");
        yield return new WaitForSeconds(1);
       

        for (int i = 0; i < namesInGame.Length; i++)
        {
            namesInGame[i].text = Geekplay.Instance.lN[i];
            float lsTime = float.Parse(Geekplay.Instance.lS[i]);

            minutes = Mathf.FloorToInt(lsTime / 60);
            seconds = Mathf.FloorToInt(lsTime % 60);
            milliseconds = Mathf.FloorToInt((lsTime * 100) % 100);
            time[i].text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, (int)milliseconds);

        }
        StopTimerCoroutine();
    }
    void Update()
    {
        if (Geekplay.Instance.remainingTimeUntilUpdateLeaderboard <= 0)
        {
            Geekplay.Instance.remainingTimeUntilUpdateLeaderboard = 60;
        }
        remainingTimeView.text = string.Format("{0:f0}", Geekplay.Instance.remainingTimeUntilUpdateLeaderboard);
    }

    //при прохождении уровня ++
    //определяем, наивысший ли это уровень ++
    //сохраняем его и посылаем ++
    //Geekplay.Instance.Leaderboard("Levels", {количество_уровня}); ++
}
