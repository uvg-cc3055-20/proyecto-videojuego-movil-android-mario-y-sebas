using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerHealth : MonoBehaviour
{
    private bool dead;
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            dead = true;
            animator.SetBool("Dead", dead);
        }
    }
}
