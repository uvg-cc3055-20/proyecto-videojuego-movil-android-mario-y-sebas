using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyBlob : MonoBehaviour
{
    public float speed = 1f;
    
    private sbyte direction;
    private SpriteRenderer sprite;

    #region Unity Callbacks
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        direction = 1;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ReverseDirection();
    }

    #endregion
    
    #region Private Methods
    private void ReverseDirection()
    {
        direction *= -1;
        transform.localScale = new Vector3(direction, 1f, 1f);
    }
    #endregion
}
