using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldItem : MonoBehaviour
{
    public GameObject popUpText;
    public Text itemText;
    bool claimedItem;
    private CollectedItemSet collectedItemSet;
    private UniqueID uniqueID;
    public bool IsBarrierItem;

    void Awake()
    {
        popUpText = FindObjectOfType<ItemDatabase>().transform.Find("itemPopUp").gameObject;
    }

    void Start()
    {
        uniqueID = GetComponent<UniqueID>();
        collectedItemSet = FindObjectOfType<CollectedItemSet>();

        if(collectedItemSet.CollectedItems.Contains(uniqueID.ID))
        {
            Destroy(this.gameObject);
            return;
        }
    }


    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            popUpText.SetActive(true);
            itemText.text = gameObject.name;
            if (Input.GetButtonDown("A Button"))
            {

                if (!claimedItem)
                {
                    collectedItemSet.CollectedItems.Add(GetComponent<UniqueID>().ID);
                    InventoryController.Instance.GiveItem(gameObject.name); 
                    if(IsBarrierItem)
                    {
                        PlayerPrefs.SetInt("BarrierPassing", 1);
                    }
                    popUpText.SetActive(false);
                    Destroy(gameObject);
                }
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            popUpText.SetActive(false);
        }
    }
}
