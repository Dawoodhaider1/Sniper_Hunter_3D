using UnityEngine;
using UnityEngine.UI;

public class TimerStopwatch : MonoBehaviour
{
    public Text timerText;
    public GameObject LevelFailedPanel;
    private float startTime = 60f;

    void Update()
    {
        float timeRemaining = startTime - Time.time;
        if (timeRemaining < 0)
        {
            timeRemaining = 0;
            Debug.Log("Level Failed !");
            Time.timeScale = 0;
            LevelFailedPanel.SetActive(true);
        }
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = formattedTime;
    }
}