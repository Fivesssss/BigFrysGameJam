using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegenPotionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.tag == "Player") 
        {
            PlayerHealth pHealth = target.GetComponent<PlayerHealth>();
            pHealth.regenHealth();
            Destroy(gameObject);
        }
    }
}