using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyHealth : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerAttack"))
        {
            Debug.Log("ASDJFKLASJDFLKAJSLDKFJALKSDJFLKASD");
            Destroy(gameObject);
        }
    }
}
