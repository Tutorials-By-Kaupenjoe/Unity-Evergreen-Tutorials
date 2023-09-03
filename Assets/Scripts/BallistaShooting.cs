using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaShooting : MonoBehaviour
{
    private bool shooting;

    [SerializeField] private GameObject firedBolt;

    void Start()
    {
        if(firedBolt == null)
        {
            firedBolt = transform.GetChild(0).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && !shooting)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        firedBolt.GetComponent<BoltProjectile>().Shoot();
        firedBolt.transform.parent = null;
        shooting = true;
    }
}
