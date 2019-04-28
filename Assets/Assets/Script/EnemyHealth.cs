
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public float sinkSpeed = 2.5f;
    BoxCollider boxCollider;
    bool isDead;
    bool isSinking;

    ParticleSystem hitParticles;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        boxCollider = GetComponent<BoxCollider>();

        currentHealth = startingHealth;
    }

    void Update()
    {
        if(isSinking)
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
        }
    }

    public void TakeDamage (int amount, Vector3 hitPoint)
    {
        if (isDead) return;

        currentHealth -= amount;

        hitParticles.transform.position = hitPoint;

        if(currentHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        boxCollider.isTrigger = true;

        anim.SetTrigger("Dead");
    }

    public void StartSinking()
    {
        GetComponent<Rigidbody>().isKinematic = true;

        isSinking = true;

        //ScoreManager.score += ;

        Destroy(gameObject, 2f);
    }
}
