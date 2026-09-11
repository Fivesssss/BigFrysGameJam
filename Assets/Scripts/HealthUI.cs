using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    //images of all cases of the healthbar UI
    [SerializeField] Image healthBar;
    [SerializeField] Sprite fullHealth;
    [SerializeField] Sprite fiveHealth;
    [SerializeField] Sprite fourHealth;
    [SerializeField] Sprite threeHealth;
    [SerializeField] Sprite twoHealth;
    [SerializeField] Sprite oneHealth;
    [SerializeField] Sprite noHealth;
    private void Start()
    {
        healthBar.sprite = fullHealth;
    }

    public void updateHealthForDamage(int currentHealth) 
    {
        switch (currentHealth)
        {
            case 5:
                healthBar.sprite = fiveHealth;
                break;
            case 4: 
                healthBar.sprite = fourHealth;
                break;
            case 3: 
                healthBar.sprite = threeHealth; 
                break;
            case 2: 
                healthBar.sprite = twoHealth; 
                break;
            case 1: 
                healthBar.sprite = oneHealth; 
                break;
            case 0: 
                healthBar.sprite = noHealth; 
                break;
        }
    }

    public void healHealth() 
    {
        healthBar.sprite = fullHealth;
    }
}
