using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WarningForFinalBoss : MonoBehaviour
{
    
    public GameObject WarningUI;
    bool HasPassed { get; set; }

    private void Awake()
    {
        HasPassed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            if (!HasPassed)
            {
                WarningUI.SetActive(true);
                HasPassed = true;
                Invoke("RemoveUI", 3f);

            }
        }
    }

    void RemoveUI()
    {
        WarningUI.SetActive(false);
    }
}
