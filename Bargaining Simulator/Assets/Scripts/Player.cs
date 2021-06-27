using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public List<Item> items;
    public KeyCode jumpKey;
    public float jumpForce;

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

        if(Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(new Vector3(0f, Time.deltaTime * jumpForce, 0f));
        }
    }

    private void FixedUpdate() 
    {
        rb.AddForce(new Vector3(horizontal, 0f, vertical).normalized * speed);
    }

    public void Equip(GameObject item)
    {
        items.Add(item.GetComponent<Item>());
    }
}
