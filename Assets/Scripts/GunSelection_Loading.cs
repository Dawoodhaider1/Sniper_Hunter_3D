using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunSelection_Loading : MonoBehaviour
{
    public Slider loadingSlider;
    public float loadingTime = 5f;

    private int sceneIndex;

    private void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(Loading());
    }

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
        if(sceneIndex == 1)
        {
            Application.LoadLevel("GunSelection");
        }
        else
        {
            SceneManager.LoadScene("GamePlay");
        }
        // Do something after the loading is complete, such as loading the next scene or enabling the game controls.
    }
}
