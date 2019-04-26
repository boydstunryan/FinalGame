using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour { 

    //Player Movement Variables
    public float moveSpeed;
    public float jumpHeight;
    private bool doubleJump;
    public Vector3 scale;

    //Player grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    //Non-Slide player
    private float moveVelocity;

    public Animator animator;

 //   Debug.log(animator);
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
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
        if (grounded)
        {
            doubleJump = false;
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown (KeyCode.Space)&& grounded)
        {
            Jump();
            print("Jumped once");
        }

        

        if (Input.GetKeyDown(KeyCode.Space)&& !doubleJump && !grounded)
        {
            Jump();
            doubleJump = true;
            print("jumped twice");
        }

        //Non Slide Player
        moveVelocity = 0f;

        if (Input.GetKey(KeyCode.D))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = moveSpeed;
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
            animator.SetBool("isWalking", true);
        }

        else if (Input.GetKeyUp(KeyCode.D))
        {
            animator.SetBool("isWalking",false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent <Rigidbody2D>().velocity.y);
            moveVelocity = -moveSpeed;
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            animator.SetBool("isWalking", true);
        }

        else if (Input.GetKeyUp(KeyCode.A))
        {
            animator.SetBool("isWalking", false);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
        

        //Player flip
        //if (GetComponent<Rigidbody2D>().velocity.x > 0)


        //else if (GetComponent<Rigidbody2D>().velocity.x < 0) ;
        
    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
        animator.SetBool("isJumping", true);
    }
}
