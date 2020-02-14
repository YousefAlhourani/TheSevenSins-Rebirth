using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class BarrierPassing : MonoBehaviour
{
    public NavMeshObstacle barrier;
    public ParticleSystem BarrierPS;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PlayerPrefs.GetInt("BarrierPassing", 0) == 1)
            {
                barrier.enabled = false;
                BarrierPS.Stop();
                gameObject.GetComponent<Collider>().enabled = false;
            }
            else
            {
                barrier.enabled = true;
            }
        }
    }
}
