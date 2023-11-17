using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponDmg : MonoBehaviour
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

    public virtual void PostDamage(int damage, Vector3 targetPosition)
    {
        // Post the damage message at the given position
        if (targetPosition == null)
        {
            MessageSystem.instance.PostMessage(damage.ToString(), targetPosition);
        }
        
    }
}
