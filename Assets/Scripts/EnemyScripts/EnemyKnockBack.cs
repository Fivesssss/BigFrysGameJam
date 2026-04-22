using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyKnockBack : MonoBehaviour
{
    [SerializeField] private Transform eTransform;
    [SerializeField] private Rigidbody2D eRb;
    [SerializeField] private AIPath enemyMoveController;

    //Enemy Graphics control
    [SerializeField] private GameObject enemyGraphics;
    private Animator enemyAnim;

    private EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAnim = enemyGraphics.GetComponent<Animator>();
    }

    public void takeKnockBack(Transform bulletTransform, int projectileKnockBack)
    {
        Vector2 hitDirection = (eTransform.position -  bulletTransform.position).normalized;
        enemyMoveController.enabled = false;

        if (enemyHealth.currentHealth > 0) 
        {
            enemyAnim.SetBool("isHit", true);
        }
        eRb.velocity = hitDirection * projectileKnockBack;

        StartCoroutine(stunEnemy());
    }

    private IEnumerator stunEnemy() { 
        
        yield return new WaitForSeconds(2);
        if (enemyHealth) 
        {
            enemyAnim.SetBool("isHit", false);
        }
        eRb.velocity = Vector2.zero;
        enemyMoveController.enabled = true;
    }
}
