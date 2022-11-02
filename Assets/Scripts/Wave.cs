using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{

    public List<GameObject> enemies;
    public delegate void WaveComplete();
    public bool isActive { get { return enemies.Count != 0; } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
