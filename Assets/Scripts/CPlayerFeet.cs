using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayerFeet : MonoBehaviour
{
    private CPlayerMovementDblJump player;

    private void Start()
    {
        player = GetComponentInParent<CPlayerMovementDblJump>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // detect if character is touching ground
        if (other.gameObject.CompareTag("Ground"))
        {
            player.SetGrounded();
        }
    }
}
