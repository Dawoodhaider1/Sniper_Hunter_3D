using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Selection : MonoBehaviour
{
    public GameObject[] Levels;
    public GameObject[] Level_Locks;

    private int Level_Number = -1;

    // Start is called before the first frame update
    void Start()
    {
        for (int j = 0; j < GameManager.Instance.Unlocked_Level; j++)
        {
            Level_Locks[j].SetActive(false);
        }
        // Add a listener to each item that sets the selectedItem value when clicked
        for (int i = 0; i < Level_Locks.Length; i++)
        {
            if (Level_Locks[i].activeSelf == true)
            {
                int levelNumber = i;
                Levels[i + 1].GetComponent<Button>().interactable = false;
            }
            //else
            //{
            //    int levelNumber = i;
            //    Levels[i].GetComponent<Button>().onClick.AddListener(() => SetSelectedItem(levelNumber));
            //}
        }

        for (int k = 0; k < Levels.Length; k++)
        {
            int LevelNumber = k;
            Levels[k].GetComponent<Button>().onClick.AddListener(() => SetSelectedItem(LevelNumber));
        }
    }

    // This function sets the selectedItem value to the number of the item that was clicked
    void SetSelectedItem(int itemNumber)
    {
        Level_Number = itemNumber;
        GameManager.Instance.Selected_Level = Level_Number;
        GameManager.Instance.Level_Index = GameManager.Instance.Selected_Level;
        //Debug.Log("Selected Level is: " + Level_Number);
    }
}
