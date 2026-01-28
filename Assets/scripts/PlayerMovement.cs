using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    public float mouseSensitivity = 200f;
    private float rotationX = 0f;
    private float rotationY = 0f;
public Camera _camera;

Rigidbody _rb;

/// <summary>
/// Start is called on the frame when a script is enabled just before
/// any of the Update methods is called the first time.
/// </summary>
void Start()
{
    _rb = GetComponent<Rigidbody>();
}
    void Update()
    {
        // Handle tank movement
        float moveDirection = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
       // Vector3 moveForewardDir= new Vector3()
       Vector3 forwardDir = transform.forward*moveDirection;
      //  transform.Translate(Vector3.forward * moveDirection);
        _rb.AddForce(forwardDir*50);
        // Handle tank rotation
        float turnDirection = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up * turnDirection);

        // Handle mouse look
        rotationX += Input.GetAxis("Mouse X") * mouseSensitivity;
        rotationY -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f); // Prevent flipping over

        //_camera.transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);
    }
}