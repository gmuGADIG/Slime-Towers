using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SlimeSelector : MonoBehaviour
{
	//The slime type of this selector
	public GameObject towerParent;
	public GameObject defaultButton;
	public GameObject zapButton;
	public GameObject fireButton;
	public GameObject iceButton;

	void Awake()
	{
		int invAmount;
		bool hasMat = false;
		hasMat = Inventory.materials.TryGetValue(SlimeTowers.MaterialType.SLIME, out invAmount);
		if (!hasMat || invAmount < 1)
		{
			defaultButton.GetComponent<Button>().interactable = false;
		}
		else
		{
			defaultButton.GetComponent<Button>().interactable = true;
		}
		hasMat = Inventory.materials.TryGetValue(SlimeTowers.MaterialType.ZAP_SLIME, out invAmount);
		if (!hasMat || invAmount < 1)
		{
			zapButton.GetComponent<Button>().interactable = false;
		}
		else
		{
			zapButton.GetComponent<Button>().interactable = true;
		}
		hasMat = Inventory.materials.TryGetValue(SlimeTowers.MaterialType.FIRE_SLIME, out invAmount);
		if (!hasMat || invAmount < 1)
		{
			fireButton.GetComponent<Button>().interactable = false;
		}
		else
		{
			fireButton.GetComponent<Button>().interactable = true;
		}
		hasMat = Inventory.materials.TryGetValue(SlimeTowers.MaterialType.ICE_SLIME, out invAmount);
		if (!hasMat || invAmount < 1)
		{
			iceButton.GetComponent<Button>().interactable = false;
		}
		else
		{
			iceButton.GetComponent<Button>().interactable = true;
		}

	}

	public void setSlime(string slime)
	{
		Debug.Log(slime);
		Inventory.inventory.logStatus();
		Slime_Type slimeType = Slime_Type.None;
		int amt;
		Debug.Log(Inventory.materials.TryGetValue(SlimeTowers.MaterialType.SLIME, out amt));
		Debug.Log(amt);
		int invAmount;
		bool hasMat = false;
		if (slime == "Default")
		{
			slimeType = Slime_Type.Default;
			hasMat = Inventory.materials.TryGetValue(SlimeTowers.MaterialType.SLIME, out invAmount);
		}
		else if (slime == "Zap")
		{
			slimeType = Slime_Type.Zap;
			hasMat = Inventory.materials.TryGetValue(SlimeTowers.MaterialType.ZAP_SLIME, out invAmount);
		}
		else if (slime == "Fire")
		{
			slimeType = Slime_Type.Fire;
			hasMat = Inventory.materials.TryGetValue(SlimeTowers.MaterialType.FIRE_SLIME, out invAmount);
		}
		else if (slime == "Ice")
		{
			slimeType = Slime_Type.Ice;
			hasMat = Inventory.materials.TryGetValue(SlimeTowers.MaterialType.ICE_SLIME, out invAmount);
		}
		else if (slime == "Remove")
		{
			slimeType = Slime_Type.None;
		}
		Debug.Log(hasMat);
		towerParent.GetComponent<Tower>().setSlime(slimeType);
		Destroy(gameObject);
	}
}
