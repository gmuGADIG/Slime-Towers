using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public TowerManager towerManager;
    public GameObject endpoint;
    public GameObject startpoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void placeMarkers()
    {

    }
    
    void findPath()
    {
        List<Vector2> currentPath = new List<Vector2>();
        HashSet<Vector2> openSet = new HashSet<Vector2>();
        
    }


}
