using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart : MonoBehaviour
{

    Player player;
    public GameObject cartItem; 

    public int minimumItemsForItemToAppear;
    
    // Start is called before the first frame update
    void Start()
    {
        cartItem.SetActive(false);
        player = transform.parent.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.items.Count > minimumItemsForItemToAppear)
        {
            cartItem.SetActive(true);
        }
    }
}
