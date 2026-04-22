using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int enemyAttackKB = 2;
    [SerializeField] private int enemyAttack = 1;
    [SerializeField] private Transform eTransform;
    [SerializeField] private AIPath enemyMoveController;
    [SerializeField] private GameObject enemySightRegion;


    void Update() 
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.tag == "Player") 
        {
            PlayerKnockBack pKB = target.GetComponent<PlayerKnockBack>();
            PlayerHealth pHealth = target.GetComponent<PlayerHealth>();

            pHealth.causePlayerDamage(enemyAttack);
            pKB.takeKnockBack(eTransform, enemyAttackKB);

            stopEnemy();
        }
    }

    private void stopEnemy() 
    {
        enemyMoveController.enabled = false;
        StartCoroutine(disableMovement());
    }

    private IEnumerator disableMovement() 
    {
        yield return new WaitForSeconds(1.5f);
        enemyMoveController.enabled = true;
    }
}
