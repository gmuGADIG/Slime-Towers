using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : MonoBehaviour
{
    [HideInInspector]
    public float TimeTillSpawn;
    public GameObject EnemyType;
    public UnityEvent<GameObject> onSpawn;
    public float RespawnTime;
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        TimeTillSpawn = RespawnTime;

    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            if (TimeTillSpawn < 0)
            {
                SpawnEnemy();
                TimeTillSpawn = RespawnTime;

                
            }
            TimeTillSpawn -= Time.deltaTime;
        }
    }

    void SpawnEnemy()
    {
        
        GameObject enemy = Instantiate(EnemyType);
        enemy.transform.position = this.transform.position;
        onSpawn.Invoke(enemy);
        
    }
    
}
