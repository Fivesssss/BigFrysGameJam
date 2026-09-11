using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerWeaponControlller : MonoBehaviour
{
    [SerializeField] private GameObject projectiles;
    [SerializeField] private GameObject projectileSpawnPoint;

    [SerializeField] private float shootCoolDown = 1.25f;
    [SerializeField] private float shootTimer = 1.5f; //this is set higher than the cooldown to let the player shoot when spawning in
    [SerializeField] private float projectileSpeed = 7f;
    private float currentProjectileSpeed;

    [SerializeField] private PlayerSFXScript playerSFXScript;

    // Update is called once per frame
    void Update()
    {
        if (transform.parent.localScale == new Vector3(-1, 1, 1))
        {
            currentProjectileSpeed = -projectileSpeed;
        }
        else
        {
            currentProjectileSpeed = projectileSpeed;
        }

        shootTimer += Time.deltaTime;//tracks time since previous frame
        if (Input.GetMouseButton(0)) { 
            onShoot();
        }    
    }


    void onShoot()
    {

        if (shootTimer > shootCoolDown) {
            //start shootTimer from 0
            shootTimer = 0;
            Vector3 spawnPosition = projectileSpawnPoint.transform.position;
            Quaternion spawnRotation = projectileSpawnPoint.transform.rotation;
            GameObject projectile = Instantiate(projectiles, spawnPosition, spawnRotation);
            //flip according to the local scale of the parent
            if (transform.parent.localScale == new Vector3(-1, 1, 1)) 
            {
                projectile.transform.localScale = new Vector3(-1, 1, 1);
            }
            Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();

            projectileRb.velocity = new Vector2(currentProjectileSpeed, 0);

            playerSFXScript.PlayPlayerAttack();
        }
    }
}
