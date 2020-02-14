using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItemSet : MonoBehaviour
{
    public HashSet<string> CollectedItems { get; set; } = new HashSet<string>();

    private void Awake()
    {
        GameEvents.SaveInitiated += Save;
        Load();
    }

    void Save()
    {
        SaveLoadSystem.Save(CollectedItems, "CollectedItems");
    }

    void Load()
    {
        if(SaveLoadSystem.SaveExists("CollectedItems"))
        {
            CollectedItems = SaveLoadSystem.Load<HashSet<string>>("CollectedItems");
        }
    }
}
