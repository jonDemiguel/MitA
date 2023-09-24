using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_eye_movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 targetPosition = player.transform.position;
            MoveCharacter(targetPosition);
        }
    }

    void MoveCharacter(Vector3 targetPosition)
    {
        // Calculate the movement step based on moveSpeed
        float step = moveSpeed * Time.deltaTime;

        // Move the monster towards the player's position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
    }
}
