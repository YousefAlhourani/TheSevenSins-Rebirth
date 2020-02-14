using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKnightSword : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.GetComponent<GabrielsSystemManager>().TakeDamage(Damage);
        }
    }
}
