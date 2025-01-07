
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[RequireComponent(typeof(LevelManager))]
public class SaveManager : MonoBehaviour
{
    
    private levelma levelManager;
    private string coinPath;
    private string inventoryPath;
    void Start()
    {
        coinPath = Application.persistentDataPath + "/coins.save";
        inventoryPath = Application.persistentDataPath + "/inventory.save";
        levelManager = GetComponent<leve>();
    }


    public void SaveData()
    {
        var save = new Save()
        {
            itemIDs = levelManager.inventory,
            coins = levelManager.coins,
        };


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
        if(File.Exists(coinPath))
        {
            Save save;
            var binaryFromatter = new BinaryFormatter();

            using(var fileStream = File.Open(coinPath, FileMode.Open))
            {
               save = (Save)binaryFromatter.Deserialize(fileStream);
            }


            levelManager.inventory = save.itemIDs;
            levelManager.coins = save.coins;

            Debug.Log("Loaded");
        }
        else
        {
            Debug.Log("Path doesnt exist");
        }


    }
}

    


          

