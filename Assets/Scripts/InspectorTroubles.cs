using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorTroubles : MonoBehaviour
{
    [SerializeField] private int speed = 15;
    public float pressure = 55f;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello, it is I, Inspector Troubles!");
    }
}
