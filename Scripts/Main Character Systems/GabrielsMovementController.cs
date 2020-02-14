using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabrielsMovementController : MonoBehaviour
{
    [SerializeField]
    float speed = 10f;
    public float turnSpeed = 120f;
    Camera cam;
    public Animator anim;
    public static GabrielsMovementController Instance;
    public bool Interact { get; set; }
    float InputX;
    float InputZ;
    Vector3 desiredMoveDirection; 
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        InputX= Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");
        
      
       if(Interact)
        {
            ResetAnimtion();
        }
       else
        {
            Move();
        }
    }
    public void ResetAnimtion()
    {
        anim.Play("Idle");
    }
    
    private void Move()
    {
        anim.SetFloat("inputX", InputX,0.0f,Time.deltaTime*2f);
        anim.SetFloat("inputY", InputZ,0.0f,Time.deltaTime*2f);
        var forward = cam.transform.forward;
        var right = cam.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();
        desiredMoveDirection = forward * InputZ + InputX * right;
        transform.position += desiredMoveDirection * speed * Time.deltaTime;
        if(desiredMoveDirection!=Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), turnSpeed * Time.deltaTime);
        }  
    }   
}
