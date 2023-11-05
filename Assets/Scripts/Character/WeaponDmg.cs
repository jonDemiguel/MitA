using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDmg : MonoBehaviour
{
    float attackspeed = 4f;
    float timer;

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("attack");
        timer = attackspeed;
    }
}
