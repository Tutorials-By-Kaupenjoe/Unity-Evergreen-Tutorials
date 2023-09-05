using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BallistaShooting : MonoBehaviour
{
    private bool reloaded;
    private bool shooting;

    [SerializeField] private GameObject firedBolt;
    [SerializeField] private GameObject boltPrefab;

    private BallistaAnimations ballistaAnimations;

    void Start()
    {
        if(firedBolt == null)
        {
            firedBolt = transform.GetChild(0).gameObject;
            reloaded = true;
        }

        ballistaAnimations = GetComponent<BallistaAnimations>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(TryShoot())
            {
                Shoot();
            } 
            else
            {
                Debug.Log("The Ballista first has to be reloaded!");
            }
        }

        if(Input.GetKeyDown(KeyCode.R))
        {
            if(TryReload())
            {
                Reload();
            } 
            else
            {
                Debug.Log("The Ballista is already reloaded!");
            }
        }
    }

    private bool TryReload()
    {
        return !reloaded;
    }

    private void Reload()
    {
        reloaded = true;
        shooting = false;

        ballistaAnimations.ReloadAnimation();

        firedBolt = Instantiate(boltPrefab, this.transform);
    }

    private bool TryShoot()
    {
        return reloaded && !shooting; 
    }

    private void Shoot()
    {
        ballistaAnimations.ShootingAnimation();

        firedBolt.GetComponent<BoltProjectile>().Shoot();
        firedBolt.transform.parent = null;
        shooting = true;
        reloaded = false;
    }
}
