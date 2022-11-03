using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wave : MonoBehaviour
{
    public HashSet<GameObject> enemies;
    public UnityEvent waveComplete;
    public float totalWaveTime;
    public float remainingTimeInWave;
    public bool active;
    
    public List<EnemySpawner> spawners;
    // Start is called before the first frame update
    void Start()
    {
        enemies = new HashSet<GameObject>();
        foreach (EnemySpawner i in spawners)
        {
            Debug.Log(i.name);
            i.onSpawn.AddListener(AddEnemyToWave);
        }
        remainingTimeInWave = totalWaveTime;

        setActive(true);
    }
    
    private void Update()
    {
        if(remainingTimeInWave > 0)
        {
            remainingTimeInWave -= Time.deltaTime;
        } else
        {
            setActive(false);

        }

    }
    public void AddEnemyToWave(GameObject enemy)
    {

        enemy.GetComponent<EnemyBehavior>().onDeath.AddListener(RemoveEnemy);
        this.enemies.Add(enemy);

    }

    void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            waveComplete.Invoke();
            Debug.Log("Wave Complete");
        }
    }

    void setActive(bool value)
    {
        active = value;
        foreach(EnemySpawner i in spawners)
        {
            i.active = value;
        }
    }
}
