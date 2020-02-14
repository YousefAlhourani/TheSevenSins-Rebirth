using UnityEngine;
using System.Collections;

public interface IEnemy
{
    int ID { get; set; }
    void Die();
    void TakeDamage(int amount);
    void PerformAttack();
}