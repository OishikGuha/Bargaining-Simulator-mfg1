using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : MonoBehaviour
{

    public KeyCode bargainKey;
    public float minDistance = 5f;

    public bool bargainIsOn;
    public bool bargainAllowed;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Vector3.Distance(player.transform.position, transform.position) < minDistance)
            bargainAllowed = true;
        else
            bargainAllowed = false;
            

        if(Input.GetKeyDown(bargainKey) && bargainAllowed)
        {
            bargainIsOn = !bargainIsOn; 
        }        

        player.ToggleBargain(bargainIsOn);
    }

    public void Confirm()
    {    
        bargainIsOn = false;
    }
}
