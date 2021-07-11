using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStick : MonoBehaviour
{
    public Camera camera;
    public SpriteRenderer texture;
    public Vector2 pushForce;
    public float pushBackMaxLength = 1f;
    public float pushBackMinLength = 0.2f;
    public float pushBackMaxShowLength = 0.2f;
    
    private Rigidbody2D currentRigidbody = null;
    private Vector2 pushBegin;
    private bool isPushing = false;

    // Update is called once per frame
    void Update()
    {
        if (currentRigidbody != null)
        {
            texture.enabled = true;

            Vector3 mouseScreenPos = Input.mousePosition;
            mouseScreenPos.z = camera.nearClipPlane;
            Vector3 mousePosition = camera.ScreenToWorldPoint(mouseScreenPos);

            Vector2 shootDirection = (Vector2) mousePosition - currentRigidbody.position;
            shootDirection.Normalize();

            transform.position = shootDirection * -1.25f + currentRigidbody.position;
            float angle = Mathf.Atan2(shootDirection.y, shootDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            if (Input.GetMouseButton(0) && !isPushing)
            {
                isPushing = true;
                pushBegin = mousePosition;
            }
            else if (Input.GetMouseButton(0) && isPushing)
            {
                Vector2 shootDirectionClamped = Vector2.ClampMagnitude((Vector2) mousePosition - currentRigidbody.position, pushBackMaxLength);
                
                Vector2 distanceMultiplierVector = shootDirectionClamped;
                if (distanceMultiplierVector.x > 0)
                    distanceMultiplierVector.x += 1f;
                else
                    distanceMultiplierVector.x -= 1f;
                if (distanceMultiplierVector.y > 0)
                    distanceMultiplierVector.y += 1f;
                else
                    distanceMultiplierVector.y -= 1f;

                float distanceMultiplier = -Mathf.Lerp(0f, pushBackMaxShowLength, shootDirectionClamped.magnitude);
                
                transform.position = shootDirection * (-1.25f + distanceMultiplier) + currentRigidbody.position;
                Debug.Log(shootDirectionClamped);
                Debug.Log(shootDirectionClamped.magnitude);
                Debug.Log(distanceMultiplier);
                Debug.Log(Mathf.Lerp(0f, 2f, 0.5f));
            }
            else if (!Input.GetMouseButton(0) && isPushing)
            {
                Vector2 shootDirectionClamped = Vector2.ClampMagnitude((Vector2) mousePosition - currentRigidbody.position, pushBackMaxLength);
                currentRigidbody.AddForce(pushForce * shootDirectionClamped);

                texture.enabled = false;
                isPushing = false;
                currentRigidbody = null;
            }
        }
    }

    public void ObjectClickNotification(Rigidbody2D rigidbody)
    {
        if (currentRigidbody == null)
        {
            currentRigidbody = rigidbody;
        }
    }
}
