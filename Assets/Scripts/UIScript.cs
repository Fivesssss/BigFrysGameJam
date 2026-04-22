using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private TextMeshProUGUI silverKeys;
    [SerializeField] private TextMeshProUGUI goldKeys;
    [SerializeField] private TextMeshProUGUI gemCounter;
    [SerializeField] private TextMeshProUGUI gemTotal;
    public bool gemCollected = false;

    private PlayerInventory inventory;

    void Start()
    {
        inventory = player.GetComponent<PlayerInventory>();
    }

    // Update is called once per frame
    void Update()
    {
        silverKeys.text = inventory.silverKeys.ToString();
        goldKeys.text = inventory.goldKeys.ToString();

        if (gemCollected) 
        {
            gemCounter.text = inventory.gems.ToString();
            StartCoroutine(showGemCounter());
        }
    }

    public IEnumerator showGemCounter()
    {
        gemCounter.gameObject.SetActive(true);
        gemTotal.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);

        gemCounter.gameObject.SetActive(false);
        gemTotal.gameObject.SetActive(false);

        gemCollected = false;
    }
}
