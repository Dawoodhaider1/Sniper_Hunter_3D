using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    //For Level Selection Panel
    public int Level_Index = 0;
    public int Selected_Level;
    public int Unlocked_Level = 0;
    public int Gun_Number;
    public int Coins;

    public float RemainingTime;

    public int[] Purchased_Guns = new int[9];
    public bool[] Purchased = new bool[9];

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //SaveUserData();
        LoadUserData();
    }

    [System.Serializable]
    class SaveData
    {
        public int Level_Index;
        public int Unlocked_Level;
        public int[] unlocked_Levels = new int[14];
        public int coins;
        public int[] purchased_Guns = new int[10];
        public bool[] purchased = new bool[10];
    }

    public void SaveUserData()
    {
        SaveData data = new SaveData();
        data.Unlocked_Level = Unlocked_Level;
        data.coins = Coins;
        //Saving the purchased Guns
        for (int i = 0; i < Purchased_Guns.Length; i++)
        {
            data.purchased_Guns[i] = Purchased_Guns[i];
        }
        for (int i = 0; i < Purchased.Length; i++)
        {
            data.purchased[i] = Purchased[i];
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadUserData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            Unlocked_Level = data.Unlocked_Level;
            Coins = data.coins;

            for (int i = 0; i < Purchased_Guns.Length; i++)
            {
                Purchased_Guns[i] = data.purchased_Guns[i];
            }
            for (int i = 0; i < Purchased.Length; i++)
            {
                Purchased[i] = data.purchased[i];
            }
        }
    }


}
