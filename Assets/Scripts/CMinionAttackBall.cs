using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMinionAttackBall : MonoBehaviour
{
	public float speed;
	public float destroyTime = 5f;
	public int direction = 1;
	
	
	private void Start()
	{
		Destroy(gameObject, destroyTime);
	}

	private void Update()
	{
		transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		Destroy(gameObject);
	}
}
