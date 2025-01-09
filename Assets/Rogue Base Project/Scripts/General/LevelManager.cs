using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private SaveManager saveData;

    [SerializeField] Text coinText;                     // Currency indicator.
    [SerializeField] Image healthImage;                 // Health bar.
    [SerializeField] int inventoryIndex;  
    
    public List<string> inventory;
   
    public int coins = 0;                              // Amount of coins collected.

 
    void Awake()
    {
       Instance = this;
       saveData = GetComponent<SaveManager>();
       
    }
   
    void Update()
    {
       
        // Restart the scene when you press.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            saveData.SaveData();
        }
    }

    private void InventorySystem()
    {
       
    }
}
