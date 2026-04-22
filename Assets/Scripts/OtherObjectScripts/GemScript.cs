using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemScript : MonoBehaviour
{
    [SerializeField] private string colour;
    [SerializeField] private Canvas mainUI;
    private UIScript mainUIScript;

    void Start() 
    {
        mainUIScript = mainUI.GetComponent<UIScript>();
    }


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

    public void SetUpGem(Canvas _mainUI) 
    {
        mainUI = _mainUI;
    }
}
