using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class CPlayerMovementDblJump : MonoBehaviour
{
    #region Public Attributes
    [Tooltip("Adjusts the player movement speed.")]
    public float moveSpeed;
    [Tooltip("Adjusts the player jumping force.")]
    public float jumpForce;
    #endregion

    #region Private Attributes
    private Animator animator;
    private Rigidbody2D rigidBody;
    private Vector3 rightWalkingScale;
    private Vector3 leftWalkingScale;
    private bool jumped;
    private bool dblJumped;
    #endregion

    #region Unity Callbacks

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rightWalkingScale = transform.localScale;
        leftWalkingScale = new Vector3(-rightWalkingScale.x, rightWalkingScale.y, rightWalkingScale.z);
        jumped = false;
        dblJumped = false;
    }

    private void Update()
    {
        Move();
        Jump();
    }

    #endregion

    #region Public Methods
    /// <summary>
    /// Called when the players feet detect touching ground.
    /// </summary>
    public void SetGrounded()
    {
        jumped = dblJumped = false;
        // set parameter for jumping
        animator.SetBool("Jumping", jumped);
    }
    #endregion

    #region Private Methods
    /// <summary>
    /// Checks if the player is pressing any key that is tagged as
    /// horizontal input, and then applies the appropiate horizontal
    /// movement.
    /// </summary>
    private void Move()
    {
        int dir = 0;
        if (CInputController.instance.IsLeftPressed)
        {
            transform.localScale = leftWalkingScale;
            dir = -1;
        }
        else if (CInputController.instance.IsRightPressed)
        {
            transform.localScale = rightWalkingScale;
            dir = 1;
        }
        transform.Translate(Vector3.right * dir * Time.deltaTime * moveSpeed);
        // set parameter for walking or idle animation
        animator.SetInteger("Walking", dir);
    }

    /// <summary>
    /// Implements the character jumping behaviour. The character has double
    /// jumped hardcoded.
    /// </summary>
    private void Jump()
    {
        if (CInputController.instance.IsABtnFirstPress)
        {
            if(!jumped)
            {
                jumped = true;
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            else if(jumped && !dblJumped)
            {
                dblJumped = true;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, 0f);
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            // set parameter for jumping
            animator.SetBool("Jumping", jumped);
        }
    }
    #endregion
}
