
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
        coinPath = Application.persistentDataPath + "/coins.save";
        inventoryPath = Application.persistentDataPath + "/inventory.save";
        levelManager = GetComponent<LevelManager>();
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
    }
}

    


          

