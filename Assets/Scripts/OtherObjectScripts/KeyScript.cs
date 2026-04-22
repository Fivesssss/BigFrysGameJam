using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] private bool isGold;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            PlayerInventory inventory = collision.gameObject.GetComponent<PlayerInventory>();
            if (isGold)
            {
                inventory.addGoldKeys();
            }
            else 
            {
                inventory.addSilverKeys();
            }
            Destroy(gameObject);
        }
    }
}
