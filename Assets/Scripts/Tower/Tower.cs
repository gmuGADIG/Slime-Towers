using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum Slime_Type
{
	None,
	Default,
	Fire,
	Ice,
	Zap
}
public enum Tower_Type
{
	None,
	Default,
	Sniper,
	AOE,
	Wall,
	RESTRICTED
}

public class Tower : MonoBehaviour
{
	//HP of tower
	protected int HP = -1;
	//Name of the tower
	public string towerName;
	//Type of the tower
	public Tower_Type towerType;
	//Amount of damage this tower does
	protected int damage = -1;
	//Type of slime in the tower
	public Slime_Type slime = Slime_Type.None;
	//Amount of pierce the bullet has
	protected int piercing = 0;
	//whether or not this tower exists
	protected bool exist = false;
	//Spriterenderer of this object
	public SpriteRenderer spriteRenderer;
	//If true allows towers to be destroyed and replaced with the placeholders
	protected bool destroyMode;
	//The position in the grid for the tower
	protected Vector2Int position = new Vector2Int(0, 0);
	//This bool is reversed so true means placing isn't allowed, and false means you can
	protected bool buildMode = false;

	public GameObject upgradePopup;

	protected GameObject currentUpgradePopup;

	public bool selected = false;
	public LayerMask WallLayer;

	public void Awake()
	{
	}

	public void Start(){
		if(towerType == Tower_Type.None && (Physics2D.OverlapPoint(transform.position,WallLayer) != null)){
			//Debug.Log("Tower "+ position.ToString() + " Collided");
			GameObject.Find("TowerManager").GetComponent<TowerManager>().setCollided(position);
		}
	}

	public Vector2Int getPosition()
	{
		return position;
	}

	public void setPosition(int x, int y)
	{
		position = new Vector2Int(x, y);
	}

	public void setDestroyMode(bool mode)
	{
		destroyMode = mode;
	}

    public void setBuildMode(bool mode)
    {
        buildMode = mode;
    }

    public void setSlime(Slime_Type slimeType)
	{
		slime = slimeType;
		GetComponent<TowerAI>().slimeSpriteUpdate();
	}

	public Slime_Type getSlime()
	{
		return slime;
	}
	
	public Tower_Type getType()
	{
		return towerType;
	}

	public string getTitle()
	{
		return towerName;
	}

	private void OnMouseDown()
	{
		if (!buildMode)
		{
			if (!EventSystem.current.IsPointerOverGameObject())
			{
				if (towerType.Equals(Tower_Type.RESTRICTED)) { }
				else if (towerType.Equals(Tower_Type.None))
				{
					if (!destroyMode)
					{
						TowerManager TowerMan = GameObject.Find("TowerManager").GetComponent<TowerManager>();
                        TowerMan.setTower(position, destroyMode, TowerMan.getSelectedType());
						Destroy(gameObject);
					}
				}
				else
				{
					if (destroyMode)
					{
						GameObject towerManager = GameObject.Find("TowerManager");
						towerManager.GetComponent<TowerManager>().setTower(position, destroyMode, Tower_Type.None);
						towerManager.GetComponent<TowerManager>().getActiveTowers().Remove(gameObject);
						if(currentUpgradePopup != null)
						{
                            Destroy(currentUpgradePopup);
                        }
						Destroy(gameObject);
					}
					else
					{
						if (towerType.Equals(Tower_Type.Wall))
						{

						}
						else if (selected = !selected)
						{
							currentUpgradePopup = Instantiate(upgradePopup, GameObject.Find("TowerCanvas").transform);
							currentUpgradePopup.GetComponent<SlimeSelector>().towerParent = gameObject;
							currentUpgradePopup.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f);
						}
						else
						{
							Destroy(currentUpgradePopup);
						}
					}
				}
			}
		}
	}
}
