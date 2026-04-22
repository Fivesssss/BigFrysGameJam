using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int silverKeys;
    public int goldKeys;
    public int gems;
    public List<GameObject> gemCollection;

    // Start is called before the first frame update
    void Start()
    {
        gemCollection = new List<GameObject>();
        silverKeys = 3;
        goldKeys = 0;
        gems = 0;
    }

    public void addSilverKeys() 
    {
        silverKeys++;
    }
    public void subtractSilverKeys()
    {
        silverKeys--;
    }

    public void addGoldKeys()
    {
        goldKeys++;
    }
    public void subtractGoldKeys()
    {
        goldKeys--;
    }

    public void addGems()
    {
        gems++;
    }
}
