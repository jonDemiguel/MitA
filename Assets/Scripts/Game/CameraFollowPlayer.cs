//using UnityEngine;

//public class FollowPlayer : MonoBehaviour
//{
//    public Transform target; // Reference to the player's transform
//    public float smoothSpeed = 0.125f;
//    public Vector3 offset;

//    private void LateUpdate()
//    {
//        if (target == null)
//        {
//            // Make sure you have a reference to the player's transform.
//            // You can set this reference in the Inspector.
//            return;
//        }

//        Vector3 desiredPosition = target.position + offset;
//        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
//        transform.position = smoothedPosition;

//        // Ensure the camera is always looking at the player's position.
//        transform.LookAt(target);
//    }
//}
