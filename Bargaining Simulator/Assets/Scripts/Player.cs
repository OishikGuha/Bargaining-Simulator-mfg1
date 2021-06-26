using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public List<GameObject> items;

    Rigidbody rb;
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate() 
    {
        rb.velocity = new Vector3(horizontal * speed, 0f, vertical * speed);    
    }

    public void Equip(GameObject item)
    {
        items.Add(item);
    }
}
