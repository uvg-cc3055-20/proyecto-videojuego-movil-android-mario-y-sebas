using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]
public class CPlayerHealth : MonoBehaviour
{
    public AudioClip hitClip;
    public float deathAnimationDuration = 1f;
    
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
        if (other.gameObject.CompareTag("Enemy") && !dead)
        {
            StartCoroutine(DeathCoroutine());
            audioSource.clip = hitClip;
            audioSource.Play();
        }
    }

    private IEnumerator DeathCoroutine()
    {
        dead = true;
        animator.SetBool("Dead", dead);
        yield return new WaitForSeconds(deathAnimationDuration);
        dead = false;
        animator.SetBool("Dead", dead);
        CGameController.instance.RespawnPlayerFast();
    }
}
