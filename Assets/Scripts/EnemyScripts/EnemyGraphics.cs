using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGraphics : MonoBehaviour
{
    private Animator enemyAnim;
    void Start() 
    {
        enemyAnim = GetComponent<Animator>();
    }

    public void startMoving() 
    {
        enemyAnim.SetBool("isMoving", true);
    }

    public void stopMoving()
    {
        enemyAnim.SetBool("isMoving", false);
    }

    public void setDead()
    {
        enemyAnim.SetBool("isDead", true);
    }

    public void startIdle()
    {
        enemyAnim.SetBool("isIdle", true);
    }

    public void stopIdle()
    {
        enemyAnim.SetBool("isIdle", false);
    }

    public void setIsHit(bool inHitState)
    {
        enemyAnim.SetBool("isMoving", inHitState);
    }
}
