using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject gun; // Assign the gun object in the inspector
    public GameObject bulletPrefab; // Assign the prefab of the bullet in the inspector
    public Transform bulletSpawnPoint; // The place from where the bullet will be fired, assign in inspector
    public float bulletSpeed = 100f;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>(); // Cache the main camera
    }

    void Update()
    {
        if (mainCamera == null)
        {
            mainCamera = GameObject.Find("MainCamera").GetComponent<Camera>();
            return;
        }


        AimGunAtMouse();
        if(Time.timeScale == 1.0f)
        {
            if (Input.GetMouseButtonDown(0)) // On left mouse click
            {
                Shoot();
            }
        }
    }

    void AimGunAtMouse()
    {
        // Get the mouse position in world space. The camera's z position doesn't matter.
        Vector3 mousePos = Input.mousePosition;
        mousePos = mainCamera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y,
            transform.position.z - mainCamera.transform.position.z));
        // Get the direction from the gun to the mouse. This will be used to rotate the gun.
        Vector3 difference = mousePos - gun.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        gun.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

    void Shoot()
{
    Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    mousePosition.z = 0; // Ensure there's no 3D offset.

    Vector2 direction = (mousePosition - gun.transform.position).normalized;

    // You should instantiate the bullet and immediately set its direction.
    GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
    
    // A method within the bullet script should handle initializing its direction.
    bullet.GetComponent<BulletMovement>().SetDirection(direction);
}

}
