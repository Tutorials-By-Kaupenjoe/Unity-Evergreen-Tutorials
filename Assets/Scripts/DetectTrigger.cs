using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered Trigger Area!");
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("Staying in Trigger Area!");
    }
}
