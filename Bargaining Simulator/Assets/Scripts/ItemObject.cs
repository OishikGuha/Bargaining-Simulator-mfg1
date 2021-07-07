using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{

    public float minDistance;
    public float animationSpeed;

    public Item item;
    public bool usingColor;
    public Color itemColor;

    Transform player;
    Player playerComponent;
    bool gotPlayer;
    bool isFollowing;

    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // gets the player transform and the main player script
        player = FindObjectOfType<Player>().gameObject.transform;
        playerComponent = player.GetComponent<Player>();

        // changes the player's color
        meshRenderer = GetComponent<MeshRenderer>();
        
        if(usingColor)
        meshRenderer.material.color = itemColor;
        // Debug.Log(renderer.material.color);
    }

    // Update is called once per frame
    void Update()
    {   
        // checks if the item matches the less than the specified distance. if yes then the item has found it's love.
        if(Vector3.Distance(player.position, transform.position) <= minDistance)
        {
            gotPlayer = true;
        }
        else
        {
            gotPlayer = false;
        }

        // if the item has gotten its player and if the player is allowing the aquiring of items then the item will start following the player until it equips  
        if(gotPlayer && playerComponent.isTakingItems)
        {
            isFollowing = true;
        }

        if (isFollowing)
        {
            Follow();
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Player")
        {
            playerComponent.Equip(gameObject);
            Destroy(gameObject);
        }
    }

    public void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, player.position, animationSpeed * Time.deltaTime);
    }
}
