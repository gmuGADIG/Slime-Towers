using UnityEngine;

public class SlimeSelector : MonoBehaviour
{
	//The slime type of this selector
	public GameObject towerParent;

	public void setSlime(string slime)
	{
		towerParent.GetComponent<Tower>().setSlime(slime);
		Destroy(gameObject);
	}
}
