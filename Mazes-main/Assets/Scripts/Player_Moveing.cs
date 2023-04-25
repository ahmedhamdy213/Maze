using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Moveing : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public AudioSource failsound;
    public float speed = 5.0f;
    public Slider staminaSlider;
    public float maxStamina = 100f;
    public float staminaDecreaseRate = 5f;
    public float staminaIncreaseRate = 10f;

    private float currentStamina;

    void Start()
    {
        currentStamina = maxStamina;
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = currentStamina;
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("Horizontal", horizontalInput);
        Vector3 horizontal = new Vector3(horizontalInput, 0.0f, 0.0f);
        transform.position += horizontal * speed * Time.deltaTime;

        if (horizontalInput < 0)
            spriteRenderer.flipX = true;
        else if (horizontalInput > 0)
            spriteRenderer.flipX = false;

        float verticalInput = Input.GetAxis("Vertical");
        animator.SetFloat("Vertical", verticalInput);
        Vector3 vertical = new Vector3(0.0f, verticalInput, 0.0f);
        transform.position += vertical * speed * Time.deltaTime;

        // Stamina logic
        if (horizontalInput != 0 || verticalInput != 0)
        {
            DecreaseStamina(staminaDecreaseRate * Time.deltaTime);
        }
        else
        {
            IncreaseStamina(staminaIncreaseRate * Time.deltaTime);
        }
    }

    void DecreaseStamina(float amount)
    {
        currentStamina -= amount;
        staminaSlider.value = currentStamina;

        if (currentStamina <= 0)
        {
            failsound.Play();
            StartCoroutine(RestartLevelAfterDelay(1.5f));
        }
    }
    IEnumerator RestartLevelAfterDelay(float delay)
    {
        speed = 0f; 
        GetComponent<Collider2D>().enabled = false;
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart the level
    }

    void IncreaseStamina(float amount)
    {
        currentStamina = Mathf.Min(currentStamina + amount, maxStamina);
        staminaSlider.value = currentStamina;
    }

    public void AddStamina(float amount)
    {
        IncreaseStamina(amount);
    }
}