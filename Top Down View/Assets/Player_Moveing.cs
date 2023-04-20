using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moveing : MonoBehaviour
{
    public Animator animator;


    void FixedUpdate()
    {
        animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));
        Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Time.deltaTime;
        animator.SetFloat("Vertical", Input.GetAxis("Vertical"));
        Vector3 Vertical = new Vector3(0.0f, Input.GetAxis("Vertical"), 0.0f);
        transform.position = transform.position + Vertical * Time.deltaTime;
    }
}
   

