using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public RectTransform inventoryPanel;
    [SerializeField] Transform itemHolder;
    Item CurrentSelectedItem { get; set; }
    InventoryUIItem ItemContainer { set; get; }
    InventoryUIItem QuickSlots { get; set; }
    public List<Button> inventoryButtons = new List<Button>();
    List<InventoryUIItem> itemUIList = new List<InventoryUIItem>();
    

    
    int currentIndex = 0;
    
    void Awake()
    {
        //Inventory UI
        UIEventHandler.OnItemAddedToInventory += ItemAdded;
        UIEventHandler.OnItemRemovedFromInventory += RemoveItem;
       
        ItemContainer = Resources.Load<InventoryUIItem>("UI/Slot");
        ItemContainer.GetComponent<Transform>().localScale = new Vector3(1f, 1f, 1f);
        inventoryPanel.gameObject.SetActive(false);  
        
    }
    
    public void ItemAdded(Item item)
    {
        if (item.Stackable && CheckIfItemIsInInventory(item))
        {
            for (int i = 0; i < itemUIList.Count; i++)
            {
                if (itemUIList[i].item == item)
                {
                    itemUIList[i].UpdateCount();
                }
            }

        }
        else if(!item.Stackable || !CheckIfItemIsInInventory(item))
        {
            InventoryUIItem emptyItem = Instantiate(ItemContainer);
            emptyItem.SetItem(item);
            itemUIList.Add(emptyItem);
            emptyItem.transform.SetParent(itemHolder);
            emptyItem.transform.localScale = new Vector3(1f, 1f, 1f);
            inventoryButtons.Add(emptyItem.GetComponent<Button>());
        }
    }


    public void RemoveItem(Item item)
    {

        if (item.Stackable && CheckIfItemIsInInventory(item))
        {
            for (int i = 0; i < itemUIList.Count; i++)
            {
                if (itemUIList[i].item == item)
                {
                    if (itemUIList[i].Amount > 1)
                    {
                        itemUIList[i].UpdateCountConsume();
                    }
                    else
                    {
                        InventoryController.Instance.RemoveItem(item);
                        Destroy(itemUIList[i].gameObject);
                        itemUIList.Remove(itemUIList[i]);
                        ItemRemoved(inventoryButtons[i]);
                        
                    }

                }
            }
        }

        else
        {
            for (int i = 0; i < itemUIList.Count; i++)
            {
                if (itemUIList[i].item == item)
                {
                    InventoryController.Instance.RemoveItem(item);
                    Destroy(itemUIList[i].gameObject);
                    itemUIList.Remove(itemUIList[i]);
                    ItemRemoved(inventoryButtons[i]);
                    
                }
            }
        }

    }

    


    public bool CheckIfItemIsInInventory(Item item)
    {
       for(int i=0;i<itemUIList.Count;i++)
       {
            if(itemUIList[i].item==item)
            {
                return true;
            }
       }
       
       return false;
    }

    public void UINavigiation()
    {
        if(inventoryPanel.gameObject.activeSelf && inventoryButtons[0]!=null)
        {
            inventoryButtons[0].Select();
        }

    }

    public void ItemRemoved(Button button)
    {
        inventoryButtons.Remove(button);
        itemUIList.Remove(button.GetComponent<InventoryUIItem>());
       // if (inventoryButtons.Count > 0)
       // {

        //    inventoryButtons[0].Select();
     //   }
    }

}
