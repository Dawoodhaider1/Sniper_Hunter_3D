using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

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

}
