using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PriestBarrier : MonoBehaviour
{
    public ParticleSystem Barrier;

    public NavMeshObstacle barrier;
    public List<GameObject> Enemies;
    int EnemyCount;
    int DefaultEnemyCount;

    private void Start()
    {
        
        EnemyCount = Enemies.Count;
        DefaultEnemyCount = Enemies.Count;
        if(PlayerPrefs.GetInt("PriestBarrier",0)==1)
        {
            barrier.enabled = false;
            Barrier.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (PlayerPrefs.GetInt("PriestBarrier", 0) != 1)
            {
                for (int i = 0; i < Enemies.Count; i++)
                {
                    if (Enemies[i] == null)
                    {
                        Enemies.RemoveAt(i);
                        EnemyCount--;
                        
                    }
                }
                if (EnemyCount == 0)
                {
                    PlayerPrefs.SetInt("PriestBarrier", 1);
                    barrier.enabled = false;
                    Barrier.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    gameObject.GetComponent<Collider>().enabled = false;
                }
            }

        }
    }

   
}
