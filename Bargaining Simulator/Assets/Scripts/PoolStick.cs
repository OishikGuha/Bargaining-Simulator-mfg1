using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStick : MonoBehaviour
{

    public float speed;

    public Vector2 maxBoundaries;
    public Vector2 minBoundaries;

    public Camera camera;
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = camera.nearClipPlane;
        Vector3 worldPosition = camera.ScreenToWorldPoint(mousePos);
        rb.MovePosition(worldPosition);
    }

    void FixedUpdate()
    {
    }
}
