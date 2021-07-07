using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public Text itemsAquired;
    public Text amountBargained;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemsAquired.text = $"Items Aquired: {GameManager.itemsAquired.ToString()}";
        amountBargained.text = $"Amount Bargained: {GameManager.scoreBargain.ToString()}";
    }
}
