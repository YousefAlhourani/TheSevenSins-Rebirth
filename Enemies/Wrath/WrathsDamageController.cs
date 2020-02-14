using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrathsDamageController : MonoBehaviour
{
    public int DamageTaken { get; set; }
    public WrathsController Controller;

    private void Start()
    {
        Controller = GetComponentInParent<WrathsController>();
    }
    public void Hit(int Damage)
    {
        DamageTaken = Damage;
        Controller.TakeDamage(DamageTaken);
    }
}
