using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfScript : MonoBehaviour
{

    public GameObject item;

    public List<Transform> itemSpawnPoints;

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
        for (int i = 0; i < itemSpawnPoints.Count; i++)
        {
            GameObject instObj = Instantiate(item, itemSpawnPoints[i].position, Quaternion.identity, transform);
            instObj.transform.localScale = Vector3.one * 0.004444444f;
        }
    }
}
