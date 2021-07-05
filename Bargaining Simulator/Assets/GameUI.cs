using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

    public Text itemsAcquired;
    public Text amountBargained;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        itemsAcquired.text = $"Items Acquired: {GameManager.itemsAcquired.ToString()}";
        amountBargained.text = $"Amount Bargained: {GameManager.scoreBargain.ToString()}";
    }
}
