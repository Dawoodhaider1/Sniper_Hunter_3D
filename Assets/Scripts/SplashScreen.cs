using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour
{
    public Slider loadingSlider;
    public float loadingTime = 5f;

    public GameObject LevelSelectionPanel;
    public GameObject LoadingScreen;

    public GameObject CoinBar;
    public GameObject SettingsButton;

    //private void Start()
    //{
    //    StartCoroutine(Loading());
    //}

    private IEnumerator Loading()
    {
        float progress = 0f;

        while (progress < loadingTime)
        {
            progress += Time.deltaTime;
            loadingSlider.value = progress / loadingTime;
            yield return null;
        }

        yield return new WaitForSeconds(1.5f);

        Scene activeScene = SceneManager.GetActiveScene();
        int sceneNumber = activeScene.buildIndex;

        if (sceneNumber == 1)
        {
            LevelSelectionPanel.SetActive(true);
            LoadingScreen.SetActive(false);
            CoinBar.SetActive(true);
            SettingsButton.SetActive(true);

        }
        else if (sceneNumber == 0)
        {
            Application.LoadLevel("MainMenu");
        }
        // Do something after the loading is complete, such as loading the next scene or enabling the game controls.
    }

    public void Loading_Bar()
    {
        StartCoroutine(Loading());
    }
}
