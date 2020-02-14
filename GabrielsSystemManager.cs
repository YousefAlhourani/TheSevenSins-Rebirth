using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;



public class GabrielsSystemManager : MonoBehaviour
{
    #region Gabies Stats
    [SerializeField] private float m_CharactersHealth=100f; //Gabriels Health
    [SerializeField] private float m_CharactersStamina = 100f; //Gabriels Stamina for Heavy attacks and such
    //[SerializeField] private float m_CharactersSpecialAbility = 0.1f; //Gabriels special Attack.

    public float Health { get { return m_CharactersHealth; }  set { m_CharactersHealth=value;} }
    public float Stamina { get { return m_CharactersStamina; }  set { m_CharactersStamina=value;} }
    //public float SpecialAbilty { get { return m_CharactersSpecialAbility; } set { m_CharactersSpecialAbility = value; } }


    //private float maxSpecialAbility = 1f;
    #endregion


    #region Gabies States
    private bool _isAttack = false; //Sword is moving to attack
    private bool _isDefend = false; //Sword is moving to defend
    private bool _isDead = false; //player is dead so stop everything.
    private bool _isChanneling = false; //player is channeling special attack.
    private bool _isInteract = false;//interacting with other objects/npcs;
    

    public bool IsAttack { get { return _isAttack; } set { _isAttack=value;} }
    public bool IsDefend { get { return _isDefend; }  set { _isDefend=value ;} }
    public bool IsDead { get { return _isDead; } set { _isDead=value;} }
    public bool IsChanneling { get { return _isChanneling; } set { _isChanneling=value;} }
    public bool IsInteract { get { return _isInteract; } set { _isInteract = true; } }



    #endregion


    SaveCharacterStats playerStats;




    
    //public float specialAbilityRate = 0.1f;
    public static GabrielsSystemManager gabie; //Singleton controller.

    
    public Canvas gameOver;
    bool hasSaved = false;

    //Used to Pause Player On Interaction Or Death.
    GabrielsMovementController movementController;
    GabiesAnimationController animatorController;
    ThirdPersonCameraController cameraController;
    
    

    public float staminaCost;
    public float staminaRegen;


    void Awake()
    {
        cameraController = FindObjectOfType<ThirdPersonCameraController>();
        movementController = FindObjectOfType<GabrielsMovementController>();
        animatorController = FindObjectOfType<GabiesAnimationController>();
        AudioManager.Instance.PlaySong(3, 0.2f);

        if(PlayerPrefs.GetInt("SaveHealth",0)==1)
        {
            Health = 100f;
            Stamina = 100f;
            PlayerPrefs.SetInt("SaveHealth", 0);
        }


        if (Time.timeScale == 0)
        {
            Time.timeScale = 1f;
        }

        if (gabie != null && gabie != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gabie = this;
        }
    }



    private void Start()
    {
       
        GameEvents.SaveInitiated += OnSaveCharacterStats;
        LoadCharacterStats();
        
       
    }

    private void FixedUpdate()
    {
        if (IsDefend)
        {
            Stamina -= staminaCost;
        }
        if(!IsDefend && Stamina<=100)
        {
            Stamina += staminaRegen;
        }
    }

    //public void SpecialAbilityManager()
    //{
    //    if (SpecialAbilty < maxSpecialAbility)
    //    {
    //        SpecialAbilty += specialAbilityRate;
    //    }
    //    if (SpecialAbilty >= maxSpecialAbility)
    //    {
    //        SpecialAbilty = maxSpecialAbility;
    //    }
    //}



    public void TakeDamage(float Damage)
    {

        if (!IsDefend)
        {
            Health -= Damage;
        }
        if (Health <= 0)
        {
            Die();
        }
    }

   

    public void Die()
    {
        Time.timeScale = 0;
        gameOver.gameObject.SetActive(true);
        PlayerPrefs.SetInt("SaveHealth", 1);
    }

   

    public void OnSaveCharacterStats()
    {

        playerStats = new SaveCharacterStats()
        {
            Health = Health,
            Stamina = Stamina,
        };
        SaveLoadSystem.Save<SaveCharacterStats>(playerStats, "PlayerStats");
    }

  

   
    public void LoadCharacterStats()
    {
        if(SaveLoadSystem.SaveExists("PlayerStats"))
        {
            SaveCharacterStats stats = SaveLoadSystem.Load<SaveCharacterStats>("PlayerStats");
            this.Health = stats.Health;
            this.Stamina = stats.Stamina;
        }
    }

    public void PauseCharacter()
    {
        animatorController.enabled = false;
        cameraController.enabled = false;
        movementController.Interact = true;
    }

    public void ResumeCharacter()
    {
        animatorController.enabled = true;
        cameraController.enabled = true;
        movementController.Interact = false;
    }
    
}



//To write to Text Folders.
[System.Serializable]
public class SaveCharacterStats 
{
    public float Health { get; set; }  
    public float Stamina { get; set; }  
}







