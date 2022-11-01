using System.Collections;
using System.Collections.Generic;
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
        foreach (Pathfinder path in paths
        )
        {
            if (path.GetPath().Count > 0)
            {
                return true;
            }
        }
        return false;
    }

    [Obsolete]
    void placeMarkers(List<Vector2Int> path)
    {

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
        } else
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
        } else
        {
            y = (int)((pos.y - towerManager.gridStart.y) / TowerManager.DISTANCEBETWEENCELLS);
        }
        return new Vector2Int(x, y);
    }
    float distance(Vector2Int a, Vector2Int b)
    {
        return Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2));
    }
    [Obsolete]
    List<Vector2Int> reconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int current)
    {
        List<Vector2Int> totalPath = new List<Vector2Int>();
        totalPath.Add(current);
        while (cameFrom.ContainsKey(current))
        {
            current = cameFrom[current];
            totalPath.Add(current);
        }
        totalPath.Reverse();
        return totalPath;
    }
    [Obsolete]
    public List<Vector2Int> GetPath()
    {
        Vector2Int startNode = getClosestNode(startpoint.transform.position);
        Vector2Int endNode = getClosestNode(endpoint.transform.position);
        List<Vector2Int> openSet = new List<Vector2Int>() { startNode };
        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
        Dictionary<Vector2Int, float> gScore = new Dictionary<Vector2Int, float>();
        
    }

    void reconstructPath(Dictionary<Vector2Int, Vector2Int> cameFrom, Vector2Int currentNode)
    {
        List<Vector2Int> totalPath = new List<Vector2Int>() { currentNode };
        while (cameFrom.ContainsKey(currentNode))
        {
            currentNode = cameFrom[currentNode];
            totalPath.Add(currentNode);
        }
        totalPath.Reverse();
    }

    [Obsolete]
    List<Vector2Int> getNeighbors(Vector2Int node)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();
        if (node.x > 0)
        {
            neighbors.Add(new Vector2Int(node.x - 1, node.y));
        }
        if (node.x < TowerManager.GRIDSIZE - 1)
        {
            neighbors.Add(new Vector2Int(node.x + 1, node.y));
        }
        if (node.y > 0)
        {
            neighbors.Add(new Vector2Int(node.x, node.y - 1));
        }
        if (node.y < TowerManager.GRIDSIZE - 1)
        {
            neighbors.Add(new Vector2Int(node.x, node.y + 1));
        }
        return neighbors;
    }
    [Obsolete]
    void ClearMarkers()
    {

        GameObject[] markers = GameObject.FindGameObjectsWithTag("Finish");
        foreach (GameObject marker in markers)
        {
            Destroy(marker);
        }
    }
}
