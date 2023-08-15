using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputs : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left Clicked!");
        }

        if(Input.GetMouseButton(1))
        {
            Debug.Log("Right Clicking");
        }

        if(Input.GetMouseButtonUp(2))
        {
            Debug.Log("Stopping to Middle Mouse Button Clicking");
        }

        if(Input.mouseScrollDelta.y != 0)
        {
            Debug.Log("Scroll Delta " + Input.mouseScrollDelta);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Position " + Input.mousePosition);
        }
    }
}
