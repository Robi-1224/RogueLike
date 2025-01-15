using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour
{
    [SerializeField] int price = 0;
    [SerializeField] string itemName;
    [SerializeField] GameObject shopPanel;
    private LevelManager levelManager;
    private SaveManager saveManager;
    // Start is called before the first frame update
    void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
        saveManager= FindAnyObjectByType<SaveManager>();
    }

    
    
    public void PurchaseButton()
    {
        

       //for the health potions
        if (levelManager.coins >= price && levelManager.purchasedList.Count !=3 && itemName =="health potion")
        {
            levelManager.coins -= price;
            levelManager.purchasedList.Add(itemName);
            saveManager.SaveData();
            Debug.Log("Purchased");
        }
        //for the perma unlocked gear
        else if(itemName != "health potion")
        {
            levelManager.coins -= price;
            levelManager.permaUnlockList.Add(itemName);
            saveManager.SaveData();
            Debug.Log("purchased");
        }
        else
        {
            Debug.Log("not enough");
        }

        
    }

    // button interactions
    public void BackToMenuButton()
    {
        shopPanel.SetActive(false);
    }

    public void OpenShopButton()
    {
        shopPanel.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Template Scene");
    }
}
