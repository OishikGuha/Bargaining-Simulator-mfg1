using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BargainUI : MonoBehaviour
{

    public  BargainManager bargainManager;
    [Space]
    public Text yourCost;
    public Text originalCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // yourCost.text = bargainManager.playersCost.ToString();
        originalCost.text = bargainManager.originalCost.ToString();;
    }
}
