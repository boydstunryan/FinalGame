using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    public float timeOut;

    public GameObject player;

    public GameObject enemyDeath;

    public GameObject projectileParticle;

    public int pointsForKill;

    private void Start()
    {
        player = GameObject.Find("Player");

        enemyDeath = Resources.Load("Prefabs/PS") as GameObject;

        if (player.transform.localScale.x < 0)
            speed = -speed;

        Destroy(gameObject, timeOut);
    }

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            print("Enterting Trigger!" + other.gameObject);
            Instantiate(enemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.AddPoints(pointsForKill);
        }

        Destroy(gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        print("Hitting Collider!"+ other.gameObject);
        Instantiate(projectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
