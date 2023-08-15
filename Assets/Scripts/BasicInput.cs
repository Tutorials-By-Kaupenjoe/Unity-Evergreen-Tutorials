using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicInput : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Called once when the key is pressed down
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Pressed Y");
        }

        // Continues to be true while the key is being pressed
        if (Input.GetKey(KeyCode.X))
        {
            Debug.Log("Pressing X");
        }

        // Called once when the key is stopped being pressed down
        if (Input.GetKeyUp(KeyCode.Z))
        {
            Debug.Log("Stopped Pressing Z");
        }

        if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Cancel Button was pressed");
        }

        if(Input.anyKey)
        {
            Debug.Log("Any Key is being pressed!");

            Debug.Log("This was the last pressed key " + Input.inputString);

            Debug.Log(Input.GetAxis("Horizontal"));
            Debug.Log(Input.GetAxis("Vertical"));
        }
    }
}
