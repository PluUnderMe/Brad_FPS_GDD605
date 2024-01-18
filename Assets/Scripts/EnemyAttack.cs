using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] PlayerHealth playerTarget;


    public void AttackHitEvent()
    {
        
        if (playerTarget == null) { return; }
        playerTarget.TakeDamage(damage);


    }
  
}
