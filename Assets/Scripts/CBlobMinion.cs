using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBlobMinion : MonoBehaviour 
{
    public GameObject attackPrefab;
    [Tooltip("Rough approximation of attack animation length.")]
    public float animDuration = 0.5f;

    private CEnemyMoveHorizontally movement;
    private Animator animator;
    private AudioSource audioSource;
    private RaycastHit2D hitInfo;
    private float lastAttackTime;

    private void Start()
    {
        movement = GetComponent<CEnemyMoveHorizontally>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        StartCoroutine(AttackBehaviour());
    }

    private IEnumerator AttackBehaviour()
    {
        while (true)
        {
            int randomWait = Random.Range(2, 5);
            movement.walking = false;
            animator.SetBool("Walk", false);
            audioSource.mute = true;
            animator.SetBool("Attack", true);
            Instantiate(attackPrefab, transform.position, Quaternion.identity).GetComponent<CMinionAttackBall>()
                .direction = movement.direction;
            yield return new WaitForSeconds(animDuration);
            animator.SetBool("Attack", false);
            yield return new WaitForSeconds(randomWait);
            animator.SetBool("Walk", true);
            audioSource.mute = false;
            movement.walking = true;
        }
    }
}
