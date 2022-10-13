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
    /**
     * Gets the towerNode from the TowerManager that is closests to pos
     */
    GameObject getClosestTowerNode(Vector2 pos)
    {
        //If pos is outside the grid of towers
        if (pos.x < towerManager.gameObject.transform.position.x || pos.x > towerManager.gameObject.transform.position.x + TowerManager.GRIDSIZE * TowerManager.DISTANCEBETWEENCELLS || pos.y < towerManager.gameObject.transform.position.y || pos.y > towerManager.gameObject.transform.position.y + TowerManager.GRIDSIZE * TowerManager.DISTANCEBETWEENCELLS)
        {
            
        }
        else //It is in the grid
        {
            //Get the tower that is closest to the position
            int x = (int)((pos.x - towerManager.gameObject.transform.position.x) / TowerManager.DISTANCEBETWEENCELLS);
            int y = (int)((pos.y - towerManager.gameObject.transform.position.y) / TowerManager.DISTANCEBETWEENCELLS);
            //return towerManager.towerGrid[y, x];
        }
        return null;
    }
    void GetPath()
    {
        GameObject closestStartTowerCell;
        GameObject closestEndToweCell;
        
    }




}
