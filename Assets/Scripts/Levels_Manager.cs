using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels_Manager : MonoBehaviour
{
    [SerializeField] private Button[] Level_buttons;
    [SerializeField] private GameObject[] Level_Locks;

    void Update()
    {
        GameManager.Instance.Unlocked_Level = GameManager.Instance.Selected_Level;
        for (int i = 0; i < GameManager.Instance.Unlocked_Level; i++)
        {
            Level_Locks[i].SetActive(false);
            Level_buttons[i].interactable = true;
        }
    }
}
