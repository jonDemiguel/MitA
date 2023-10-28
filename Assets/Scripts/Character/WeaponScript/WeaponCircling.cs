using UnityEngine;

public class WeaponCircling : MonoBehaviour
{
    public Transform characterTransform; 
    public float circlingSpeed = 5f;   
    public float circlingRadius = 2f;    
   
    private Vector3 originalPosition;

    private void Start() {
        originalPosition = transform.position;
    }

    private void Update() {
        // time is always there - > can make circle spin forever
        float angle = Time.time * circlingSpeed;

        // Calculate offset for x and y positions
        Vector3 offset = new Vector3(Mathf.Sin(angle) * circlingRadius, Mathf.Cos(angle) * circlingRadius, 0);

        // find weapon position in relation to character
        transform.position = characterTransform.position + offset;
    }
}