using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Debug.Log("Player not found");
        }
    }
    void Update()
    {
        if (this.target)
        {
            transform.position = target.position + offset;
        }
    }
}
