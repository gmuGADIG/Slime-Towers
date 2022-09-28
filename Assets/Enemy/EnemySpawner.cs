using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float TimeTillSpawn;
    public GameObject EnemyType;
    
    public const float RespawnTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        TimeTillSpawn = RespawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimeTillSpawn < 0) {
            GameObject enemy = Instantiate(EnemyType);
            enemy.transform.position = this.transform.position;
            TimeTillSpawn = RespawnTime;
        }
        TimeTillSpawn -= Time.deltaTime;
    }
}
