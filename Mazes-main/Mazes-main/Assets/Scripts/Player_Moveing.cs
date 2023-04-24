using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Moveing : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float speed = 5.0f;
    private bool isAttachedToRope = false;
    private HingeJoint2D ropeJoint;

    void Start()
    {
        ropeJoint = gameObject.AddComponent<HingeJoint2D>();
        ropeJoint.enabled = false;
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

        if (Input.GetKeyDown(KeyCode.Space) && isAttachedToRope)
        {
            // Detach from rope
            isAttachedToRope = false;
            ropeJoint.enabled = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Rope"))
        {
            // Attach to rope
            isAttachedToRope = true;
            ropeJoint.enabled = true;
            ropeJoint.connectedBody = collision.rigidbody;
            ropeJoint.anchor = Vector2.zero;
            ropeJoint.connectedAnchor = collision.transform.InverseTransformPoint(transform.position);
        }
    }
}