using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class CPlayerHealth : MonoBehaviour
{
    public AudioClip hitClip;
    
    private bool dead;
    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            dead = true;
            animator.SetBool("Dead", dead);
            audioSource.clip = hitClip;
            audioSource.Play();
            Debug.Log("PLayerHealth-> player hit by: " + other.gameObject.name);
        }
    }
}
