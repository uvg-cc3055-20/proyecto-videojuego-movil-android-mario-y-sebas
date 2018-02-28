using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalsePlataform : MonoBehaviour {
    private Rigidbody2D rb;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.gravityScale = 10f;
            Destroy(gameObject, 5f);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
