using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Level_Manager level_Manager;
    public int score = 0;
    public Text Score_Text;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        level_Manager = FindObjectOfType<Level_Manager>();
    }

    public void UpdateScore()
    {
        score += 1;
        Score_Text.text = score.ToString();
        if (score >= level_Manager.count)
        {
            StartCoroutine(Level_Completed());
        }
    }

    IEnumerator Level_Completed()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Level" + level_Manager.count + " Completed");
        Time.timeScale = 0;
    }
}
