using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStick : MonoBehaviour
{

    public float speed;

    public Vector2 maxBoundaries;
    public Vector2 minBoundaries;

    public Vector2 axis;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axis = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, minBoundaries.x, maxBoundaries.x), Mathf.Clamp(transform.position.y, minBoundaries.y, maxBoundaries.y));
    }

    void FixedUpdate()
    {
        rb.velocity = axis * speed;
    }
}
