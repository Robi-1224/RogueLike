using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject[] inventoryItems;
    [SerializeField] GameObject[] purchasedItems;

    public List<Image> inventoryVisual;

    [SerializeField] Transform itemTransform;
    private LevelManager levelManager;

    private bool onlyOnce = true;
    
    // Start is called before the first frame update
    void Awake()
    {
        
        levelManager = FindAnyObjectByType<LevelManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
       StartCoroutine(InventoryCheck());
        
    }

    private IEnumerator InventoryCheck()
    {
        while (onlyOnce) {
           
            if (levelManager.purchasedList != null && onlyOnce)
            {
                for (int i = 0; i < levelManager.purchasedList.Count; i++)
                {
                    Instantiate(inventoryItems[0], itemTransform);
                    GameObject[] items = GameObject.FindGameObjectsWithTag("health potion");

                    purchasedItems = items;

                    inventoryVisual[i].GetComponent<Image>().sprite = purchasedItems[i].GetComponentInChildren<SpriteRenderer>().sprite;
                   
                }


            }

            if (onlyOnce && levelManager.permaUnlockList != null)
            {
                for (int i = 0; i < levelManager.permaUnlockList.Count; i++) {

                    Instantiate(inventoryItems[1], itemTransform);
                    GameObject[] items = GameObject.FindGameObjectsWithTag("Dash cloak");

                    purchasedItems= items;

                    inventoryVisual[3].GetComponent<Image>().sprite = purchasedItems[i].GetComponentInChildren<SpriteRenderer>().sprite;
                }
            }


            yield return null;
            onlyOnce = false;
        }
    }
}
