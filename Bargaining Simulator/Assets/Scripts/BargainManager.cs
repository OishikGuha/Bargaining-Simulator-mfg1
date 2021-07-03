using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BargainManager : MonoBehaviour
{

    public float originalCost;
    public float playersCost;

    float prevOriginalCost;

    // Start is called before the first frame update
    void Start()
    {
        prevOriginalCost = originalCost;
        playersCost = originalCost;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevOriginalCost != originalCost)
        {
            prevOriginalCost = originalCost;
            playersCost = originalCost;
        }
    }

    public void ReduceCost(float cost)
    {
        playersCost -= cost;
    }

    public void Confirm()
    {
        Debug.Log(originalCost);
        originalCost = playersCost;
    }
}
