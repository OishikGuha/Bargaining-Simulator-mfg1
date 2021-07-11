using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private int neuronsCount = 0;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>(); // Probably bad code but the jam ends in an hour
        ScoreSystem.GetInstance().StartScoreTime();
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
            neuronsCount += numNeuronsToSpawn;

            for (int i = 0; i < numNeuronsToSpawn; ++i)
            {
                float x = Random.Range(-boundsX, boundsX);
                float y = Random.Range(-boundsY, boundsY);
                
                GameObject neuronObject = Instantiate(neuronPrefab, transform);
                neuronObject.transform.position += new Vector3(x, y, 0);
                neuronObject.GetComponent<NeuronClickNotifier>().poolStick = poolStick;
            }
        }
    }

    public void NeuronDeleteNotification()
    {
        neuronsCount--;
        if (neuronsCount == 0)
        {
            ScoreSystem.GetInstance().StopScoreTime();
            ScoreSystem.GetInstance().OriginalCost = (int)originalCost;
            ScoreSystem.GetInstance().NumItems = originalItems;
            SceneManager.LoadScene(1);
        }
    }
}



