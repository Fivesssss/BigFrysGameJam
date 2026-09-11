using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossScript : MonoBehaviour
{
    private PlayerInventory inventory;
    [SerializeField] private GameObject boss;
    [SerializeField] private TextMeshProUGUI bossSpawnText;
    private bool bossSpawn = false; //this bool is to 

    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.gems == 3 && !bossSpawn)
        {
            bossSpawn = true;
            boss.SetActive(true);
            bossSpawnText.gameObject.SetActive(true);
            StartCoroutine(bossSpawnTextDespawn());
        }
    }

    private IEnumerator bossSpawnTextDespawn() 
    {
        yield return new WaitForSeconds(3);
        bossSpawnText.gameObject.SetActive(false);
    }
}
