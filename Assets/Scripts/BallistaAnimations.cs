using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallistaAnimations : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShootingAnimation()
    {
        animator.SetBool("loaded_bolt", false);
        animator.SetTrigger("shoot");
    }

    public void ReloadAnimation()
    {
        animator.SetBool("loaded_bolt", true);
    }
}
