using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private Animator playerAnim;

    [SerializeField] HealthUI healthUI;

    [SerializeField] private int health = 6; //this is the base health
    public int currentHealth; //this is the actual player health that gets used during runtime

    [SerializeField] private PlayerSFXScript playerSFXScript;

    private void Start()
    {
        currentHealth = health;
        playerAnim = GetComponent<Animator>();
    }

    public void causePlayerDamage(int damage)
    {
        currentHealth  = currentHealth - damage;
        healthUI.updateHealthForDamage(currentHealth);
        playerSFXScript.PlayPlayerHurt();
        if (currentHealth <= 0)
        {
            //destroy gameObject
            playerAnim.SetBool("isDead", true);
            StartCoroutine(playerDeath());
        }
    }

    public void regenHealth() 
    {
        playerSFXScript.PlayPlayerRegen();
        if (currentHealth < health)
        {
            currentHealth = health;
            healthUI.healHealth();
        }
    }

    private IEnumerator playerDeath() 
    {
        playerSFXScript.PlayPlayerDeath();
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
        SceneManager.LoadScene("MainMenu");
        //return to main menu

    }
}
