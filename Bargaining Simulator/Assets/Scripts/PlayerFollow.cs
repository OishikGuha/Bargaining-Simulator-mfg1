using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    public Vector3 playerOffset;
    public Vector3 bargainOffset;
    public bool isBargaining;
    public Transform bargainPoint;
    public float bargainMinDistance;
    public float playerMinDistance;
    public float speed;
    public float speedDampening;
    public Vector3 clampPoint;

    Transform player;
    ShopKeeper shopKeeper;
    bool hasSwitched;

    float speedMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        shopKeeper = FindObjectOfType<ShopKeeper>();
        player = FindObjectOfType<Player>().transform;
    }

    void Update()
    {
        speedMultiplier = Vector3.Distance(player.position, new Vector3(player.position.x, player.position.y, 0f)) / speedDampening;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        isBargaining = shopKeeper.bargainIsOn;
        
        if(!isBargaining)
        {
            PlayerPointSwitch();
        }
        else
        {
            BargainPointSwitch();
        }
    }

    public void BargainPointSwitch()
    {
        if(!(Vector3.Distance(transform.position, bargainPoint.position - bargainOffset) < bargainMinDistance))
        {
            transform.position = Vector3.Lerp(transform.position, bargainPoint.position - bargainOffset, Time.deltaTime * speed);
            transform.rotation = Quaternion.Lerp(transform.rotation, bargainPoint.rotation, Time.deltaTime * speed);
        }
    }

    public void PlayerPointSwitch()
    {
        
        transform.position = Vector3.Lerp(transform.position, player.position - playerOffset, Time.deltaTime * speed * speedMultiplier);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(60.2f,0f, 0f), Time.deltaTime * speed);

        if (transform.position.z < clampPoint.z)
        {
            Vector3 newPos = transform.position;
            newPos.z = clampPoint.z;
            transform.position = newPos;
        }
    }
}
