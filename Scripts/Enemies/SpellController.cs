using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour
{
    [SerializeField] private float spellDamage;
    [SerializeField] float speed;
    private Rigidbody rb;
    private Transform target;

    private void Awake()
    {
        target = FindObjectOfType<GabrielsSystemManager>().gameObject.transform;
        rb=GetComponent<Rigidbody>();
        transform.rotation.SetLookRotation(target.position);
        
    }
    private void Start()
    {
        rb.AddForce(transform.forward * speed );
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            
                other.GetComponent<GabrielsSystemManager>().TakeDamage(spellDamage / 2f);
                Destroy(gameObject);  
            
        }
       else
        {
            Invoke("SpellDeath", 3);
        }
    }

  

    void SpellDeath()
    {
        Destroy(this.gameObject);
    }

}
