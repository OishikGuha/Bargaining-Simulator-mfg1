using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemListClass
{
    public string name;
    public float cost;
    public GameObject itemObj;

    public ItemListClass(string pName, float pCost, GameObject pItemCost)
    {
        name = pName;
        cost = pCost;
        itemObj = pItemCost;
    }
}
