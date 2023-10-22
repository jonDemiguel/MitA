using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryItem : MonoBehaviour
{
    [SerializeField] GameObject healthPickup;
    [SerializeField] [Range(0f, 1f)] float chanceOfDrop = 1f;


    private void OnDestory()
    {
        Transform t = Instantiate(healthPickup).transform;
        t.position = transform.position;
    }
}
