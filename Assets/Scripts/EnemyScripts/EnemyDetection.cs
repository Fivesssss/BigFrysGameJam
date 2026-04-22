using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyDetection : MonoBehaviour
{
    [SerializeField] AIPath enemyAIPath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            enemyAIPath.enabled = true;
        }
    }
}
