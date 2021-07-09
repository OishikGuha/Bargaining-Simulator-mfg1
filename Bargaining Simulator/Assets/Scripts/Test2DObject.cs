using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2DObject : MonoBehaviour
{

    public float force;
    public Vector2 direction;
    public float delay;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("AddingForce");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AddingForce()
    {
        rb.AddForce(direction * force * Time.deltaTime);
        yield return new WaitForSeconds(delay);
        StartCoroutine("AddingForce");
    }
}
