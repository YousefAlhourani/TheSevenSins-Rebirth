using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class DropRespawnController : MonoBehaviour
    {
        [SerializeField] private float fallDamage;
        [SerializeField] Transform tempPosition; //Position of the main character
        private Vector3 savedPos; //saved position incase of fall.
        GabrielsSystemManager player;
        void Start()
        {
            tempPosition.GetComponent<Transform>();
            savedPos = tempPosition.position;
            
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "DropRespawn")
            {
                player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<GabrielsSystemManager>() ;
                player.TakeDamage(fallDamage);
                tempPosition.position = savedPos;
            }
        }
    }
