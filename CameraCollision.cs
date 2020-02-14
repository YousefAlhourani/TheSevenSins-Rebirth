using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{

    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;
    public float smooth = 10f;
    Vector3 dollyDirection;
    public Vector3 dollyDirAdjusted;
    public float distance;

    void Awake()
    {
        dollyDirection = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }

    private void Update()
    {
        Vector3 desiredCameraPosition = transform.parent.TransformPoint(dollyDirection * maxDistance);

        RaycastHit hit;
        if(Physics.Linecast(transform.parent.position, desiredCameraPosition,out hit))
        {
            if (hit.transform.tag != "Enemy" && hit.transform.tag != "NPC" &&hit.transform.tag!="Player"&&hit.transform.tag!="AutoSave")
            {
                Debug.Log(hit.transform.name);
                distance = Mathf.Clamp(hit.distance * 0.9f, minDistance, maxDistance);
            }
        }
        else
        {
            distance = maxDistance;
        }
        
    }
    private void LateUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, dollyDirection * distance, Time.deltaTime * smooth);
    }





}
