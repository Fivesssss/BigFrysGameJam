using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Enemy Graphics control
    [SerializeField] private GameObject enemyGraphics;
    private Animator enemyAnim;
    [SerializeField] GameObject silverKey;
    [SerializeField] GameObject goldKey;

    [SerializeField] private bool isMedium = false;
    [SerializeField] private bool isBoss = false;
    [SerializeField] private int health = 3;
    public int currentHealth;

    private void Start()
    {
        currentHealth = health;
        enemyAnim = enemyGraphics.GetComponent<Animator>();
    }
    public void removeHealth() {
        currentHealth--;

        if (currentHealth <= 0) {
            enemyAnim.SetBool("isDead", true);
            StartCoroutine(destroyEnemy());
        }
    }

    private IEnumerator destroyEnemy() 
    {
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
