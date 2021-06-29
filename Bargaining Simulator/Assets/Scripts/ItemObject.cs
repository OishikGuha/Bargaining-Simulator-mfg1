using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    public float minDistance;
    public float animationSpeed;

    public Item item;

    Transform player;
    bool gotPlayer;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {   
        if(Vector3.Distance(player.position, transform.position) < minDistance)
        {
            gotPlayer = true;
        }

        if(gotPlayer)
        {
            Follow();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            Equip(other.gameObject);
        }
    }

    public void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, animationSpeed * Time.deltaTime);
    }

    public void Equip(GameObject player)
    {
        player.GetComponent<Player>().Equip(gameObject);
        
        // You probably might still want to keep the object
        // around to put in the cart and to show at checkout
        Destroy(gameObject);
    }
}
