using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltProjectile : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private bool fired = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        if(fired)
        {
            float angleRad = Mathf.Atan2(rigidbody2d.velocity.y, rigidbody2d.velocity.x);
            float angleDeg = (180 / Mathf.PI) * angleRad - 90; // Offset by 90 Degrees

            transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        }
    }

    public void Shoot()
    {
        rigidbody2d.gravityScale = 1f;
        rigidbody2d.AddForce(transform.up * 10f, ForceMode2D.Impulse);
        fired = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        fired = false;
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.isKinematic = true;
        GetComponent<BoxCollider2D>().enabled = false;
        transform.position += transform.up * 0.15f;
    }
}
