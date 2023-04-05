using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager : MonoBehaviour
{
    public SpawnManager spawnManager;
    public GameObject[] Levels;
    public int[] Tasks;
    public string[] Animals;
    public GameObject[] Animals_GameObjects;
    public GameObject[] Level_Text;
    public Text[] LevelNumber;
    public Text[] LevelTarget;
    public Text Level_Information;
    int RandAnimal;
    public int count;
    public int CurrentLevelNumber;
    public List<string> Name = new List<string>();
    public List<GameObject> AnimalGameObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        CurrentLevelNumber = GameManager.Instance.Selected_Level + 1;
        TargetAnimals();
    }

    IEnumerator LevelData()
    {
        for(int i = 0; i < count; i++)
        {
            //Text Game Objects set active...
            Level_Text[i].SetActive(true);
            LevelNumber[i].text = "Level " + CurrentLevelNumber;
            LevelTarget[i].text = "Find and Kill " + string.Join(", ", Name) + " !";
            //Information Button set...
            Level_Information.text = LevelTarget[i].text;
            //Level Information enabled for few seconds at the start of each level...
            LevelNumber[i].enabled = true;
            LevelTarget[i].enabled = true;
            yield return new WaitForSeconds(5f);
            //LevelNumber[i].enabled = false;
            //LevelTarget[i].enabled = false;
            ////Text game Objects set inactive...
            //Level_Text[i].SetActive(false);
        }
    }

    public void TargetAnimals()
    {
        count = Tasks[GameManager.Instance.Selected_Level]; //here [xyz] is the level count...
        for (int i = 0; i < count; i++)
        {
            RandAnimal = Random.Range(0, Animals.Length);
            Name.Add(Animals[RandAnimal]);
            AnimalGameObjects.Add(Animals_GameObjects[RandAnimal]);
            foreach (GameObject animals in AnimalGameObjects)
            {
                animals.SetActive(true);
            }
            StartCoroutine(LevelData());
        }
    }
}
