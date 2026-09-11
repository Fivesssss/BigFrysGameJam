using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyHealth : MonoBehaviour
{
    //Enemy Graphics control
    [SerializeField] private GameObject enemyGraphics;
    private Animator enemyAnim;
    [SerializeField] GameObject silverKey; //only the medium enemy drops
    [SerializeField] GameObject goldKey; //only the boss drops

    [SerializeField] private bool isMedium = false; //Medium-Sized Enemy Check
    [SerializeField] private bool isBoss = false;
    [SerializeField] private int health = 3; //base health of an enemy, changes based on size

    [SerializeField] private CircleCollider2D enemyAttackCollider;

    private AIPath aIPath;

    public int currentHealth; //the actual health var that is used internally

    [SerializeField] private EnemySFXScript enemySFXScript;

    private void Start()
    {
        currentHealth = health;
        enemyAnim = enemyGraphics.GetComponent<Animator>();
        aIPath = GetComponent<AIPath>();
    }
    public void removeHealth() {
        currentHealth--;
        enemySFXScript.PlayEnemyHurt();

        if (currentHealth <= 0) {
            enemyAnim.SetBool("isDead", true);
            StartCoroutine(destroyEnemy());
        }
    }

    private IEnumerator destroyEnemy() 
    {
        enemySFXScript.PlayEnemyDeath();
        //prevent enemy from moving and attacking when dying
        aIPath.enabled = false;
        enemyAttackCollider.enabled = false;
        
        yield return new WaitForSeconds(2);
        if (isBoss)
        {
            Instantiate(goldKey, transform.position, transform.rotation);
        }
        else if (isMedium)
        {
            Instantiate(silverKey, transform.position, transform.rotation);
        }
        Destroy(gameObject);
    }

}
