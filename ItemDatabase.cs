using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public static ItemDatabase instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
            instance = this;


        BuildItemDatabase();
    }

    public Item GetItem(string itemName)
    {
       return items.Find(item =>item.itemName==itemName);
    }

    /* item types:
     * 0: Consumable
     * 1:QuestItem
     * 2:Weapons
     * 3:Craftables
    */

    void BuildItemDatabase()
    {
        items = new List<Item>()
        {
            new Item(1,"Health Potion",Item.ItemType.Consumable,"Bottle Containing A Blood Red Fluid, Drinking Heals You 25 Health Points",new Dictionary<string, int>{  {"Heal Health",25} },true,false),

            new Item(2,"Mana Potion",Item.ItemType.Consumable,"Bottle Containing A Flowerly Smell, Drinking Heals You 25 Mana Points",new Dictionary<string, int>{  {"Heal Mana",25} },true,false),

            new Item(3,"Mega Health Potion",Item.ItemType.Consumable,"Potion Created By The Crazy Chemist, It Wil Heal 75 Health Points",new Dictionary<string, int>{ {"Heals Mega Healh",75 } },true,false),

            new Item(4,"Mega Mana Potion",Item.ItemType.Consumable,"Potion Created By The Crazy Chemist, It Wil Heal 75 Mana Points",new Dictionary<string, int>{{"Heals Mega Mana" ,75} },true,false),

            new Item(5,"Wolfs Bane",Item.ItemType.Craftables,"A Herb That Is Deadly At First, Can Be Used To Craft Potions",new Dictionary<string, int>{ {"Used for Crafting",0 } },true,false),

            new Item(6,"Corpse Flower",Item.ItemType.Craftables,"The Flower Is Blood Red,Can Be Used To Craft Potions",new Dictionary<string, int>{{"Used For Crafting",0}},true,false),

            new Item(7,"Gold Ring",Item.ItemType.Craftables,"This Ring Belongs To The Cowards Family, He Would Love It If You Returned It", new Dictionary<string, int>{{"Quest Item",0}},true,false),
            
            new Item(8,"Bloodied Wand Of Hell",Item.ItemType.QuestItem,"This Staff Lets The Holder Pass The Portal The Priest Places",new Dictionary<string, int>{{"Quest Item",0}},false,false),
        };
    }
 
}
