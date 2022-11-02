using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{

    private TowerManager towerManager;
    private EnemyManager enemyManager;
    public GameObject startPoint;
    public GameObject endPoint;
    public GameObject pathfindingNode;
    public List<GameObject> pathfindingNodes { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        if (towerManager == null)
        {
            towerManager = FindObjectOfType<TowerManager>();
        }
        if(enemyManager == null)
        {
            
            enemyManager = FindObjectOfType<EnemyManager>();
            
        }
        enemyManager.paths.Add(this);
        pathfindingNodes = new List<GameObject>();
    }
    public void resetPathMarkers()
    {
        placeMarkers(GetPath());
    }

    void placeMarkers(List<Vector2Int> path)
    {
        ClearMarkers();
        path.Reverse();
        GameObject prev = null;
        foreach (Vector2Int pos in path)
        {
            GameObject marker = Instantiate(pathfindingNode);
            marker.transform.position = towerManager.getTower(pos).transform.position;
            marker.GetComponent<PathfindingNode>().nextNode = prev;
            pathfindingNodes.Add(marker);
            prev = marker;

        }
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
    public List<Vector2Int> GetPath()
    {
        Vector2Int startNode = getClosestNode(startPoint.transform.position);
        Vector2Int endNode = getClosestNode(endPoint.transform.position);
        List<Vector2Int> openSet = new List<Vector2Int>();
        Dictionary<Vector2Int, Vector2Int> cameFrom = new Dictionary<Vector2Int, Vector2Int>();
        Dictionary<Vector2Int, float> gScore = new Dictionary<Vector2Int, float>();
        Dictionary<Vector2Int, float> fScore = new Dictionary<Vector2Int, float>();
        openSet.Add(startNode);

        gScore.Add(startNode, 0);
        fScore.Add(startNode, distance(startNode, endNode));
        List<Vector2Int> path = new List<Vector2Int>();
        while (openSet.Count > 0)
        {
            Vector2Int current = openSet[0];
            for (int i = 1; i < openSet.Count; i++)
            {
                if (fScore[openSet[i]] < fScore[current])
                {
                    current = openSet[i];
                }
            }
            if (current == endNode)
            {
                path = reconstructPath(cameFrom, current);
                break;
            }
            openSet.Remove(current);
            if (towerManager.getTower(current).GetComponent<Tower>().towerName != "Tower" && towerManager.getTower(current).GetComponent<Tower>().towerName != "RESTRICTED")
            {
                continue;
            }
            foreach (Vector2Int neighbor in getNeighbors(current))
            {
                float tentativeGScore = gScore[current] + distance(current, neighbor);
                if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                {
                    cameFrom[neighbor] = current;
                    gScore[neighbor] = tentativeGScore;
                    fScore[neighbor] = gScore[neighbor] + distance(neighbor, endNode);
                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }
        return path;


    }


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

    void ClearMarkers()
    {

        foreach (GameObject marker in pathfindingNodes)
        {
            Destroy(marker);
        }
        pathfindingNodes.Clear();
    }
}
