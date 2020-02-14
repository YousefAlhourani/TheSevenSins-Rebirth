using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonKnightController : MonoBehaviour,IEnemy
{

    public float currentHealth;
    public float maxHealth;
    public int ID { get; set; }
    public float lookRadius;
    Transform target;
    NavMeshAgent agent;
    public Animator animator;
    float attackRange;

    public float WakeUpRadius; 
    bool WokeUp { get; set; }
    private bool isDead { get; set; }
    bool CanAttack { get; set; } = true;

    private CollectedItemSet collectedItemSet;
    private UniqueID uniqueID;

    public bool SaveEnemy;

    
    void Start()
    {
        isDead = false;
        WokeUp = false;
        collectedItemSet = FindObjectOfType<CollectedItemSet>();
        uniqueID = GetComponent<UniqueID>();
        collectedItemSet = FindObjectOfType<CollectedItemSet>();

        if (collectedItemSet.CollectedItems.Contains(uniqueID.ID))
        {
            Destroy(this.gameObject);
            return;
        }
        currentHealth = maxHealth;
        agent=GetComponent<NavMeshAgent>();
        target=GabrielsSystemManager.gabie.transform;
        ID = 0;
        attackRange = agent.stoppingDistance +0.25f;
    }

    void Update()
    {

        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= WakeUpRadius && !isDead && !WokeUp)
        {
            FaceTarget();
            animator.SetTrigger("WakeUp");
            WokeUp = true;
            
        }
        if (!isDead && WokeUp)
        {
            lookRadius = WakeUpRadius * 2;
            FaceTarget();
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                agent.isStopped = false;
                if(agent.remainingDistance>attackRange && agent.remainingDistance<lookRadius)
                {
                    animator.SetBool("isWalk",true);
                } 
                else 
                if(agent.remainingDistance<=attackRange+1f && CanAttack)
                {
                    int x=Random.Range(0, 100);
                    animator.SetBool("isWalk", false);
                    if(x>=95)
                    {
                        animator.SetTrigger("OtherAttack");
                    }
                    else
                    animator.SetTrigger("Attack");
                    PerformAttack();

                }
                else 
                if(agent.remainingDistance<=attackRange&&!CanAttack)
                {
                    animator.SetBool("isWalk", false);
                }
                
            }
            else if(distance> lookRadius)
            {
                agent.isStopped = true;
                animator.SetBool("isWalk", false);
            }
        }

    }

    void FaceTarget()
    {
        
        Vector3 direction=(target.position-transform.position).normalized;
        Quaternion lookRotation=Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
        transform.rotation=Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime*5f);
       
    }
   

    public void PerformAttack()
    {
        CanAttack = false;
    }

  
    public void ResetAttack()
    {
        CanAttack = true;
    }
   
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Die();
            
        }
    }
    public void Die()
    {
        CombatEvents.EnemyDied(this);
        if (!SaveEnemy)
        { collectedItemSet.CollectedItems.Add(GetComponent<UniqueID>().ID); }
        isDead = true;
        animator.SetTrigger("Dead"); 
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

}
