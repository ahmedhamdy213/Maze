using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    public GameManager gameManager;
    public AudioSource source;
    void OnTriggerEnter2D(Collider2D collider)
    {
        source.Play();
        gameManager.CompleteLevel();
    }
}
