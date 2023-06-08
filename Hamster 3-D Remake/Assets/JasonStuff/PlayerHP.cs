using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [Header("Player Health amount")]
    public int maxHealth = 10;
    public int currentHealth;

    [Header("Add the Splatter image here")]
    [SerializeField] private Image bloodSplatter = null;

    [Header("Hurt Image Flash")]
    [SerializeField] private Image hurtImage = null;
    [SerializeField] private float hurtTimer = 0.1f;

    [Header("Audio Name")]
    [SerializeField] AudioSource jOw;
   // private AudioSource healthAudioSource = null;

    public Healthbar healthbar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
        //healthAudioSource = GetComponent<AudioSource>();
    }

    void UpdateHealth()
    {
        Color splatterAlpha = bloodSplatter.color;
        splatterAlpha.a = 1 - ((float)currentHealth / maxHealth);
        bloodSplatter.color = splatterAlpha;
    }

    IEnumerator HurtFlash()
    {
        hurtImage.enabled = true;
        jOw.Play();
        yield return new WaitForSeconds(hurtTimer);
        hurtImage.enabled = false;
    }
    IEnumerator DisableHurtImage()
    {
        yield return new WaitForSeconds(hurtTimer);
        hurtImage.enabled = false;
    }



    void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            StartCoroutine(HurtFlash());
            StartCoroutine(DisableHurtImage());
            currentHealth -= damage;
            healthbar.SetHealth(currentHealth);
            UpdateHealth();
        }
    }

    void Die()
    {
        SceneManager.LoadScene("LoserFU");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("DMG"))
        {
            TakeDamage(1);
        }
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
