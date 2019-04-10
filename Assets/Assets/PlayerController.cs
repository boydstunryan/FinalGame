using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class PlayerController : MonoBehaviour { 

    //Player Movement Variables
    public float moveSpeed;
    public float jumpHeight;

    //Player grounded variables
    private bool grounded;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

=======
public class PlayerController : MonoBehaviour
{
>>>>>>> master
    // Start is called before the first frame update
    void Start()
    {
        
    }

<<<<<<< HEAD
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent <Rigidbody2D>().velocity.y);
        }

        if(Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x,jumpHeight);
=======
    // Update is called once per frame
    void Update()
    {
        
>>>>>>> master
    }
}
