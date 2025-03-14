using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy());        
    }

    IEnumerator SpawnEnemy() 
    {
        yield return new WaitForSeconds(3);
        int randPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[randPoint].transform.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }

}
