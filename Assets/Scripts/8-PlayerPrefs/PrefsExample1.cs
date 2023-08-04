using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsExample1 : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Saving PlayerPrefs");
            PlayerPrefs.SetFloat("speed", playerMovement.speed);
        }

        if(Input.GetKeyDown(KeyCode.L)) 
        {
            playerMovement.speed = PlayerPrefs.GetFloat("speed", 3);
            Debug.Log("Loading PlayerPrefs");
        }
    }
}
