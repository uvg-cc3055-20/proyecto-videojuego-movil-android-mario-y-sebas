using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falseGround : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.gravityScale = 10f;
            Destroy(gameObject, 5f);
        }
    }
}
