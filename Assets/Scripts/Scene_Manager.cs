using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene_Manager : MonoBehaviour
{
    public Text Coins_Text;
    public AudioSource Menu_BG_Audio;
    public AudioSource ClickSound;
    //public TimerStopwatch stopwatch;

    private void Start()
    {
        Menu_BG_Audio.Play();
        Coins_Text.text = GameManager.Instance.Coins.ToString();
        Time.timeScale = 1;
        //stopwatch = FindObjectOfType<TimerStopwatch>();
        //stopwatch.timeRemaining = 30f;
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Exit from Game !");
    }

    public void SoundsOn()
    {
        AudioListener.volume = 1;
        Debug.Log("Sounds On !");
    }

    public void SoundsOff()
    {
        AudioListener.volume = 0;
        Debug.Log("Sounds Off !");
    }

    public void MoreGames()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=5360866347787636750");
    }

    public void NoAds()
    {
        Application.OpenURL("https://play.google.com/store/apps/dev?id=5360866347787636750");
    }

    public void Main_Menu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void GamePlay()
    {
        Application.LoadLevel("GamePlay");
    }

    public void ClickSounds()
    {
        ClickSound.Play();
    }
}
