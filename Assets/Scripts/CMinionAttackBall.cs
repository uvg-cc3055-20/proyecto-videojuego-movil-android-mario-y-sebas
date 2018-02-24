using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMinionAttackBall : MonoBehaviour
{
	public float speed;
	public float destroyTime = 5f;

	private void Start()
	{
		Destroy(gameObject, destroyTime);
	}

	private void Update()
	{
		transform.Translate(Vector2.right * speed * Time.deltaTime);
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			CGameController.instance.RespawnPlayer();
		}
		Destroy(gameObject);
	}
}
