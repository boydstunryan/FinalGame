using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour { 

    //Player Movement Variables
    public float moveSpeed;
    public float jumpHeight;
    private bool doubleJump;

    //Player grounded variables
    private bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    private float moveVelocity;

    public Animator animator; 

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
    }

    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }



    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Space)&& grounded)
        {
            Jump();
        }

        if (grounded)
        {
            doubleJump = false;
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && !doubleJump && !grounded)
        {
            Jump();
            doubleJump = true;
        }

        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
            animator.SetBool("isWalking", true);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking",false);
        }
        if (Input.GetKey(KeyCode.A))
        {
          GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent <Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
            animator.SetBool("isWalking", true);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
        }

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(1f, 1f, 1f);

        else if (GetComponent<Rigidbody2D>().velocity.x < 0) ;
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
        animator.SetBool("isJumping", true);
    }
}
