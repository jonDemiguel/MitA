using UnityEngine;
public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public float lifetime = 2f;

    private Rigidbody2D rb;
    private Vector2 movementDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifetime); // Bullet will destroy itself after a certain time
    }

    void FixedUpdate()
    {
        if (rb != null && movementDirection != Vector2.zero)
        {
            rb.velocity = movementDirection * speed; // Set the bullet's velocity in the fixed update
        }
    }

    public void SetDirection(Vector2 direction)
    {
        movementDirection = direction;
    }
}
