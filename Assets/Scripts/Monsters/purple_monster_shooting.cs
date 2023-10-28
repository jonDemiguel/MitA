using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purple_monster_shooting : MonoBehaviour
{
    public GameObject bullet;
    //public Transform bulletPos;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            purple_monster_shooting script = GetComponent<purple_monster_shooting>();
            script.enabled = false;
        }
        if (timer > 2) {
            timer = 0;
            shoot();
        }
        


    }

    void shoot() {
        Vector3 pos = transform.position;
        //Offset so bullet instantiates in middle of prefab and not bottom
        pos.y += 3;
        Instantiate(bullet, pos, Quaternion.identity);
    }   
}
