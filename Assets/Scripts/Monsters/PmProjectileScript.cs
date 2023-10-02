using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PmProjectileScript : MonoBehaviour
{   

    public GameObject player;
    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {   
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 moveDirection = player.transform.position - transform.position;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y).normalized * speed; // Apply velocity using the corrected moveDirection

        float rotation = Mathf.Atan2(-moveDirection.y, -moveDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0, rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
