using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMAB : MonoBehaviour
{
    public float speed = 5.0f;
    private Vector2 movement;
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Get horizontal and vertical inputs
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        movement = new Vector2(moveX, moveY).normalized;

        // Set animator parameters
        animator.SetFloat("moveX", movement.x);
        animator.SetFloat("moveY", movement.y);
    }

    void FixedUpdate()
    {
        transform.Translate(movement * speed * Time.fixedDeltaTime);
    }
}
