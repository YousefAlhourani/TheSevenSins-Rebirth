using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAnimationController : MonoBehaviour
{
    SkeletonKnightController instance;
    Animator anime;
    public BoxCollider Sword;
    public AudioSource SwordSlash;
    public AudioSource Die;
    
    void Start()
    {
        anime = GetComponent<Animator>();
        instance = GetComponentInParent<SkeletonKnightController>(); 
    }

    


    public void ResetAttack()
    { 
        instance.ResetAttack();
    }
    public void EnableSwordCollider()
    {
        SwordSlash.Play();
        Sword.enabled = true;
    }
    public void DisableSwordCollider()
    {
        Sword.enabled = false;
    } 
    
    public void DestroyObjecet()
    {
       Destroy(instance.gameObject);

    }

    public void DieSFX()
    {
        Die.Play();
    }

    
}


