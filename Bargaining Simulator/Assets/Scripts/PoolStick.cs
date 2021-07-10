using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolStick : MonoBehaviour
{
    public Camera camera;
    public SpriteRenderer texture;
    public Vector2 pushForce;
    public float pushBackMaxLength = 1f;
    
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

            if (Input.GetMouseButton(0))
            {
                isPushing = true;
                Vector2 shootDirectionClamped = Vector2.ClampMagnitude((Vector2) mousePosition - currentRigidbody.position, pushBackMaxLength);
                transform.position = shootDirection * (-1.25f * (shootDirectionClamped + Vector2.one)) + currentRigidbody.position;
                Debug.Log(shootDirectionClamped);
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
