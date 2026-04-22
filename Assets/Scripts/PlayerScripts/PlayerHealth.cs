using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Animator playerAnim;

    [SerializeField] private int health = 6;
    public int currentHealth;

    private void Start()
    {
        currentHealth = health;
        playerAnim = GetComponent<Animator>();
    }

    public void causePlayerDamage(int damage)
    {
        currentHealth  = currentHealth - damage;
        if (currentHealth <= 0)
        {
            //destroy gameObject
            playerAnim.SetBool("isDead", true);
            StartCoroutine(playerDeath());
        }
    }

    public void regenHealth() 
    {
        if (currentHealth < health)
        {
            currentHealth = health;
        }
    }

    private IEnumerator playerDeath() 
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        //return to main menu

    }
}
