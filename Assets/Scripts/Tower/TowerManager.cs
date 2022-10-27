using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    //Constants for the grid specifically the size of the grid and the distance between the cells
    public static int GRIDSIZE = 10;
    public static int DISTANCEBETWEENCELLS = 1;
    public int RESTRICTEDDISTANCE = 10;
    //The 2D array that holds all of the towers
    private GameObject[,] towerGrid;
    //The vector where the grid starts
    public Vector2 gridStart;
    //The tower that makes up the grid
    public GameObject towerPlaceholder;
    //The tower that represents restricted grids
    public GameObject restricted;
    //The active towers for pathfinding to use
    public List<GameObject> activeTowers = new List<GameObject>();
    //The tower types of the game
    public GameObject[] towerTypes;
    //The selected tower to use
    public int selectedTower = 0;
    //Whether to destroy the towers or create new ones
    public bool destroyMode = false;
    //Indicator for mode Orange for manage, Green for create, Red for delete
    public GameObject squareSelector;
    [Tooltip("The Enemy Manager active in the scene")]
    public EnemyManager enemyManager;

    //Makes a shallow copy of the active towers on the grid
    public List<GameObject> getActiveTowers()
    {
        return activeTowers;
    }

    //Puts the placeholder tower to all the grid
    void Start()
    {
        towerGrid = new GameObject[GRIDSIZE, GRIDSIZE];
        if (enemyManager == null) {
            enemyManager = FindObjectOfType<EnemyManager>();
        } else {
            Debug.LogError("Scene has Tower Manager and no Enemy Manager. This will cause problems");
        }
        squareSelector.GetComponent<SpriteRenderer>().color = Color.green;
        for (int i = 0; i < GRIDSIZE; i++)
        {
            for (int k = 0; k < GRIDSIZE; k++)
            {

                towerGrid[i, k] = Instantiate(towerPlaceholder, new Vector3(k * DISTANCEBETWEENCELLS + gridStart.x, i * DISTANCEBETWEENCELLS + gridStart.y), new Quaternion());
                towerGrid[i, k].GetComponent<Tower>().setPosition(k, i);
                towerGrid[i, k].transform.SetParent(transform);
            }

        }
        enemyManager.resetPathMarkers();

        List<Pathfinder> pathfinders = enemyManager.paths;
        int count = 1;
        foreach (Pathfinder pathfinder in pathfinders)
        {
            setRestricted(getClosestNode(pathfinder.startPoint.transform.position));
            setRestricted(getClosestNode(pathfinder.endPoint.transform.position));
        }
        enemyManager.resetPathMarkers();
    }

    void setRestricted(Vector2Int position)
    {
        int i = position.y, k = position.x;
        for(int y = 0; y < GRIDSIZE; y++)
        {
            for(int x = 0; x < GRIDSIZE; x++)
            {
                if((Mathf.Abs(x-k) + Mathf.Abs(y-i)) <= RESTRICTEDDISTANCE)
                {
                    Destroy(towerGrid[y, x]);
                    towerGrid[y, x] = Instantiate(restricted, new Vector3(x * DISTANCEBETWEENCELLS + gridStart.x, y * DISTANCEBETWEENCELLS + gridStart.y), new Quaternion());
                    towerGrid[y, x].GetComponent<Tower>().setPosition(x, y);
                    towerGrid[y, x].transform.SetParent(transform);
                }
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
        enemyManager.resetPathMarkers();
        if(!enemyManager.hasValidPath())
        {
            activeTowers.Remove(towerGrid[i, k]);
            Destroy(towerGrid[i, k]);
            towerGrid[i, k] = Instantiate(towerPlaceholder, new Vector3(k * DISTANCEBETWEENCELLS + gridStart.x, i * DISTANCEBETWEENCELLS + gridStart.y), new Quaternion());
            towerGrid[i, k].GetComponent<Tower>().setPosition(k, i);
            towerGrid[i, k].transform.SetParent(transform);
            towerGrid[i, k].GetComponent<Tower>().setDestroyMode(destroy);
            enemyManager.resetPathMarkers();
        }
    }
    
    //Setting the mode the player is in should eventually be changed to something else
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            destroyMode = !destroyMode;
            changeDeleteMode(destroyMode);
            if (destroyMode)
            {
                squareSelector.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                squareSelector.GetComponent <SpriteRenderer>().color = Color.green;
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

    /**
     * Gets the towerNode that is closest to the position
     */
    public Vector2Int getClosestNode(Vector2 pos)
    {
        int x;
        int y;
        if (pos.x < gridStart.x)
        {
            x = 0;
        }
        else if (pos.x > gridStart.x + (GRIDSIZE - 1) * DISTANCEBETWEENCELLS)
        {
            x = GRIDSIZE - 1;
        }
        else
        {
            x = (int)((pos.x - gridStart.x) / DISTANCEBETWEENCELLS);
        }
        if (pos.y < gridStart.y)
        {
            y = 0;
        }
        else if (pos.y > gridStart.y + (GRIDSIZE - 1) * DISTANCEBETWEENCELLS)
        {
            y = GRIDSIZE - 1;
        }
        else
        {
            y = (int)((pos.y - gridStart.y) / DISTANCEBETWEENCELLS);
        }
        return new Vector2Int(x, y);
    }
}
