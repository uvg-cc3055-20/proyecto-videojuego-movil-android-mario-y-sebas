using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyHealth : MonoBehaviour
{
    public float maxHealth;

    private float health;

    private void Start()
    {
        health = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Enemy hit!");
    }

    public void MakeDamage(float amount)
    {
        if (amount > 0)
        {
            health -= amount;
            if (health < 0)
            {
                health = 0;
                // trigger death
            }
        }
    }
}
