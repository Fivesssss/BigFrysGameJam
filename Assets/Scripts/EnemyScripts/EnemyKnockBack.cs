using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyKnockBack : MonoBehaviour
{
    [SerializeField] private Transform enemyTransform; //the transform of the enemy
    [SerializeField] private Rigidbody2D eRb;
    [SerializeField] private AIPath aiPath;

    [SerializeField] private GameObject enemyGraphics;

    [SerializeField] private CircleCollider2D enemyAttackCollider;
    private Animator enemyAnim;
        
    private EnemyHealth enemyHealth;

    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        enemyAnim = enemyGraphics.GetComponent<Animator>();
    }

    //this function will apply knockback to the enemy upon being hit by the player weapon projectile
    // it will disable the movement and ability to attack of the enemy whilst stunned
    public void takeKnockBack(Transform bulletTransform, int projectileKnockBack)
    {
        Vector2 hitDirection = (enemyTransform.position -  bulletTransform.position).normalized;
        aiPath.enabled = false;
        enemyAttackCollider.enabled = false;

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
        aiPath.enabled = true;
        enemyAttackCollider.enabled = true;
    }
}
