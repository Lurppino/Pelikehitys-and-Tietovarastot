using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    void Update()
    {
        // Movement forward/backward
        float moveDirection = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        // Rotation left/right
        float turnDirection = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, turnDirection * rotationSpeed * Time.deltaTime);
    }
}

