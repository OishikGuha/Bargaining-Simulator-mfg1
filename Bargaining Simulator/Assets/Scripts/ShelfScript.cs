using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{
    public List<GameObject> itemsToChooseFrom;

    public List<Transform> itemSpawnPoints;
    public List<Item> items = new List<Item>();

    public bool manuallyGenerate;

    // Start is called before the first frame update
    void Start()
    {
        GenerateItems();
    }

    // Update is called once per frame
    void Update()
    {
        if (manuallyGenerate)
        {
            GenerateItems();
            manuallyGenerate = false;
        }
    }
    
    public void GenerateItems()
    {
        items.Clear();
        for (int i = 0; i < itemSpawnPoints.Count; i++)
        {
            GameObject chosenItem = itemsToChooseFrom[Random.Range(0, itemsToChooseFrom.Count)];
            items.Add(new Item(i.ToString(), chosenItem.GetComponent<ItemObject>().item.cost, chosenItem));
            
            GameObject instObj = Instantiate(items[i].itemObj, itemSpawnPoints[i].transform.position, Quaternion.identity, transform);
            instObj.transform.localScale = Vector3.one * 0.004444444f;
        }
    }
}
