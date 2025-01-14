using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] List<GameObject> inventoryItems;
    [SerializeField] List<Image> inventoryVisual;
    // Start is called before the first frame update
    void Start()
    {
        //inventoryVisual[0].sprite = inventoryItems[0].GetComponentInChildren<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
