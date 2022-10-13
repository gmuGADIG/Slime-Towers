using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    //Constants for the grid specifically the size of the grid and the distance between the cells
    public const int GRIDSIZE = 10;
    public const int DISTANCEBETWEENCELLS = 1;
    //The 2D array that holds all of the towers
    private GameObject[,] towerGrid = new GameObject[GRIDSIZE, GRIDSIZE];
    //
    public Vector2 gridStart;
    public GameObject towerPlaceholder;

    public List<GameObject> activeTowers = new List<GameObject>();

    public GameObject[] towerTypes;
    public int selectedTower = 0;

    public bool destroyMode = false;

    public List<GameObject> getActiveTowers()
    {
        return activeTowers;
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

    public void setTower(Vector2Int position, bool destroy)
    {
        int i = position.y, k = position.x;
        towerGrid[i, k] = Instantiate(destroy ? towerPlaceholder : towerTypes[selectedTower], new Vector3(k * DISTANCEBETWEENCELLS + gridStart.x, i * DISTANCEBETWEENCELLS + gridStart.y), new Quaternion());
        towerGrid[i, k].GetComponent<Tower>().setPosition(k, i);
        towerGrid[i, k].transform.SetParent(transform);
        towerGrid[i, k].GetComponent<Tower>().setDestroyMode(destroy);
        if (!destroy)
        {
            activeTowers.Add(towerGrid[i, k]);
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            destroyMode = !destroyMode;
            changeDeleteMode(destroyMode);
        }
    }



    void changeDeleteMode(bool mode)
    {
        for(int i = 0; i < GRIDSIZE; i++)
        {
            for(int k = 0; k < GRIDSIZE; k++)
            {
                towerGrid[i, k].GetComponent<Tower>().setDestroyMode(mode);
            }
        }
    }

    GameObject getTower(Vector2Int position)
    {
        return towerGrid[position.y, position.x];
    }

    GameObject getTower(int x, int y)
    {
        return towerGrid[y, x];
    }
}
