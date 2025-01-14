using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] int price = 0;
    [SerializeField] string itemName;
    [SerializeField] GameObject shopPanel;
    private LevelManager levelManager;
    private SaveManager saveManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
        saveManager= FindAnyObjectByType<SaveManager>();
    }

    
    
    public void PurchaseButton()
    {
        

       
        if (levelManager.coins >= price && levelManager.purchasedList.Count !=3)
        {
            levelManager.coins -= price;
            levelManager.purchasedList.Add(itemName);
            saveManager.SaveData();
            Debug.Log("Purchased");
        }
        else
        {
            Debug.Log("not enough");
        }
    }

    public void BackToMenuButton()
    {
        shopPanel.SetActive(false);
    }

    public void OpenShopButton()
    {
        shopPanel.SetActive(true);
    }
}
