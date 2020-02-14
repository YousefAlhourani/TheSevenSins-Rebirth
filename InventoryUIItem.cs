using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIItem : MonoBehaviour
{
    public Item item;

    public Text itemText;
    public Image itemIcon;
    public Text itemCount;
    public int Amount;

    public void SetItem(Item item)
    {
        this.item = item;
        SetupItemValues();   
    }

    void SetupItemValues()
    {
        Amount = 1;
        itemText.text= item.itemName;
        itemIcon.sprite = Resources.Load<Sprite>("UI/Items/" + item.itemName);
        itemCount.text = Amount.ToString();
    }

    public void OnSelectItemButton()
    {
        InventoryController.Instance.SetItemDetails(item, GetComponent<Button>());
    }

    public void UpdateCount()
    {
        Amount++;
        itemCount.text = Amount.ToString();
    }

    public void UpdateCountConsume()
    {
        Amount--;
        itemCount.text = Amount.ToString(); 
    }
}
