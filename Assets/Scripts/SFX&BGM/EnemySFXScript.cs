using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySFXScript : MonoBehaviour
{
    [SerializeField] private AudioSource enemyHurt;
    [SerializeField] private AudioSource enemyDeath;

    public void PlayEnemyHurt()
    {
        enemyHurt.Play();
    }

    public void PlayEnemyDeath()
    {
        enemyDeath.Play();
    }
}
