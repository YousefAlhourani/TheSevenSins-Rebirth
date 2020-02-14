using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollider : MonoBehaviour
{

    public float Damage;
    bool HasHit { get; set; }

    private void Start()
    {
        HasHit = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!HasHit)
            {
                if (!GabrielsSystemManager.gabie.IsDefend)
                {
                    other.GetComponent<GabrielsSystemManager>().TakeDamage(Damage);
                }
                HasHit = true;
            }

        }
    }
}
