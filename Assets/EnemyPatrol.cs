using System.Collections;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;
    public Collider2D[] testArray;

    public Vector3 scale;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;

    private bool notAtEdge;
    public Transform edgeCheck;

    private void Start()
    {
        scale = transform.localScale;
    }

    void Update()
    {
        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        hittingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        if (hittingWall)
        {
            moveRight = !moveRight;
            print("Hit the wall");
        }

        if (!notAtEdge)
        {
            moveRight = !moveRight;
            print("Hit the edge");
        }

        if (moveRight)
        {
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent <Rigidbody2D>().velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }
}
