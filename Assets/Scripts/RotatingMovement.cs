using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private Transform rotateAround;

    private bool autoRotate = false;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R)) 
        {
            this.transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.Q)) 
        {
            this.transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }

        
        if(Input.GetKey(KeyCode.A)) 
        {
            this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.D))
        {
            this.transform.RotateAround(rotateAround.position, Vector3.forward, -rotationSpeed * Time.deltaTime);
        }

       
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ToggleAutoRotation();
        }

        if (autoRotate)
        {
            this.transform.RotateAround(rotateAround.position, Vector3.forward, rotationSpeed * Time.deltaTime);
            this.transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);
        }
    }

    private void ToggleAutoRotation()
    {
        this.autoRotate = !this.autoRotate;
    }
}
