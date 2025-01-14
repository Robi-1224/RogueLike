
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(LevelManager))]
public class SaveManager : MonoBehaviour
{
    
    private LevelManager levelManager;
    private string coinPath;
    private string inventoryPath;
    void Start()
    {
        //makes a path to your file explorer
        coinPath = Application.persistentDataPath + "/coins.save";
        inventoryPath = Application.persistentDataPath + "/inventory.save";
        levelManager = GetComponent<LevelManager>();
        LoadData();
    }


    public void SaveData()
    {
        // sets the variables from the save script to the current variables of LevelManager script
        var save = new Save()
        {
            itemIDs = levelManager.purchasedList,
            coins = levelManager.coins,
            
        };
        
        // creates a file at the file path with the current levelManager variables
        var binaryFormatter = new BinaryFormatter();

        using (var fileStream = File.Create(coinPath))
        {
            binaryFormatter.Serialize(fileStream, save);
        }

        using (var fileStream = File.Create(inventoryPath))
        {
           binaryFormatter.Serialize(fileStream, save);
        }

        Debug.Log("Saved");
    }

    public void LoadData()
    {
        if(File.Exists(coinPath) && File.Exists(inventoryPath))
        {
            //checks if the file path exists and deserializes it 
            Save save;
            var binaryFromatter = new BinaryFormatter();

            using(var fileStream = File.Open( coinPath, FileMode.Open))
            {
               save = (Save)binaryFromatter.Deserialize(fileStream);
            }

            using (var fileStream = File.Open(inventoryPath, FileMode.Open))
            {
                save = (Save)binaryFromatter.Deserialize(fileStream);
            }
            // puts the current variables to the saved ones

            levelManager.purchasedList = save.itemIDs;
            levelManager.coins = save.coins;

            Debug.Log("Loaded");
        }
        
        else
        {
            Debug.Log("Path doesnt exist");
        }


    }
}

    


          

