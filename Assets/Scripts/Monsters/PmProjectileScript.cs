using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PmProjectileScript : MonoBehaviour
{   

    public GameObject player;
    public Collider2D playerbox;
    private Rigidbody2D rb;
    public float speed;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerbox = player.GetComponent<Collider2D>();
        Vector3 targetPosition = playerbox.bounds.center;
        if (player == null ) Destroy(this.gameObject);
        Vector3 moveDirection = targetPosition - transform.position;
        float v = (float)(moveDirection.y + .09);
        rb.velocity = new Vector2(moveDirection.x, v).normalized * speed;

        float rotation = Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotation);
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 2)
        {
            Destroy(gameObject);
        }
    }
}
