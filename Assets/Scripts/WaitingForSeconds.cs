using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitingForSeconds : MonoBehaviour
{
    enum CountingMethod
    {
        // Pro: Easy to use, will stop when Time.timeScale = 0;
        // Con: Can look convoluted, might not be most efficient
        Frames,
        // Pro: Pass in additional parameters, better performance
        // Con: Bit more complicated
        Coroutine,
        // Pro: Easier to use
        // Con: Inflexible, Error-prone, Reflection (worse performance)
        Invoke
    }

    private float counter = 0;
    private float timeToAct = 1f;

    [SerializeField] private CountingMethod countingMethod;

    RotatingMovement rotatingMovement;

    // Start is called before the first frame update
    void Start()
    {
        rotatingMovement = GetComponent<RotatingMovement>();

        if(countingMethod == CountingMethod.Coroutine)
        {
            StartCoroutine(ToggleRotationCoroutine());
        }

        if(countingMethod == CountingMethod.Invoke)
        {
            InvokeRepeating("ToggleWithInvoke", timeToAct, timeToAct);
        }
    }

    void ToggleWithInvoke() 
    {
        rotatingMovement.ToggleAutoRotation();
    }

    IEnumerator ToggleRotationCoroutine()
    {
        yield return new WaitForSeconds(timeToAct);
        rotatingMovement.ToggleAutoRotation();
        StartCoroutine(ToggleRotationCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        if(countingMethod == CountingMethod.Frames)
        {
            if(counter < timeToAct)
            {
                counter += Time.deltaTime;
            } 
            else
            {
                counter = 0;
                rotatingMovement.ToggleAutoRotation();
            }
        }
    }
}
