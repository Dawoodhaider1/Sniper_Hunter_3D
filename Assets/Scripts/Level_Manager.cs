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
    public Text[] LevelNumber;
    public Text[] LevelTarget;
    int RandAnimal;
    public int count;
    public List<string> Name = new List<string>();
    Dictionary<string, int> countDict = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();

        TargetAnimals();
    }

    IEnumerator LevelData()
    {
        for(int i = 0; i < count; i++)
        {
            LevelNumber[i].text = "Level " + count;
            LevelTarget[i].text = "Find and Kill a " + string.Join(", ", Name)/*Animals[RandAnimal]*/;
            LevelNumber[i].enabled = true;
            LevelTarget[i].enabled = true;
            yield return new WaitForSeconds(3f);
            LevelNumber[i].enabled = false;
            LevelTarget[i].enabled = false;
        }
    }

    public void TargetAnimals()
    {
        count = Tasks[0]; //here [0] is the level count...
        for (int i = 0; i < count; i++)
        {
            RandAnimal = Random.Range(0, Animals.Length);
            Name.Add(Animals[RandAnimal]);
            StartCoroutine(LevelData());
        }
    }
}
