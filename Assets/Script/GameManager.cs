using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("StopWatch")]
    public float timeLimit;
    private float stopwatchTime;
    public TMP_Text timeDisplay;

    [Header("Points")]
    public TMP_Text pointDisplay;
    public int points;

    private void Update()
    {
        UpdateStopwatch();
        UpDatePoint();
    }

    void UpdateStopwatch()
    {
        stopwatchTime += Time.deltaTime;
        UpdateStopwatchDisplay();

        if (stopwatchTime >= timeLimit)
        {
            Time.timeScale = 0f ;
        }
    }
    void UpdateStopwatchDisplay()
    {
        int minutes = Mathf.FloorToInt(stopwatchTime / 60);
        int seconds = Mathf.FloorToInt(stopwatchTime % 60);

        timeDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void UpDatePoint()
    {
        pointDisplay.text = points.ToString();
    }

}
