using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{

    public float CameraMoveSpeed = 120.0f; //The speed of which the Camera Rotates.
    public GameObject CameraFollowObj;     // The Object That You Want To Follow.
    Vector3 FollowPos;                      
    public float clampAngleMax = 45.0f;     //Maximum Angle Rotation
    public float clampAngleMin = 15f;       //Minimum Angle Rotation
    public float inputSensitivity = 150f;   //Speed of the rotation
    public GameObject CameraObj;            //Refernece to the Camera
    public GameObject PlayerObj;            //Reference to the Player Object
    public float inputX;                    //Input on Camera X ( Horizontal Input)
    public float inputY;                    //Input on Camera Y ( Vertical Input)
    public float finalInputX;               
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;              //Value of FinalInputX*InputSensitivity*Time.delta
    private float rotX = 0.0f;              //Value of FinalInputZ*InputSensitivity*Time.delta

    private void Start()
    {
        //ThirdPersonCameraController.CS
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        CameraFollowObj = FindObjectOfType<GabrielsSystemManager>().gameObject;
        PlayerObj = FindObjectOfType<GabrielsSystemManager>().gameObject;
        transform.position = PlayerObj.transform.position;
    }
    private void Update()
    {
        //Setup Of The Rotation For Xbox Input
        float inputX = Input.GetAxis("Camera X");
        float inputZ = Input.GetAxis("Camera Y");
        finalInputX = inputX;
        finalInputZ = inputZ;
        //instead of passing InputX and inputZ directly this gives you 
        //more way to configure the camera speed

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;
        //clampAngleMin and clampAngleMax are defined in the inspector.
        //They ensure the camera won't rotate outside of the scene.
        rotX = Mathf.Clamp(rotX, clampAngleMin, clampAngleMax);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0f);
        transform.rotation = localRotation;
    }
    private void LateUpdate()
    {
        CameraUpdater();
    }
    void CameraUpdater()
    {
        //Make Sure We Are Following Player
        Transform target = CameraFollowObj.transform;
    
        //Move Towards Player
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
