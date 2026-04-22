using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.VFX;

public class ChestScript : MonoBehaviour
{
    private bool enterRegion = false;

    [SerializeField] private GameObject gem;
    [SerializeField] TextMeshProUGUI doNotHaveSilverKey;
    [SerializeField] TextMeshProUGUI pressEnter;
    [SerializeField] private Canvas mainUI;

    private PlayerInventory inventory;

    // Update is called once per frame
    void Update()
    {
        if (inventory != null)
        {
            if (inventory.silverKeys >= 1 && Input.GetKeyDown(KeyCode.Return) && enterRegion)
            {
                Debug.Log("enter Pressed");
                GameObject spawnGem = Instantiate(gem, transform.position, transform.rotation);
                GemScript gemScript  = spawnGem.GetComponent<GemScript>();
                gemScript.SetUpGem(mainUI);
                inventory.subtractSilverKeys();
                Destroy(gameObject);
            }
            else if (inventory.silverKeys < 1 && Input.GetKeyDown(KeyCode.Return) && enterRegion)
            {
                doNotHaveSilverKey.gameObject.SetActive(true);
                StartCoroutine(disableKeyText());
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.tag == "Player") 
        {
            enterRegion = true;
            pressEnter.gameObject.SetActive(true);
            inventory = target.GetComponent<PlayerInventory>();
            StartCoroutine(disableEnterText());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enterRegion = false;
            doNotHaveSilverKey.gameObject.SetActive(false);
            pressEnter.gameObject.SetActive(false);
            inventory = null;
        }
    }

    private IEnumerator disableKeyText() 
    {
        yield return new WaitForSeconds(2);
        doNotHaveSilverKey.gameObject.SetActive(false);

    }

    private IEnumerator disableEnterText()
    {
        yield return new WaitForSeconds(2);
        pressEnter.gameObject.SetActive(false);

    }
}
