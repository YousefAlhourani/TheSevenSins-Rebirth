using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathsCutSceneController : MonoBehaviour
{
    [Header("References Related To the Cutscene")]
    public GameObject Wrath;
    public Rigidbody[] WrathsStoneBody;
    public Camera CutSceneCamera;
    public Animator CutSceneAnimation;
    public GameObject Player;
    public GameObject NamePopUp;
    public GameObject CanvasPopUp;
    public GameObject MainCamera;
    
  



    private void Awake()
    {
        Player = FindObjectOfType<GabrielsSystemManager>().gameObject;
        CutSceneCamera.enabled = false; ;
        CutSceneAnimation.enabled = false;
       for(int i=0;i<WrathsStoneBody.Length;i++)
        {
            WrathsStoneBody[i].isKinematic = true;
        }
        Wrath.SetActive(false);
    }
  

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {  
            CutSceneCamera.enabled = true; 
            CutSceneAnimation.enabled = true;
            Player.SetActive(false);
            MainCamera.SetActive(false);
           AudioManager.Instance.ChangeSong(3,0.2f);
            
            this.gameObject.GetComponent<Collider>().enabled = false;
        }
    }

    public void ToggleWrath()
    {
        for (int i = 0; i < WrathsStoneBody.Length; i++)
        {
            WrathsStoneBody[i].isKinematic = false;
            WrathsStoneBody[i].AddExplosionForce(5f, Wrath.transform.position, 10f);
            
        }
        Invoke("RemoveBodyParts", 4f);
        Wrath.SetActive(true);
        CanvasPopUp.SetActive(true);
        NamePopUp.SetActive(true);
        AudioManager.Instance.PlaySong(2, 0.2f);
    }

    public void ResetCameras()
    {
        Player.SetActive(true);
        MainCamera.SetActive(true);
        CutSceneCamera.enabled=false;
        NamePopUp.SetActive(false);
        CutSceneAnimation.enabled = false;
        
    }

    void RemoveBodyParts()
    {
        for(int i=0;i<WrathsStoneBody.Length;i++)
        {
            WrathsStoneBody[i].gameObject.SetActive(false);
        }
    }

 
    
}
