using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTower : Tower
{

    private void OnMouseDown()
    {
        if (destroyMode)
        {
            GameObject.Find("TowerManager").GetComponent<TowerManager>().setTower(position, destroyMode);
            Destroy(gameObject);
        }
    }
}
