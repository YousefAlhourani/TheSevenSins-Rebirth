using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathHit : MonoBehaviour
{
    Collider TailHitBox;
    public float Damage;
    public float PushBackForce;
    public bool HasHit { get; set; }
    private void Start()
    {
        TailHitBox = GetComponent<Collider>();
        TailHitBox.enabled = false;
        HasHit = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!HasHit)
            {
                HasHit = true;
                if (!GabrielsSystemManager.gabie.IsDefend)
                {
                    Vector3 dir = transform.position - other.transform.position;
                    dir.Normalize();
                    other.GetComponent<Rigidbody>().AddForce(-dir * PushBackForce);
                    other.GetComponent<GabrielsSystemManager>().TakeDamage(Damage);
                }
            }
        }
    }
}
