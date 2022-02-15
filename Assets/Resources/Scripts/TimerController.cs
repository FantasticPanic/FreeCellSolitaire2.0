using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerController : MonoBehaviour
{
    public static TimerController instance;

    public TextMeshProUGUI timeCounter;
    public TimeSpan timePlaying;
    public string currentTime;
    private bool timerCounting;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        timeCounter.text = "00:00:00";
        timerCounting = false;
    }


    public void BeginTimer()
    {
        timerCounting = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerCounting = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerCounting)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            currentTime = timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = currentTime;
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
