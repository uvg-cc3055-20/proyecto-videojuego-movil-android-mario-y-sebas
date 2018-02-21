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

    public void MakeDamage(float amount)
    {
        if (amount > 0)
        {
            health -= amount;
            if (health < 0)
            {
                health = 0;
                //TODO: trigger death
            }
        }
    }
}
