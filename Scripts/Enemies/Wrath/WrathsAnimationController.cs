using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathsAnimationController : MonoBehaviour
{
    Animator anime;
    public Collider TailWhip;
    Transform target;
    public GameObject GroundAttack;
    public WrathHit TailHit;
    public AudioSource WingFlapping;
    public AudioSource TailAttack;
    public AudioSource FirstRoar;
    public AudioSource IdleSFX;
    public AudioSource RangedAttackSFX;
    
    private void Start()
    {
        target = GabrielsSystemManager.gabie.transform;
        anime = GetComponent<Animator>();
    }

    public void IdleSFXMEth()
    {
        IdleSFX.Play();
    }


    public void TailWhipColliderOn()
    {
        TailWhip.enabled = true;
    }

    public void TailWhipColliderOff()
    {
        TailWhip.enabled = false;
    }

    public void WakeUp()
    {
        FirstRoar.Play();
    }
    public void RangedAttack()
    {
        RangedAttackSFX.Play();
        GameObject t = Instantiate(GroundAttack, target.position, Quaternion.identity);
        Destroy(t, 5f);
    }

    public void TailHitReset()
    {
        TailHit.HasHit = false;
    }

    public void WingEffect()
    {
        WingFlapping.Play();
    }

    public void TailWhipSFX()
    {
        TailAttack.Play();
    }
        
}
