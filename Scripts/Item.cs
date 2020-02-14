using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Item 
{
    public int itemID;
    public string itemName;
    public string itemDescription;
    
    public Dictionary<string, int> stats = new Dictionary<string, int>();
    public bool ItemModifier { get; set; }
    public bool Stackable { get; set; }
    public enum ItemType { Consumable,QuestItem,Weapon,Craftables}
    public ItemType ItemTypes { get; set; }

    public Item(int id, string title, ItemType _ItemType, string description, Dictionary<string, int> stats, bool stackable,bool itemMod)
    {
        this.itemID = id;
        this.itemName = title;
        this.itemDescription = description;
        this.ItemModifier = itemMod;
        this.stats = stats;
        this.ItemTypes = _ItemType;
        this.Stackable = stackable;
       
        
    }

    //Copy Constructer
   public Item(Item item)
    {
        this.itemID = item.itemID;
        this.itemName = item.itemName;
        this.itemDescription = item.itemDescription;
        this.stats = item.stats;

    }


   

 
}

