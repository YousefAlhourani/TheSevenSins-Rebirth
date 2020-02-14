using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispController : MonoBehaviour
{
    public GameObject player;

    [SerializeField]
    float speed = 10f;

    private void Update()
    {
        OrbitAroundPlayer(); //Orbits around the main character;
    }

    void OrbitAroundPlayer()
    {
       
        transform.RotateAround(player.transform.position,Vector3.up  ,speed * Time.deltaTime); 
    }
}
