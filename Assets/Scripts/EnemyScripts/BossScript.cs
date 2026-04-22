using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Experimental.GraphView;

public class BossScript : MonoBehaviour
{
    private PlayerInventory inventory;
    [SerializeField] private GameObject boss;
    [SerializeField] private TextMeshProUGUI bossSpawnText;
    private bool bossSpawn = false;

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
            boss.transform.localScale = new Vector3(5, 5, 1);
            bossSpawnText.gameObject.SetActive(true);
            StartCoroutine(bossSpawnTextDespawn());
        }
        else if (inventory.gems == 3 && bossSpawn) 
        {
            boss.transform.localScale = new Vector3 (5, 5, 1);
        }
    }

    private IEnumerator bossSpawnTextDespawn() 
    {
        yield return new WaitForSeconds(3);
        bossSpawnText.gameObject.SetActive(false);
    }
}
