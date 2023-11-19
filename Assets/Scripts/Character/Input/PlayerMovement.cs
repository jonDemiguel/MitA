using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float moveSpeed;
    Rigidbody2D rb;
    Vector2 moveDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HELLO");
        inputManage();
        moveSpeed = GetComponent<PlayerStats>().currentSpeed;
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
        Debug.Log(moveSpeed);
    }

    void FixedUpdate()
    {
        Move();
    }
    void inputManage()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }
    void Move()
    {
        Debug.Log("Actual: " + moveSpeed);
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
    private void OnAnimatorMove()
    {
        
    }
}
