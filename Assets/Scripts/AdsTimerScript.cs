using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsTimerScript : MonoBehaviour
{
    public static AdsTimerScript Instance;
    private Coroutine minuteTimer;
    public bool CanShow;
    [SerializeField] private int timeText;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {

        StartMinutesCoroutine();
    }
    public void StartMinutesCoroutine()
    {
        if (minuteTimer == null)
        {
            minuteTimer = StartCoroutine(MinutesCoroutine());
        }
    }
    public void StopMinutesCoroutine()
    {
        if (minuteTimer != null)
        {
            StopCoroutine(minuteTimer);
            minuteTimer = null;
        }
        StartMinutesCoroutine();
    }
    public IEnumerator MinutesCoroutine()
    {
        float duration = 65f;
        float elapsed = 0f;
        CanShow = false;
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            timeText = (int)elapsed;
            yield return null;
        }
        CanShow = true;

    }
}
