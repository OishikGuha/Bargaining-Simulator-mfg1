using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BargainManager : MonoBehaviour
{

    public float originalCost;
    // public float playersCost;
    public int numberOfActions;
    public int minNumberOfActionsforTheActionHelpThisVariableNameIsTooBigAAAAA;
    public GameObject UI;
    public ShopKeeper shopKeeper;
    [Header("Shopkeeper Settings")]
    public float shopKeeperDelay;
    public int minRandomCost;
    public int maxRandomCost;
    public float reduceCostCooldown;

    float prevOriginalCost;
    bool canReduceCost;
    float cost;

    // Start is called before the first frame update
    void Start()
    {
        // playersCost = originalCost;
    }

    void OnEnable()
    {
        prevOriginalCost = originalCost;
        StartCoroutine("AddShopKeeperCost");
    }

    // Update is called once per frame
    void Update()
    {
        if(canReduceCost == false)
        {
            StartCoroutine("ReduceCostCooldown", cost);
        }
    }

    public void ReduceCost(float pCost)
    {
        if(canReduceCost)
        {
            numberOfActions++;
            cost = pCost;
            originalCost -= cost;
            canReduceCost = false;

            // this one sets the score
            GameManager.scoreBargain = prevOriginalCost - originalCost;
        }
    }

    public IEnumerator AddShopKeeperCost()
    {
        for (;;)
        {
            float costDistance = prevOriginalCost - originalCost;
            if(costDistance > 0)
            {
                float randomCost = costDistance/2;
                originalCost += randomCost;
            }

            yield return new WaitForSeconds(shopKeeperDelay);
        }
    }

    public IEnumerator ReduceCostCooldown(float delayExtra)
    {
        yield return new WaitForSeconds(shopKeeperDelay + delayExtra);
        canReduceCost = true;
    }
}

