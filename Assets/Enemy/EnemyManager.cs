using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public TowerManager towerManager;
    public GameObject endpoint;
    public GameObject startpoint;
    public GameObject targetObject;
    public List<Pathfinder> paths;
    // Start is called before the first frame update
    void Start()
    {
        if (towerManager == null)
        {
            towerManager = FindObjectOfType<TowerManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            resetPathMarkers();
        }
    }

    public void resetPathMarkers(){
        foreach (Pathfinder path in paths)
        {
            path.resetPathMarkers();
        }
    }

    public bool hasValidPath()
    {
        foreach (Pathfinder path in paths)
        {
            if (path.GetPath().Count == 0)
            {
                return false;
            }
        }
        return true;
    }

    /**
     * Gets the towerNode from the TowerManager that is closests to pos
     */
    Vector2Int getClosestNode(Vector2 pos)
    {
        int x;
        int y;
        if (pos.x < towerManager.gridStart.x)
        {
            x = 0;
        }
        else if (pos.x > towerManager.gridStart.x + (TowerManager.GRIDSIZE - 1) * TowerManager.DISTANCEBETWEENCELLS)
        {
            x = TowerManager.GRIDSIZE - 1;
        }
        else
        {
            x = (int)((pos.x - towerManager.gridStart.x) / TowerManager.DISTANCEBETWEENCELLS);
        }
        if (pos.y < towerManager.gridStart.y)
        {
            y = 0;
        }
        else if (pos.y > towerManager.gridStart.y + (TowerManager.GRIDSIZE - 1) * TowerManager.DISTANCEBETWEENCELLS)
        {
            y = TowerManager.GRIDSIZE - 1;
        }
        else
        {
            y = (int)((pos.y - towerManager.gridStart.y) / TowerManager.DISTANCEBETWEENCELLS);
        }
        return new Vector2Int(x, y);
    }
    float distance(Vector2Int a, Vector2Int b)
    {
        return Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2));
    }
}
