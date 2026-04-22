using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //player physics objects
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private CapsuleCollider2D playerCollider;
    [SerializeField] private SpriteRenderer spriteRenderer;

    //player weapon spawners
    //[SerializeField] private GameObject WeaponXPositive;
    //[SerializeField] private GameObject WeaponYPositive;
    //[SerializeField] private GameObject WeaponXNegative;
    //[SerializeField] private GameObject WeaponYNegative;

    //movement variables
    private Vector2 movement;
    [SerializeField] private float speed = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addSpeed() 
    {
        speed++;
    }

    //physics logic
    private void FixedUpdate()
    {
        float xMovement = Input.GetAxisRaw("Horizontal");
        float yMovement = Input.GetAxisRaw("Vertical");
        Vector2 movementNormalized = new Vector2 (xMovement, yMovement).normalized;
        movement = movementNormalized * speed;

        //apply this to the rb velocity
        rb.velocity = movement;
        flipSprite();
    }

    private void flipSprite() 
    {


        if (rb.velocity.x < 0)
        {
            //add sprite logic
            transform.localScale = new Vector3(-1, 1, 1);
            //setNegativeXActive();

        }
        else if (rb.velocity.x > 0)
        {
            //add sprite logic
            transform.localScale = new Vector3(1, 1, 1);
            //setPositiveXActive();
        }
    }

    /*
    private void setPositiveXActive() 
    { 
        WeaponXPositive.SetActive (true);
        WeaponXNegative.SetActive (false);
    }

    private void setNegativeXActive()
    {
        WeaponXPositive.SetActive(false);
        WeaponXNegative.SetActive(true);
    }
    */
}
