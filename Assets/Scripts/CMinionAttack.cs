using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class CMinionAttack : MonoBehaviour
{
    public GameObject attackPrefab;
    public float attackDistance = 1f;
    public LayerMask targetLayerMask;
    public float attackCooldownTime = 0.5f;
    [Tooltip("Rough approximation of attack animation length.")]
    public float animDuration = 0.5f;

    private Animator animator;
    private RaycastHit2D hitInfo;
    private float lastAttackTime;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        hitInfo = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, attackDistance,
            targetLayerMask);
        if (hitInfo && Time.time - lastAttackTime > attackCooldownTime)
        {
            StartCoroutine(AttackAnimation());
        }
    }

    private IEnumerator AttackAnimation()
    {
        bool prevState = animator.GetBool("Walk");
        animator.SetBool("Attack", true);
        lastAttackTime = Time.time;
        Instantiate(attackPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(animDuration);
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", prevState);
    }
}
