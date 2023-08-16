using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidDestroy : MonoBehaviour
{
    private void OnMouseDown()
    {
        DestroyAsteroid();
    }

    public void DestroyAsteroid()
    {
        Destroy(gameObject);
        SoundManager.instance.PlayRandomAsteroidSound();
    }
}
