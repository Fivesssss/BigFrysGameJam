using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLogic : MonoBehaviour
{
    [SerializeField] private int projectileDamage = 1;
    [SerializeField] private int projectileKnockBack = 2;
    [SerializeField] private Transform projTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
        void Update()
    {
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject target = collision.gameObject;
        if (target.tag == "Enemy") {
            Debug.Log("Hit");
            EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
            EnemyKnockBack enemyKnockBack = target.GetComponent<EnemyKnockBack>();

            enemyKnockBack.takeKnockBack(projTransform, projectileKnockBack);

            enemyHealth.removeHealth();
            Destroy(gameObject);
        }
    }
}
