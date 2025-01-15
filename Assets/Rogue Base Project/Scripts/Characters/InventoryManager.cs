using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject[] inventoryItems;
    [SerializeField] GameObject[] purchasedItems;

    [SerializeField] List<Image> inventoryVisual;

    [SerializeField] Transform itemTransform;
    private LevelManager levelManager;

    private bool onlyOnce = true;
    // Start is called before the first frame update
    void Awake()
    {
        //inventoryVisual[0].sprite = inventoryItems[0].GetComponentInChildren<SpriteRenderer>().sprite;
        levelManager = FindAnyObjectByType<LevelManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
      StartCoroutine(InventoryCheck());
    }

    private IEnumerator InventoryCheck()
    {
        
        if(levelManager.purchasedList != null && onlyOnce)
        {
            for(int i= 0; i< levelManager.purchasedList.Count; i++)
            {
                Debug.Log("spawn");
                GameObject[] items = GameObject.FindGameObjectsWithTag(levelManager.purchasedList[i]);

                purchasedItems = items;

                inventoryVisual[i].GetComponent<Image>().sprite = inventoryItems[i].GetComponentInChildren<SpriteRenderer>().sprite;
            }
            onlyOnce= false;
            yield return null;
        }
       
    }
}
