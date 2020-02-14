using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NecromancerController : MonoBehaviour,IEnemy
{
    public float health;
    public int ID { get; set; }
    Transform target;
    NavMeshAgent agent;
    private bool CanAttack { get; set; }
    public float lookRadius = 10f;
    private CollectedItemSet collectedItemSet;
    private UniqueID uniqueID;
    public Animator anime;
    public List<ParticleSystem> BodyParts;
    float attackRange;
    
    Rigidbody rb;
   

   


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        CanAttack = true;
        agent = GetComponent<NavMeshAgent>();
        target = GabrielsSystemManager.gabie.transform;
        ID = 1;
        collectedItemSet = FindObjectOfType<CollectedItemSet>();
        uniqueID = GetComponent<UniqueID>();
        collectedItemSet = FindObjectOfType<CollectedItemSet>();
        attackRange = agent.stoppingDistance + 2f;
        if (collectedItemSet.CollectedItems.Contains(uniqueID.ID))
        {
            Destroy(this.gameObject);
            return;
        }
       

    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                FaceTarget();
                if(CanAttack)
                {

                    PerformAttack();
                    
                }
            }
        }

       
    }

    public void PerformAttack()
    {
        anime.SetBool("isAttacking", true);
        CanAttack = false;
        
    }
   
    public void ResetAttack()
    {
        anime.SetBool("isAttacking", false);
        CanAttack = true;
    }
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        for(int i=0;i<BodyParts.Count;i++)
        {
            BodyParts[i].Stop();
            
        }
        rb.isKinematic = false;
        
        CombatEvents.EnemyDied(this);
        collectedItemSet.CollectedItems.Add(GetComponent<UniqueID>().ID);
        Destroy(gameObject,5);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
