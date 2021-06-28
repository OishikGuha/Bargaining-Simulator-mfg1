using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Item
{
    public string name;
    public float cost;
    public GameObject itemObj;

    public Item(string pName, float pCost, GameObject pItemCost)
    {
        name = pName;
        cost = pCost;
        itemObj = pItemCost;
    }
}
