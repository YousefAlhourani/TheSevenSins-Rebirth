using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    public static InventoryController Instance { get; set; }
    public List<Item> playerItems = new List<Item>();
    public InventoryUIDetails inventoryDetailsPanel;
    public InventoryUIDetails[] inventoryDetailsPanel1;
    public ConsumableController consumable;

   

    private void Start()
    {
        GameEvents.SaveInitiated += SaveInventory;

        UIEventHandler.OnItemRemovedFromInventory += RemoveItem;

        inventoryDetailsPanel1 = Resources.FindObjectsOfTypeAll<InventoryUIDetails>();
        inventoryDetailsPanel = inventoryDetailsPanel1[0];


        LoadInvetory();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    
    public void RemoveItem(Item item)
    {
        playerItems.Remove(item);
    }

    public void GiveItem(string itemSlug)
    {
        Item item = ItemDatabase.instance.GetItem(itemSlug);
        playerItems.Add(item);
        UIEventHandler.ItemAddedToInventory(item);
    }

    public void GiveItems(List<Item> items)
    {
        if (items != null)
        {
            foreach (Item item in items)
            {
                GiveItem(item.itemName);
            }
        }
    }

 
    

    public void SetItemDetails(Item item , Button selectedItem)
    {
        
        inventoryDetailsPanel.SetItem(item, selectedItem);
    }

    void SaveInventory()
    {
        SaveLoadSystem.Save<List<Item>>(playerItems,"Inventory");
    }


    void LoadInvetory()
    {
        if(SaveLoadSystem.SaveExists("Inventory"))
        {
            GiveItems(SaveLoadSystem.Load<List<Item>>("Inventory"));
        }
    }


 
}


