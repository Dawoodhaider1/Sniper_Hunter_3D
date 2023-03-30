using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GunSelection : MonoBehaviour
{
    public GameObject[] Guns;
    public GameObject Guns_GameObject;
    public GameObject Buy_Button;
    public GameObject Select_Button;
    public GameObject[] Purchase_Texts;
    public GameObject NotEnoughMoney;
    public int[] Prices;
    public int currentGun = 0;
    public GameObject[] stats;
    public int Stats = 0;

    //public bool[] purchased = new bool[4];
    public int[] purchased_Guns = new int[9];

    void Start()
    {
        Guns_GameObject.SetActive(true);
        for (int j = 0; j < 9; j++)
        {
            if (GameManager.Instance.Purchased_Guns[j] != 0)
            {
                Buy_Button.SetActive(false);
                Select_Button.SetActive(true);
            }
            else
            {
                Buy_Button.SetActive(true);
                Select_Button.SetActive(false);
            }
        }
        ShowGun();
    }

    void Update()
    {
        for (int j = 0; j < 9/*MainManager.Instance.Purchased_Bikes.Length*/; j++)
        {
            if (currentGun > 0 && GameManager.Instance.Purchased[currentGun - 1] == false && GameManager.Instance.Purchased_Guns[j] == 0)
            {
                Buy_Button.SetActive(true);
                Select_Button.SetActive(false);

                for (int i = 0; i < Purchase_Texts.Length; i++)
                {
                    if (i == currentGun - 1)
                    {
                        Purchase_Texts[i].SetActive(true);
                    }
                    else
                    {
                        Purchase_Texts[i].SetActive(false);
                    }
                }
            }
            else
            {
                Buy_Button.SetActive(false);
                Select_Button.SetActive(true);
            }
        }
    }

    public void Left_Gun()
    {
        currentGun--;
        Stats--;
        if (currentGun < 0 && Stats < 0)
        {
            currentGun = Guns.Length - 1;
            Stats = Guns.Length - 1;
        }
        ShowGun();
    }

    public void Right_Gun()
    {
        currentGun++;
        Stats++;
        if (currentGun == Guns.Length && Stats == Guns.Length)
        {
            currentGun = 0;
            Stats = 0;
        }
        ShowGun();
    }

    void ShowGun()
    {
        for (int i = 0; i < Guns.Length; i++)
        {
            if (i == currentGun && i == Stats)
            {
                Guns[i].SetActive(true);
                stats[i].SetActive(true);
                GameManager.Instance.Gun_Number = currentGun;
                Debug.Log("Current Active Gun is: " + currentGun);
            }
            else
            {
                Guns[i].SetActive(false);
                stats[i].SetActive(false);
            }
        }
    }

    public void Purchase_Gun()
    {
        PurchasedGun();
    }

    public void PurchasedGun()
    {
        if (GameManager.Instance.Coins >= Prices[currentGun - 1])
        {
            GameManager.Instance.Coins -= Prices[currentGun - 1];
            for (int i = 0; i <= GameManager.Instance.Purchased_Guns.Length; i++)
            {
                if (i == currentGun)
                {
                    GameManager.Instance.Purchased_Guns[i - 1] = currentGun;
                }
            }
            purchased_Guns[currentGun - 1] = currentGun;
            Scene_Manager.FindObjectOfType<Scene_Manager>().Coins_Text.text = GameManager.Instance.Coins.ToString();
            GameManager.Instance.Purchased[currentGun - 1] = true;
            //purchased[currentBike - 1] = true;
            GameManager.Instance.SaveUserData();
        }
        else
        {
            Guns_GameObject.SetActive(false);
            NotEnoughMoney.SetActive(true);
        }
    }
}
