using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;
    public bool Level_1;
    public bool Level_2;
    public bool Level_3;
    public bool Level_4;
    public bool Level_5;

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        Transform spawnPoint = null;

        if (Level_1)
        {
            spawnPoint = spawnPoints[0];
        }
        else if (Level_2)
        {
            spawnPoint = spawnPoints[1];
        }
        else if (Level_3)
        {
            spawnPoint = spawnPoints[2];
        }
        else if (Level_3)
        {
            spawnPoint = spawnPoints[2];
        }
        else
        {
            Debug.LogError("No spawn point available!");
            return;
        }
        playerPrefab.transform.position = spawnPoint.position;
        //Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    //This function will load the next Level when the level is Completed!
    public void NextLevel()
    {
        //Next Level Condition
    }

    //This function will make the current level to reload
    public void Retry()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    //This function will Load the Main Menu Scene
    public void MainMenu()
    {
        Application.LoadLevel("MainMenu");
    }
}
