using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OtherObjectSFXScript : MonoBehaviour
{
    [SerializeField] private AudioSource doorSFX;
    [SerializeField] private AudioSource chestSFX;
    [SerializeField] private AudioSource silverKeySFX;
    [SerializeField] private AudioSource goldKeySFX;
    [SerializeField] private AudioSource gemSFX;

    public void playDoorSFX()
    {
        doorSFX.Play();
    }

    public void playChestSFX()
    {
        chestSFX.Play();
    }

    public void playSilverKeySFX()
    {
        silverKeySFX.Play();
    }

    public void playGoldKeySFX() 
    { 
        goldKeySFX.Play(); 
    }

    public void playGemSFX()
    {
        gemSFX.Play();
    }
}
