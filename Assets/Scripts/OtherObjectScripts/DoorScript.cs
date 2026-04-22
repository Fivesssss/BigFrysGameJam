using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorScript : MonoBehaviour
{
    private bool enterDoorRegion = false;
    private PlayerInventory inventory = null;
    [SerializeField] private TextMeshProUGUI notEnoughKeys;
    [SerializeField] private TextMeshProUGUI pressEnterToEscape;

    //Update code later
    //Text mesh pro later
    void Update() 
    {
        if (inventory != null)
        {
            if (inventory.goldKeys == 1 && Input.GetKeyDown(KeyCode.Return) && enterDoorRegion)
            {
                Debug.Log("You have escaped");
                inventory.subtractGoldKeys();
                //Exit Scene play
            }
            else if (inventory.goldKeys < 1 && Input.GetKeyDown(KeyCode.Return) && enterDoorRegion)
            {
                notEnoughKeys.gameObject.SetActive(true);
                StartCoroutine(waitKeys());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        GameObject target = collision.gameObject;
        if (target.tag == "Player") 
        {
            pressEnterToEscape.gameObject.SetActive(true);
            StartCoroutine(waitPressEnter());
            enterDoorRegion = true;
            inventory = target.GetComponent<PlayerInventory>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enterDoorRegion = false;
            inventory = null;
            notEnoughKeys.gameObject.SetActive(false);
            pressEnterToEscape.gameObject.SetActive(false);
        }
    }

    private IEnumerator waitKeys() 
    {
        yield return new WaitForSeconds(2);
        notEnoughKeys.gameObject.SetActive(false);
    }

    private IEnumerator waitPressEnter()
    {
        yield return new WaitForSeconds(2);
        pressEnterToEscape.gameObject.SetActive(false);
    }
}
