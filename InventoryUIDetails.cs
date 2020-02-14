using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InventoryUIDetails : MonoBehaviour
{
    Item item;
    Button selectedItemButton;
    public Text itemNameText, itemDescriptionText;
    InventoryUI uiControl;


    private void Start()
    {
        uiControl = FindObjectOfType<InventoryUI>();
        gameObject.SetActive(false);
    }
    public void SetItem(Item item,Button selectedButton)
    {
        gameObject.SetActive(true);
        this.item = item;
        selectedItemButton = selectedButton;
        itemNameText.text = item.itemName;
        itemDescriptionText.text = item.itemDescription;
        selectedItemButton.onClick.AddListener(OnItemInteract);
    }

    public void OnItemInteract()
    {
        InventoryUIItem itemUI = selectedItemButton.GetComponent<InventoryUIItem>() ;
        if (item.ItemTypes==Item.ItemType.Consumable)
        {
            if (item.Stackable)
            {
                if(itemUI.Amount>1)
                {
                    itemUI.UpdateCountConsume();
                    InventoryController.Instance.consumable.ConsumeItem(item);

                }
                else
                
                {
                    InventoryController.Instance.RemoveItem(item);
                    InventoryController.Instance.consumable.ConsumeItem(item);
                    Destroy(selectedItemButton.gameObject);
                    uiControl.ItemRemoved(selectedItemButton);
                    RemoveItemDetails();
                }
            }

            else
            {
                InventoryController.Instance.RemoveItem(item);
                InventoryController.Instance.consumable.ConsumeItem(item);
                Destroy(selectedItemButton.gameObject);
                uiControl.ItemRemoved(selectedItemButton);
                RemoveItemDetails(); //Remember to copy this to other types of Items.
            }


        }
        else if(item.ItemTypes==Item.ItemType.Craftables)
        {
            Debug.Log("Crafting Item Cant Do Anything");
        }

        else if(item.ItemTypes==Item.ItemType.QuestItem)
        {
            Debug.Log("Questing Item");
        }
        else
        item = null;
        
    }

    void RemoveItemDetails()
    {
        gameObject.SetActive(false);
    }

   
}
