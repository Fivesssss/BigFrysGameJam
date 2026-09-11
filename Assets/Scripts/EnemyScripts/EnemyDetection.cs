using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] AIPath enemyAIPath;
    [SerializeField] bool isBoss;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            enemyAIPath.enabled = true;
            Debug.Log("Player Detected");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemyAIPath.enabled = false;
            Debug.Log("Player Lost");
        }
    }   
}
