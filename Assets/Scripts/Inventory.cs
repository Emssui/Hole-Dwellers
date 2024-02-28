using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    
    public static Inventory instance;
    
    void Awake ()
    {
        instance = this;
    }
    
    #endregion
    
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // Reference to the inventory UI GameObject
    public GameObject inventoryUI;

    // Toggle inventory UI visibility
    public void ToggleInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        // Check if the inventory UI is active, then activate the GameObject with the "Inventory" tag
        if (inventoryUI.activeSelf)
        {
            GameObject inventoryObject = GameObject.FindGameObjectWithTag("Inventory");
            if (inventoryObject != null)
            {
                inventoryObject.SetActive(true);
            }
            else
            {
                Debug.LogWarning("No GameObject with tag 'Inventory' found!");
            }
        }
    }
}