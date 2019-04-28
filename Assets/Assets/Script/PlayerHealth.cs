using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    public Slider healthSlider;
    public Image damageImage;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    PlayerController playerController;
    PlayerShoot playerShoot;
    bool isDead;
    bool damaged;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        playerShoot = GetComponentInChildren<PlayerShoot>();

        currentHealth = startingHealth;
    }

    private void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColor;
        }

        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }

        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;

        currentHealth -= amount;

        healthSlider.value = currentHealth;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;

        playerShoot.DestroyFinishedParticle();

        anim.SetTrigger("die");

        playerController.enabled = false;
        playerShoot.enabled = false;
    }
}
