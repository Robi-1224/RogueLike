using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public string itemID;
    public bool used;
    public Sprite sprite;

    private void Awake()
    {
        sprite = GetComponent<Sprite>();
    }
}
