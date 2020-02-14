using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GabiesAnimationController : MonoBehaviour
{
    Animator anime;
    [SerializeField] Collider swordCollider;
    [SerializeField] ParticleSystem swordTrail;
    public static GabiesAnimationController Instance;
    [SerializeField] ParticleSystem Shield;
    int noOfClicks;
    bool canClick;
    int baseDamageSword;
    

    private void Awake()
    {
        if(Instance!=null&&Instance!=this)
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
        anime = GetComponent<Animator>();
        noOfClicks = 0;
        canClick = true;
        baseDamageSword = swordCollider.gameObject.GetComponent<SwordController>().swordDamage;
        swordTrail.Stop();
        Shield.Stop();
    }
    private void Update()
    {
        if(Input.GetButtonDown("Right Trigger"))
        {
            ComboStarter();
        }

        if(Input.GetButtonDown("Y Button"))
        {
            HeavyAttack();
        }

        if(Input.GetButtonDown("Left Trigger") && (anime.GetFloat("inputX")+anime.GetFloat("inputY"))==0)
        {
            Block();
        }
        else if(Input.GetButtonUp("Left Trigger") || (anime.GetFloat("inputX") + anime.GetFloat("inputY")) != 0 || GabrielsSystemManager.gabie.Stamina<=0)
        {
            anime.SetBool("Block", false);
            GabrielsSystemManager.gabie.IsDefend = false;
            TurnOffShieldFX();
           
        }
    }

    void Block()
    {
        
        anime.SetBool("Block",true);
        GabrielsSystemManager.gabie.IsDefend = true;  
    }

    void ComboStarter()
    {
        if(canClick)
        {
            noOfClicks++;
        }

        if(noOfClicks==1)
        {
            anime.SetInteger("comboAnimation", 31);
        }
        swordCollider.gameObject.GetComponent<SwordController>().swordDamage = baseDamageSword;
    }

    public void HeavyAttackCheck()
    {
        
            anime.SetInteger("comboAnimation", 4);
        
        
    }
    public void HeavyAttack()
    {
        if (noOfClicks == 0)
        {
            anime.SetInteger("comboAnimation", 15);
            swordCollider.gameObject.GetComponent<SwordController>().swordDamage = baseDamageSword * 2;
        }
        else
        {
            ComboCheck();
        }
    }

    public void ComboCheck()
    {
        canClick = false;

        if(anime.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && noOfClicks ==1)
        {
            anime.SetInteger("comboAnimation", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else if(anime.GetCurrentAnimatorStateInfo(0).IsName("Attack_1") && noOfClicks>=2)
        {
            anime.SetInteger("comboAnimation", 33);
            canClick = true;
        }
        else if(anime.GetCurrentAnimatorStateInfo(0).IsName("Attack_2")&&noOfClicks==2)
        {
            anime.SetInteger("comboAnimation", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else if(anime.GetCurrentAnimatorStateInfo(0).IsName("Attack_2")&&noOfClicks>=3)
        {
            anime.SetInteger("comboAnimation", 6);
            canClick = true;
        }
        else if(anime.GetCurrentAnimatorStateInfo(0).IsName("Attack_3") && noOfClicks==3)
        {
            anime.SetInteger("comboAnimation", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else if (anime.GetCurrentAnimatorStateInfo(0).IsName("Attack_3") && noOfClicks >= 4)
        {
            anime.SetInteger("comboAnimation", 12);
            canClick = true;
            noOfClicks = 0;
        }
        else if(anime.GetCurrentAnimatorStateInfo(0).IsName("combo"))
        {
            anime.SetInteger("comboAnimation", 4);
            canClick = true;
            noOfClicks = 0;
        }
        else
        {
            anime.SetInteger("comboAnimation", 4);
            canClick = true;
            noOfClicks = 0;
        }
    }




    public void TurnOnSwordCollider()
    {
        swordCollider.enabled = true;
    }

    public void TurnOffSwordCollider()
    {
        swordCollider.enabled = false;
    }

    public void TurnOnSwordFx()
    {
        AudioManager.Instance.PlaySoundEffect(0);
        //swordTrail.Play();
    }

    public void TurnOffSwordFx()
    {
        //AudioManager.Instance.TurnOffSoundEffect(0);
        //swordTrail.Stop();
    }

    public void TurnOnShieldFX()
    {
        Shield.Play();
        
    }
    public void TurnOffShieldFX()
    {
        Shield.Stop();
    }
}
