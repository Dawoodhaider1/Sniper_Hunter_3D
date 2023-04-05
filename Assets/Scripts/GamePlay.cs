using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public static GamePlay Instance;

    public Level_Manager level_Manager;

    public int Reward;
    public int Bonus;
    public int Total;
    public int score = 0;
    public Text Score_Text;

    public Text Level_Reward;
    public Text Bonus_Reward;
    public Text Total_Reward;

    public GameObject WinPanel;
    public GameObject PauseMenu;

    public GameObject MiniMap;
    public GameObject Player;

    //public MonoBehaviour Controls;

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

    // Start is called before the first frame update
    private void Start()
    {
        level_Manager = FindObjectOfType<Level_Manager>();
        //GameManager.Instance.RemainingTime = 30f;
    }

    public void UpdateScore()
    {
        //kill score...
        score += 1;
        Score_Text.text = score.ToString();
        //coins addition...
        Reward = Random.Range(200, 500);
        Bonus = Reward + Random.Range(100, 200);
        Total = Reward + Bonus;
        //Reward Display...
        Level_Reward.text = Reward.ToString();
        Bonus_Reward.text = Bonus.ToString();
        Total_Reward.text = Total.ToString();
        //Coins Update...
        GameManager.Instance.Coins += Total;
        GameManager.Instance.SaveUserData();

        if (score >= level_Manager.count)
        {
            StartCoroutine(Level_Completed());
        }
    }

    IEnumerator Level_Completed()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("Level" + level_Manager.count + " Completed");
        MiniMap.SetActive(false);
        Player.SetActive(false);
        WinPanel.SetActive(true);
    }

}
