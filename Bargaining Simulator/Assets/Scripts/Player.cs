using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed = 10f;
    public List<Item> items;
    public KeyCode jumpKey;
    public float jumpForce;
    [Space]
    [Tooltip("must be particles")]public ParticleSystem playerTrail;
    public bool isMoving;
    public float currentSpeed;

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
        // horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        
        LookAtMouse();

        // jumping
        if(Input.GetKeyDown(jumpKey))
        {
            rb.AddForce(new Vector3(0f, Time.deltaTime * jumpForce, 0f));
        }

        // setting the speed
        currentSpeed = rb.velocity.magnitude;

        // checks if the player is moving
        if(currentSpeed > 1f)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        UseTrail();
    }

    private void FixedUpdate() 
    {
        // rb.angularVelocity = Vector3.up * horizontal * rotationSenstivity;

        rb.AddRelativeForce(new Vector3(horizontal, 0f, vertical) * speed);
    }

    public void Equip(GameObject item)
    {
        items.Add(item.GetComponent<ItemObject>().item);
        
        // Put in cart logic
    }

    public void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(plane.Raycast(ray, out rayLength))
        {
            Vector3 pointToLook = ray.GetPoint(rayLength);
            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    public void UseTrail()
    {
        if(isMoving && !playerTrail.isPlaying)
        {
            playerTrail.Play();
        }
        else if(!isMoving && playerTrail.isPlaying)
        {
            playerTrail.Stop();
        }
    }
}
