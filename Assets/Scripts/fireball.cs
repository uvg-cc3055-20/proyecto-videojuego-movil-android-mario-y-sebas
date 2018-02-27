	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	
	public class fireball : MonoBehaviour {
		
		// Use this for initialization
		void Start () {
			
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.gameObject.CompareTag("Player"))
				Destroy(gameObject);
		}

		// Update is called once per frame
		void Update () {
			
		}
	}
