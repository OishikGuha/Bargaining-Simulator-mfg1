using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{

    public Player player;
    [Space]
    public TextMeshProUGUI countText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MakeText();
    }

    void MakeText()
    {
        // cancels the rotation of the text
        countText.transform.rotation = Quaternion.identity;
        
        // gives the text the amount of items the player has
        countText.text = player.items.Count.ToString();        
    }
}
