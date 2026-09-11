    using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerWeaponControlller playerWeapon;
    private Animator playerAnim;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    //compute the direction of the knockback and prevent player from attacking and moving whilst stunned
    public void takeKnockBack(Transform eTransform, int enemyKnockBack)
    {
        Vector2 hitDirection = (playerTransform.position - eTransform.position).normalized;

        if (playerHealth.currentHealth > 0)
        {
            playerAnim.SetBool("isHit", true);
        }

        //disable playermovement and player attack
        playerMovement.enabled = false;
        playerWeapon.enabled = false;

        playerRb.velocity = hitDirection * enemyKnockBack;

        StartCoroutine(stunPlayer());
    }

    //this will allow player to shoot and move after set time
    public IEnumerator stunPlayer()
    {

        yield return new WaitForSeconds(2);
        if (playerHealth.currentHealth > 0)
        {
            playerAnim.SetBool("isHit", false);
        }
        playerRb.velocity = Vector2.zero;
        playerMovement.enabled = true;
        playerWeapon.enabled = true;
    }
}
