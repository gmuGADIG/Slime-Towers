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
    //The vector where the grid starts
    public Vector2 gridStart;
    //The tower that makes up the grid
    public GameObject towerPlaceholder;
    //The active towers for pathfinding to use
    public List<GameObject> activeTowers = new List<GameObject>();
    //The tower types of the game
    public GameObject[] towerTypes;
    //The selected tower to use
    public int selectedTower = 0;
    //Whether to destroy the towers or create new ones
    public bool destroyMode = false;
    //Whether the player is managing the towers
    public bool managing = false;
    //Indicator for mode Orange for manage, Green for create, Red for delete
    public GameObject squareSelector;

    //Makes a shallow copy of the active towers on the grid
    public List<GameObject> getActiveTowers()
    {
        return activeTowers;
    }

    //Puts the placeholder tower to all the grid
    void Start()
    {
        squareSelector.GetComponent<SpriteRenderer>().color = Color.green;
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

    //Sets the tower at a specific position
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
    
    //Setting the mode the player is in should eventually be changed to something else
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && !managing)
        {
            if (destroyMode)
            {
                squareSelector.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                squareSelector.GetComponent <SpriteRenderer>().color = Color.green;
            }
            destroyMode = !destroyMode;
            changeDeleteMode(destroyMode);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            managing = !managing;
            if (managing)
            {
                squareSelector.GetComponent<SpriteRenderer>().color = new Color(0.8f, 0.3f, 0.0f);
            }
            else
            {
                squareSelector.GetComponent<SpriteRenderer>().color = Color.green;
            }
            changeManageMode(managing);
            if (!managing)
            {
                destroyMode = false;
                changeDeleteMode(destroyMode);
            }
        }
    }


    //Changes all the towers to make sure they know they will be deleted or not if clicked 
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

    public GameObject getTower(Vector2Int position)
    {
        return towerGrid[position.y, position.x];
    }

    GameObject getTower(int x, int y)
    {
        return towerGrid[y, x];
    }
    
    void changeManageMode(bool mode)
    {
        for (int i = 0; i < GRIDSIZE; i++)
        {
            for (int k = 0; k < GRIDSIZE; k++)
            {
                towerGrid[i, k].GetComponent<Tower>().setManageMode(mode);
            }
        }
    }
}
