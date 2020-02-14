using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningController : MonoBehaviour
{
    [SerializeField] int skCount;
    [SerializeField] int necroCount;
    public GameObject[] skeletonKnight;
    public GameObject[] necroMancer;
    //public ParticleSystem barrier;
    public GameObject[] wayPoints;
    int EnemyCount { get; set; }

    private void Start()
    {

        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }


}
