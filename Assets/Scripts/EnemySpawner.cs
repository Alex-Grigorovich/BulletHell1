using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // Start is called before the first frame update


    public GameObject enemyToSpawn;
    
    private float spawnCounter;
    public float timeToSpawn;

    public Transform minSpawn, maxSpawn;
   // public List<WaveInfo> waves;
    void Start()
    {
        spawnCounter = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeToSpawn;
           
            //Instantiate(enemyToSpawn,  transform.rotation);
            
            Instantiate(enemyToSpawn, SelectSpawnPoint(), transform.rotation);
        }

    }

    public Vector3 SelectSpawnPoint()
    {
        var SpawnPoint = Vector3.zero;


        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if (spawnVerticalEdge)
        {
            SpawnPoint.y = Random.Range(minSpawn.position.y, maxSpawn.position.y);

            if (Random.Range(0f, 1f) > .5f)
            {
                SpawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                SpawnPoint.x = minSpawn.position.x;
            }
            
        }
        else
        {
            SpawnPoint.x = Random.Range(minSpawn.position.x, maxSpawn.position.x);

            if (Random.Range(0f, 1f) > .5f)
            {
                SpawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                SpawnPoint.y = minSpawn.position.y;
            }
        }
        
        return SpawnPoint;
    }
    
    
}

