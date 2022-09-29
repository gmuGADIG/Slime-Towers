using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour

{
    public const int GRIDSIZE = 10;
    public const int DISTANCEBETWEENCELLS = 1;

    private GameObject[,] towerGrid = new GameObject[GRIDSIZE, GRIDSIZE];

    public Vector2 gridStart;
    public GameObject towerPlaceholder;

    public GameObject[] towers;
    public int selectedTower = 0;

    public Vector2Int FindMousePosition()
    {
        Vector2Int gridPosition = new Vector2Int(0, 0);
        Vector2 mousePosition = Input.mousePosition;
        //if()

        return gridPosition;
    }

    void Start()
    {
        for(int i = 0; i < GRIDSIZE; i++)
        {
            for(int k = 0; k < GRIDSIZE; k++)
            {
                
                towerGrid[i, k] = Instantiate(towerPlaceholder, new Vector3(k*DISTANCEBETWEENCELLS + gridStart.x, i*DISTANCEBETWEENCELLS + gridStart.y), new Quaternion());
                towerGrid[i, k].GetComponent<Tower>().setPosition(k, i);
                towerGrid[i, k].transform.SetParent(transform);
            }

        }
    }

    public void setTower(Vector2Int position)
    {
        int i = position.x, k = position.y;
        towerGrid[i, k] = Instantiate(towers[selectedTower], new Vector3(i * DISTANCEBETWEENCELLS + gridStart.x, k * DISTANCEBETWEENCELLS + gridStart.y), new Quaternion());
        towerGrid[i, k].GetComponent<Tower>().setPosition(k, i);
        towerGrid[i, k].transform.SetParent(transform);
    }
    
    void Update()
    {
        
    }
}
