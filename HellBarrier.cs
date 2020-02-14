using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HellBarrier : MonoBehaviour
{
    public ParticleSystem Barrier;

    public NavMeshObstacle barrier;
    public List<GameObject> Enemies;
    int EnemyCount;
    int DefaultEnemyCount;

    private void Start()
    {
        EnemyCount = Enemies.Count;
        
        if (PlayerPrefs.GetInt("HellBarrier", 0) == 1)
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
            if (PlayerPrefs.GetInt("HellBarrier", 0) != 1)
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
                    PlayerPrefs.SetInt("HellBarrier", 1);
                    barrier.enabled = false;
                    Barrier.Stop(true, ParticleSystemStopBehavior.StopEmitting);
                    gameObject.GetComponent<Collider>().enabled = false;
                }
            }

        }
    }
}
