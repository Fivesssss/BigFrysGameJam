using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyMovement : MonoBehaviour
{
    //Enemy Graphics control
    [SerializeField] private GameObject enemyGraphics;
    private SpriteRenderer spriteRenderer;
    private Animator enemyAnim;
    [SerializeField ]private AIPath aiPath;

    private Rigidbody2D enemyRB;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();    
        enemyAnim = enemyGraphics.GetComponent<Animator>();
        spriteRenderer = enemyGraphics.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        updateSprite();
    }

    private void updateSprite() 
    {
        if (aiPath.desiredVelocity.x != 0) 
        {
            enemyAnim.SetBool("isMoving", true);
        }
        else
        {
            enemyAnim.SetBool("isMoving", false);
        }

        if (aiPath.desiredVelocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (aiPath.desiredVelocity.x > 0) 
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
