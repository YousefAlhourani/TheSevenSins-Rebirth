using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class WrathsController : MonoBehaviour, IEnemy
{
    [Header("General Enemy Setup")]
    public float Health;
    float MaxHealth;
    public int ID { get; set; }
    public Image HealthBar;
    NavMeshAgent agent;
    public Animator anime;
    public Transform target;
    public float TurnSpeed;
    [SerializeField] bool IsDead;
    public GameObject HealthBarObject;
    public GameObject GameDonePanel;
    public CanvasGroup FadeOut;
    


    [Header("Wraths Movement Input")]
    [SerializeField] Vector3 DefaultPosition;
    [SerializeField] Quaternion DefaultRotation;
    [SerializeField] float AttackRange;

    [Header("Stage One Timers")]
    [SerializeField] float ChaseTimer;
    float DefaultChaseTimer;
    [SerializeField] float AttackTimer;
    float DefaultAttackTimer;
    [SerializeField] float RangedAttackTimer;
    float DefaultRangedAttackTimer;
    [SerializeField] float FireBreathingTimer;
    float DefaultFireBreathingTimer;


    [Header("Stage Two Timers")]

    [SerializeField] float ChaseTimerStageTwo;
    float DefaultChaseTimerStageTwo;
    [SerializeField] float AttackTimerStageTwo;
    float DefaultAttackTimerStageTwo;
    [SerializeField] float RangedAttackTimerStageTwo;
    float DefaultRangedAttackTimerStageTwo;
    [SerializeField] float FireBreathingTimerStageTwo;
    float DefaultFireBreathingTimerStageTwo;


    [Header("Stage Three Timers")]
    [SerializeField] float RangedAttackTimerStageThree;
    float DefaultRangedAttackTimerStageThree;
    [SerializeField] float FireBreathingTimerStageThree;
    float DefaultFireBreathingTimerStageThree;
    [SerializeField] float SpamAttackTimer;
    float DefaultSpamAttackTimer;
    [SerializeField] float ChaseTimerStageThree;
    float DefaultChaseTimerStageThree;
    [SerializeField] float AttackStageThree;
    float DefaultAttackStageThree;

    [Header("Wraths Animation Variables")]
    [SerializeField] private bool StageOne;
    [SerializeField] private bool StageTwo;
    [SerializeField] private bool StageThree;
    public static readonly int hashAttack = Animator.StringToHash("Attack");
    public static readonly int hashIdleState = Animator.StringToHash("Idle");
    public static readonly int hashChasingState = Animator.StringToHash("Chase");
    public static readonly int hashFireAttack = Animator.StringToHash("Ranged Attack");


    float distance;

    void Start()
    {
        GameDonePanel.SetActive(false);
        agent = GetComponent<NavMeshAgent>();
        MaxHealth = Health;
        StageOne = true;
        StageTwo = false;
        StageThree = false;
        AttackRange = agent.stoppingDistance+2f; 
        target = GabrielsSystemManager.gabie.transform;
        ID = 3;
        DefaultPosition = transform.position;
        agent.Warp(DefaultPosition);
        DefaultRotation = transform.rotation;

        //Stage One
        #region stageOne
        DefaultChaseTimer = ChaseTimer;
        DefaultAttackTimer = AttackTimer;
        DefaultRangedAttackTimer = RangedAttackTimer;
        DefaultFireBreathingTimer = FireBreathingTimer;
        #endregion

        //StageTwo Variables
        #region stageTwo
        DefaultChaseTimerStageTwo = ChaseTimerStageTwo;
        DefaultAttackTimerStageTwo = AttackTimerStageTwo;
        DefaultRangedAttackTimerStageTwo = RangedAttackTimerStageTwo;
        DefaultFireBreathingTimerStageTwo = FireBreathingTimerStageTwo;
        #endregion


        //Stage Three Variables
        DefaultRangedAttackTimerStageThree = RangedAttackTimerStageThree;
        DefaultFireBreathingTimerStageThree=FireBreathingTimerStageThree  ;
        DefaultSpamAttackTimer = SpamAttackTimer;
        DefaultAttackStageThree = AttackStageThree;
        DefaultChaseTimerStageThree = ChaseTimerStageThree;

    }

    void Update()
    {
        if (!IsDead)
        {
            distance = Vector3.Distance(target.position, transform.position);

            if (Health <= MaxHealth * 0.7f )
            {
                StageOne = false;
                StageTwo = true;
                StageThree = false;

            }
            if (Health <= MaxHealth * 0.3f)
            {
                StageOne = false;
                StageTwo = false;
                StageThree = true;
            }

            if (StageOne) { PhaseOne(); }
            

            if (StageTwo) { PhaseTwo(); }


            if (StageThree) { PhaseThree(); }

        }
    }

    void PhaseOne()
    {
        RangedAttackTimer -= Time.deltaTime;
        if (RangedAttackTimer > 0)
        {
            if (distance > AttackRange+1f)
            {
                ChaseTimer -= Time.deltaTime;
                if (ChaseTimer <= 0)
                {

                    agent.SetDestination(target.position);
                    FaceTarget();
                    ChaseTimer = DefaultChaseTimer;
                }
            }

            if (distance <= AttackRange + 1f)
            {
                AttackTimer -= Time.deltaTime;
                if (AttackTimer <= 0)
                {
                    anime.SetTrigger(hashAttack);
                    AttackTimer = DefaultAttackTimer;
                }
            }
        }
        if (RangedAttackTimer < 0)
        {

            anime.SetBool(hashFireAttack, true);

            FireBreathingTimer -= Time.deltaTime;
            if (FireBreathingTimer <= 0)
            {
                anime.SetBool(hashFireAttack, false);
                RangedAttackTimer = DefaultRangedAttackTimer;
                FireBreathingTimer = DefaultFireBreathingTimer;
            }


        }

    }

    void PhaseTwo()
    {
        RangedAttackTimerStageTwo -= Time.deltaTime;
        if (RangedAttackTimerStageTwo > 0)
        {
            if (distance > AttackRange+1f)
            {
                ChaseTimerStageTwo -= Time.deltaTime;
                if (ChaseTimerStageTwo <= 0)
                {

                    agent.SetDestination(target.position);
                    FaceTarget();
                    ChaseTimerStageTwo = DefaultChaseTimerStageTwo;
                }
            }

            if (distance <= AttackRange + 1f)
            {
                AttackTimerStageTwo -= Time.deltaTime;
                if (AttackTimerStageTwo <= 0)
                {
                    anime.SetTrigger(hashAttack);
                    AttackTimerStageTwo = DefaultAttackTimerStageTwo;
                }
            }
        }
        if (RangedAttackTimerStageTwo < 0)
        {

            anime.SetBool(hashFireAttack, true);

            FireBreathingTimerStageTwo -= Time.deltaTime;
            if (FireBreathingTimerStageTwo <= 0)
            {
                anime.SetBool(hashFireAttack, false);
                RangedAttackTimerStageTwo = DefaultRangedAttackTimerStageTwo;
                FireBreathingTimerStageTwo = DefaultFireBreathingTimerStageTwo;
            }


        }
    }



    void PhaseThree()
    {
        if (SpamAttackTimer > 0)
        {
            RangedAttackTimerStageThree -= Time.deltaTime;

            if (RangedAttackTimerStageThree <= 0)
            {
                anime.SetBool(hashFireAttack, true);

                FireBreathingTimerStageThree -= Time.deltaTime;
                if (FireBreathingTimerStageThree <= 0)
                {
                    anime.SetBool(hashFireAttack, false);
                    RangedAttackTimerStageThree = DefaultRangedAttackTimerStageThree;
                    FireBreathingTimerStageThree = DefaultFireBreathingTimerStageThree;
                }
            }
        }
        else if(SpamAttackTimer<=0)
        {
            if (Health <= MaxHealth * 0.15f)
            {
                SpamAttackTimer = DefaultSpamAttackTimer;
            }
            else
            {
                if (distance > AttackRange + 1f)
                {
                    ChaseTimerStageThree -= Time.deltaTime;
                    if (ChaseTimerStageThree <= 0)
                    {

                        agent.SetDestination(target.position);
                        FaceTarget();
                        ChaseTimerStageThree = DefaultChaseTimerStageThree;
                    }
                }

                if (distance <= AttackRange + 1f)
                {
                    AttackStageThree -= Time.deltaTime;
                    if (AttackStageThree <= 0)
                    {
                        anime.SetTrigger(hashAttack);
                        AttackStageThree = DefaultAttackStageThree;
                    }
                }
            }
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

   
    public void TakeDamage(int amount)
    {
        Health -= amount;
        HealthBar.fillAmount = Health/1000;
        if(Health<=0)
        {
            Die();
        }
    }

    public void Die()
    {
        CombatEvents.EnemyDied(this);
        HealthBarObject.SetActive(false);
        FadeOut.alpha = 0;
        GameDonePanel.SetActive(true);
        Time.timeScale = 0.5f;
        GabrielsSystemManager.gabie.PauseCharacter();
        anime.speed = 0;
        AudioManager.Instance.ChangeSong(2, 0.2f);
        StartCoroutine(DoFade());
        
      
    }
    public void PerformAttack() { /*Here To Fill Interface Requirements.*/}
    
    IEnumerator DoFade()
    {
        while(FadeOut.alpha<1)
        {
            FadeOut.alpha += Time.deltaTime;
            yield return null;
        }
       if(FadeOut.alpha>=1)
        {
            LastScene();
            yield return null;
        }
        yield return null;

    }
    void LastScene()
    {
        SceneManager.LoadScene(5);
    }
}
