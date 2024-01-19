using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //sets the enemy health
    [SerializeField] float EnemyHp = 100f;
    [SerializeField] GameObject scoreCanvas;

    bool isDead = false;


    public bool IsDead() //checks to see if the enemy is dead
    {
        return isDead;
    }

    public void TakeDamage(float damage) //when they have taken damage to 0 or below health die 
    {
        GetComponent<EnemyAI>().onDamageTaken();
        EnemyHp -= damage;
        if (EnemyHp <= 0)
            Die();
    }

    private void Die() //when they die triggers the animator and increase the score canvas
    {      
        if (isDead)
        {
            return;
        }
        isDead = true;
        GetComponent<Animator>().SetTrigger("isDying");
        scoreCanvas.GetComponent<ScoreManager>().Score = scoreCanvas.GetComponent<ScoreManager>().Score + 10;
    }

    private void Start()
    {
        scoreCanvas = GameObject.FindGameObjectWithTag("scoreCanvas");
    }
}
