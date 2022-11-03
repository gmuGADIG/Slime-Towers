using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyEvents : MonoBehaviour
{
    UnityEvent despawnAllEnemies;
    private ManagerScript gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = ManagerScript.gm;
        gameManager.despawnAllEnemies.AddListener(despawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void despawn() {
        Destroy(gameObject);
    }
}
