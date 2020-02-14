using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public Transform[] CheckPoints;
    [HideInInspector]
    public int CurrentIndex;
    Vector3 CurrentCheckPointPos;
    

    public Vector3 ReturnPos()
    {
        return CurrentCheckPointPos;
    }
}
