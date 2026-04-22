using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBack : MonoBehaviour
{
    [SerializeField] private Transform pTransform;
    [SerializeField] private Rigidbody2D Rb;
    [SerializeField] private PlayerMovement pMovement;
    [SerializeField] private PlayerWeaponControlller pWeapon;
    private Animator playerAnim;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerAnim = GetComponent<Animator>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void takeKnockBack(Transform eTransform, int enemyKnockBack)
    {
        Vector2 hitDirection = (pTransform.position - eTransform.position).normalized;

        if (playerHealth.currentHealth > 0)
        {
            playerAnim.SetBool("isHit", true);
        }

        //disable playermovement and player attack
        pMovement.enabled = false;
        pWeapon.enabled = false;

        Rb.velocity = hitDirection * enemyKnockBack;

        StartCoroutine(stunPlayer());
    }

    public IEnumerator stunPlayer()
    {

        yield return new WaitForSeconds(2);
        if (playerHealth.currentHealth > 0)
        {
            playerAnim.SetBool("isHit", false);
        }
        Rb.velocity = Vector2.zero;
        pMovement.enabled = true;
        pWeapon.enabled = true;
    }
}
