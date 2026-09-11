using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemScript : MonoBehaviour
{
    private Canvas mainUI;
    private UIScript mainUIScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.tag == "Player")
        {
            PlayerInventory inventory = target.GetComponent<PlayerInventory>();
            PlayerMovement movement = target.GetComponent<PlayerMovement>();
            movement.addSpeed();
            inventory.addGems();
            mainUIScript.gemCollected = true;
            Destroy(gameObject);
        }
    }

    //this is the Canvas UI that will be passed into the spawned in gem from the chest script   
    public void SetUpGem(Canvas _mainUI) 
    {
        mainUI = _mainUI;
        mainUIScript = mainUI.GetComponent<UIScript>();
    }
}
