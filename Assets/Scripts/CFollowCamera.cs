using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFollowCamera : MonoBehaviour
{
	public GameObject target;
	public float maxDistance = 1f;
	public float camSpeed = 1f;

	private void Update()
	{
		if (Vector2.Distance(target.transform.position, transform.position) > maxDistance)
		{
			Vector2 m = target.transform.position - transform.position;
			transform.Translate(m * camSpeed * Time.deltaTime);
		}
	}
}
