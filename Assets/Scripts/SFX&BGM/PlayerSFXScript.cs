using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFXScript : MonoBehaviour
{

    [SerializeField] private AudioSource playerAttack;
    [SerializeField] private AudioSource playerHurt;
    [SerializeField] private AudioSource playerDeath;
    [SerializeField] private AudioSource playerRegen;

    public void PlayPlayerAttack() 
    {
        playerAttack.Play();
    }

    public void PlayPlayerHurt()
    {
        playerHurt.Play();
    }

    public void PlayPlayerDeath()
    {
        playerDeath.Play();
    }

    public void PlayPlayerRegen()
    {
        playerRegen.Play();
    }
}
