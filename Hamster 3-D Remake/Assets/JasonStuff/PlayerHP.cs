using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;

    public Healthbar healthbar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    // Check for collision with objects tagged as "DMG"
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DMG"))
        {
            TakeDamage(1);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    void TakeDamage(int damage)
        {
            currentHealth -= damage;

            healthbar.SetHealth(currentHealth);
        }
}