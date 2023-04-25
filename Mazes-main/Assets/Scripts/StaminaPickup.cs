using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StaminaPickup : MonoBehaviour
{
    public float staminaAmount = 20f;
    public AudioSource pickupsound;
    public SpriteRenderer spriteRenderer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            pickupsound.Play();
            other.GetComponent<Player_Moveing>().AddStamina(staminaAmount);
            StartCoroutine(DestroyAfterDelay(2f));
        }

    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        spriteRenderer.enabled = false;
        GetComponent<Collider2D>().enabled = false; // Disable the collider to prevent further interactions
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        Destroy(gameObject); // Destroy the stamina pickup
    }
}