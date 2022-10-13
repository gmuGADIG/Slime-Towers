using UnityEngine;

public class SlimeSelector : MonoBehaviour
{
	//The slime type of this selector
	public string slimeType;
	public GameObject towerParent;

	void OnMouseDown()
	{
		towerParent.GetComponent<Tower>().setSlime(slimeType);
	}
}
