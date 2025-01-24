using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using TMPro;
using System;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private SaveManager saveData;
    private RandomSpawns randomSpawns;

    public List<string> purchasedList;
    public List<string> permaUnlockList;

    [SerializeField] Text coinText;                     // Currency indicator.
    [SerializeField] Image healthImage;                 // Health bar.
    [SerializeField] int inventoryIndex;  
   
    public int coins = 0;                              // Amount of coins collected.
    public int amountOfEnemies;
    public int amountOfCoins;
    private int wave = 0;
    void Start()
    {
      
       Instance = this;
       saveData = GetComponent<SaveManager>();
       randomSpawns = FindAnyObjectByType<RandomSpawns>();

       amountOfCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
       amountOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
      
    }
   
    void Update()
    {
        coinText.text = coins.ToString();
        // Restart the scene when you press.
        if (amountOfCoins == 0 && amountOfEnemies == 0)
        {
            randomSpawns.Randomize();
            saveData.SaveData();
            wave++;
            amountOfCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
            amountOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        }

       


       
    }

  
}
