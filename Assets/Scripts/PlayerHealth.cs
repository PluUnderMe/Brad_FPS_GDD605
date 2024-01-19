using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float PlayerHp = 100f; //sets player hp

    public void TakeDamage(float damage)  //trigers the player to take damage and call the death handler once hp is equal or lower than 0
    {
     
        PlayerHp -= damage; 
        if (PlayerHp <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
            
    }

}