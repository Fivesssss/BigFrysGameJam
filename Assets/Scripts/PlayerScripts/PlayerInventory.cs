    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int silverKeys;
    public int goldKeys;
    public int gems;
    public List<GameObject> gemCollection;

    [SerializeField] private OtherObjectSFXScript otherObjectSFXScript;
    [SerializeField] private GameObject boss;
    [SerializeField] private TextMeshProUGUI bossSpawnText;

    // Start is called before the first frame update
    void Start()
    {
        gemCollection = new List<GameObject>();
        silverKeys = 0;
        goldKeys = 0;
        gems = 0;
    }

    public void addSilverKeys() 
    {
        silverKeys++;
        otherObjectSFXScript.playSilverKeySFX();
    }
    public void subtractSilverKeys()
    {
        silverKeys--;
    }

    public void addGoldKeys()
    {
        goldKeys++;
        otherObjectSFXScript.playGoldKeySFX();
    }
    public void subtractGoldKeys()
    {
        goldKeys--;
    }

    public void addGems()
    {
        gems++;
        otherObjectSFXScript.playGemSFX();

        //Boss spawning code block
        if (gems == 3)
        {
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
