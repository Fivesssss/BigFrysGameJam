using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 9f;
    [SerializeField] private float speedMultiplier = 6f;
    [SerializeField] private GameObject groundCheck; // the ground check location object
    [SerializeField] private float checkRadius = 0.5f; //the radius to be used for the ground check
    [SerializeField] private LayerMask ground;
    [SerializeField] private Animator playerAnim;

    private Vector2 movementVector;
    private Rigidbody2D playerRB;
    private bool hasJumped = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal") * speedMultiplier;

        //sprite flipping logic, becuase the sprite is facing left by default when moving right the x scale must be negative
        if (movementVector.x < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (movementVector.x > 0) 
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //make sure that space is pressed and that the player is on the floor
        if (Input.GetKeyDown(KeyCode.Space) && !hasJumped) 
        {
            movementVector.y = jumpForce;
            playerRB.linearVelocity = movementVector;
            hasJumped = true;
        }
    }

    private void FixedUpdate()
    {
        movementVector.y = playerRB.linearVelocityY;
        playerRB.linearVelocity = movementVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") && hasJumped) 
        {
            //create a circle near groundCheck to see if it overlaps with the ground, this prevents wall jumps
            //or jumping when hitting the bottom of a floor
            hasJumped = !(Physics2D.OverlapCircle(groundCheck.transform.position, checkRadius, ground));
        }
    }
}
