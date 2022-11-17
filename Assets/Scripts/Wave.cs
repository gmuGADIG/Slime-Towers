using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Wave : MonoBehaviour
{
    public HashSet<GameObject> enemies;
    public UnityEvent onWaveComplete;
    public UnityEvent onWaveStart;
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

        //StartWave();
        ManagerScript.StartAttack.AddListener(StartWave);
    }
    
    private void Update()
    {
        if (active)
        {
            if (remainingTimeInWave > 0)
            {
                remainingTimeInWave -= Time.deltaTime;
            }
            else
            {
                setActive(false);

            }
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
            onWaveComplete.Invoke();
            ManagerScript.gm.setGameState(GameState.EXPLORE);
            Debug.Log("Wave Complete");
        }
    }

    public void setActive(bool value)
    {
        active = value;
        foreach(EnemySpawner i in spawners)
        {
            i.active = value;
        }
    }

    public void StartWave()
    {
        if(active == false)
        {
            setActive(true);
            remainingTimeInWave = totalWaveTime;
            onWaveStart.Invoke();
        }
    }
}
