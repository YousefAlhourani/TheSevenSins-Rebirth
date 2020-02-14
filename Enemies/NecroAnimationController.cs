using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroAnimationController : MonoBehaviour
{
    public GameObject spawnPoint;
    public GameObject projectile;
    public GameObject spellSphere;
    NecromancerController instance;
    public AudioSource NecroAttackSFX;
    Animator anime;
    void Start()
    {
        anime = GetComponent<Animator>();
        instance = GetComponentInParent<NecromancerController>();
    }

    public void PerformAttack()
    {
        if (spawnPoint != null)
        {

            GameObject shot=Instantiate(projectile, spawnPoint.transform.position, spawnPoint.transform.rotation);
            NecroAttackSFX.Play();
            shot.transform.localRotation = spawnPoint.transform.rotation;
        }

    }

    public void SpellSphereOn()
    {
        spellSphere.SetActive(true);
    }
    public void SpellSphereOff()
    {
        spellSphere.SetActive(false);
    }

    public void ResetAttack()
    {
        instance.ResetAttack();
    }
}
