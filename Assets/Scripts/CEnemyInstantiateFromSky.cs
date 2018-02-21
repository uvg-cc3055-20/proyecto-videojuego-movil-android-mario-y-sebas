using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyInstantiateFromSky : MonoBehaviour
{
    public GameObject[] enemies;
    public Transform spawnPoint;
    [Tooltip("Maximum enemies this spawner can instantiate.")]
    public int spawnAmount;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && (spawnAmount--) > 0)
        {
            Instantiate(enemies[Random.Range(0, enemies.Length)], spawnPoint.position, Quaternion.identity);   
        }
    }
}
