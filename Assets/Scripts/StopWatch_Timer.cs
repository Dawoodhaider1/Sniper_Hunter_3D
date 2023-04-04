using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopWatch_Timer : MonoBehaviour
{
    public float startTime = 60f;
    public Text timerText;
    public GameObject losePanel;
    public Button retryButton;

    private float currentTime;
    private bool isRunning = false;

    private void Start()
    {
        currentTime = startTime;
        timerText.text = FormatTime(currentTime);
    }

    private void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;
            timerText.text = FormatTime(currentTime);

            if (currentTime <= 0f)
            {
                isRunning = false;
                currentTime = 0f;
                timerText.text = "00:00";
                losePanel.SetActive(true);
            }
        }
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void ResetTimer()
    {
        currentTime = startTime;
        timerText.text = FormatTime(currentTime);
        losePanel.SetActive(false);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void OnEnable()
    {
        retryButton.onClick.AddListener(ResetTimer);
    }

    private void OnDisable()
    {
        retryButton.onClick.RemoveListener(ResetTimer);
    }
}
