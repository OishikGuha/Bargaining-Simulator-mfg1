using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Vector3 playerOffset;
    public bool isBargaining;
    public Transform bargainPoint;
    public float minDistance;
    public float speed;

    Transform player;
    ShopKeeper shopKeeper;
    bool hasSwitched;

    // Start is called before the first frame update
    void Start()
    {
        shopKeeper = FindObjectOfType<ShopKeeper>();
        player = FindObjectOfType<Player>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        isBargaining = shopKeeper.bargainIsOn;
        if(!isBargaining)
        {
            transform.position = new Vector3(player.position.x, 0f, player.position.z) - playerOffset;
            transform.rotation = Quaternion.Euler(60.2f, 0f, 0f);
        }
        else
        {
            BargainPointSwitch();
        }
    }

    public void BargainPointSwitch()
    {
        // if(!(Vector3.Distance(transform.position, bargainPoint.position) < minDistance))
        // {
            transform.position = Vector3.Lerp(transform.position, bargainPoint.position, Time.deltaTime * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, bargainPoint.rotation, Time.deltaTime * speed);
        // }
    }
}
