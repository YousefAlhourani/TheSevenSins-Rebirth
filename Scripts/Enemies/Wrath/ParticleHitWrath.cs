using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHitWrath : MonoBehaviour
{
    
    public Collider DamageCollider;
    ParticleSystem RockSystem;
    [SerializeField] float ColliderOn;
    private void Start()
    {
        RockSystem = GetComponent<ParticleSystem>();
        DamageCollider.enabled = false;
        
    }

    private void Update()
    {
        ColliderOn += Time.deltaTime;
        if(ColliderOn>=0.85f)
        {
            DamageCollider.enabled = true;
        }
        else
        {
            DamageCollider.enabled = false;
        }
    }



}
