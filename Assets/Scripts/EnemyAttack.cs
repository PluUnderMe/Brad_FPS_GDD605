using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] float damage = 20f;
    [SerializeField] PlayerHealth playerTarget;


    public void AttackHitEvent() //sets the damage and when the player will take damage from the enemy
    {
        
        if (playerTarget == null) { return; }
        playerTarget.TakeDamage(damage);


    }
  
}
