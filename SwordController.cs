using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    private int[] attack=new int[] {0,4,8,10};
    public ParticleSystem swordTrail;
    public static SwordController Instance;
    public int swordDamage;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
            Instance = this;
        swordTrail.Stop();
    }
    private void OnTriggerEnter(Collider other)
    {
       Vector3 Hit= other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
        if (other.tag == "Enemy")
        {
            AudioManager.Instance.PlaySong(1);
            other.GetComponent<IEnemy>().TakeDamage(swordDamage);
            swordTrail.Play();
            swordTrail.transform.position = Hit;
        }

        if(other.tag=="Wrath")
        {
            AudioManager.Instance.PlaySong(1);
            other.GetComponent<WrathsDamageController>().Hit(swordDamage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        swordTrail.Stop();
    }



}
