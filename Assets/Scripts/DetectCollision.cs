using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision Started! " + collision.collider.name);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Collision Continuing! " + collision.collider.name);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("Collision Stopping! " + collision.collider.name);
    }
}
