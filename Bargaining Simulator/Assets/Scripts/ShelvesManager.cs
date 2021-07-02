using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelvesManager : MonoBehaviour
{

    public bool affectAllShelves;
    public List<GameObject> itemsToChooseFrom;
    
    [SerializeField]List<ShelfScript> shelves = new List<ShelfScript>();

    // Start is called before the first frame update
    void Awake()
    {
        // adds all the children (shelves) to the list
        for (int i = 0; i < transform.childCount; i++)
        {
            shelves.Add(transform.GetChild(i).GetComponent<ShelfScript>());
        }

        // checks if the manager wants to affect all shelves. if yes, it does the required stuff idk
        if(affectAllShelves)
        {
            foreach (var item in shelves)
            {
                item.itemsToChooseFrom = itemsToChooseFrom;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
