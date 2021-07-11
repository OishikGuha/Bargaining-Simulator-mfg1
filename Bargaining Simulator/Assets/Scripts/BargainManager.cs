using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BargainManager : MonoBehaviour
{
    public float boundsX;
    public float boundsY;
    public GameObject neuronPrefab;
    public PoolStick poolStick;
    
    internal float originalCost;
    private float newCost;
    private int originalItems = 0;
    private int originalNeuronCount = 0;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); // Probably bad code but the jam ends in an hour
    }

    void Update()
    {
        if (player.items.Count > originalItems)
        {
            originalItems = player.items.Count;
            
            foreach (var item in player.items)
                originalCost += item.cost;
        
            newCost = originalCost;

            int numNeuronsToSpawn;
            if (originalCost > 100)
                numNeuronsToSpawn = (int) originalCost / 100 + 10;
            else if (originalCost > 10)
                numNeuronsToSpawn = (int) originalCost / 10 + 5;
            else
                numNeuronsToSpawn = (int) originalCost;
            numNeuronsToSpawn -= originalNeuronCount;

            for (int i = 0; i < numNeuronsToSpawn; ++i)
            {
                float x = Random.Range(-boundsX, boundsX);
                float y = Random.Range(-boundsX, boundsY);
                Transform newTransform = transform;
                newTransform.parent = transform;
                newTransform.position += (Vector3) new Vector2(x, y);
                GameObject neuronObject = Instantiate(neuronPrefab, transform);
                neuronObject.GetComponent<NeuronClickNotifier>().poolStick = poolStick;
            }
        }
    }
}



