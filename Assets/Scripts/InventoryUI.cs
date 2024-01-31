using UnityEngine;

/* This object manages the inventory UI. */

public class InventoryUI : MonoBehaviour {

	public GameObject inventoryUI;	// The entire UI
	public Transform itemsParent;	// The parent object of all the items

	Inventory inventory;	// Our current inventory

	void Start ()
	{
		inventory = Inventory.instance;
		// inventory.onItemChangedCallback += UpdateUI;
	}

	// Check to see if we should open/close the inventory
	void Update ()
	{
		if (Input.GetKeyDown(KeyCode.I))
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
            Debug.Log("Inventory");
		}
	}

	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	// public void UpdateUI ()
	// {
	// 	InventorySlot[] slots = GetComponentsInChildren<InventorySlot>();

	// 	for (int i = 0; i < slots.Length; i++)
	// 	{
	// 		if (i < inventory.items.Count)
	// 		{
	// 			slots[i].AddItem(inventory.items[i]);
	// 		} else
	// 		{
	// 			slots[i].ClearSlot();
	// 		}
	// 	}
	// }

}