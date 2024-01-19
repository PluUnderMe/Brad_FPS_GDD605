using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] float EnemyHp = 100f;
    [SerializeField] GameObject scoreCanvas;

    bool isDead = false;


    public bool IsDead()
    {
        return isDead;
    }

    public void TakeDamage(float damage)
    {
        GetComponent<EnemyAI>().onDamageTaken();
        EnemyHp -= damage;
        if (EnemyHp <= 0)
            Die();
    }

    private void Die()
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
