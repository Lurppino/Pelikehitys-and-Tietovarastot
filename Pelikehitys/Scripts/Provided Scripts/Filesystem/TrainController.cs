using UnityEngine;

public class TrainController : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float turnSpeed = 45.0f;
    [SerializeField] private int amount = 5;

    private float horizontalInput;
    private float forwardInput;

    private void Update()
    {
        MoveTrain();
    }

    void MoveTrain()
    {
        // Player inputs
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        // Move the train forward/backward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);

        // Rotate the train left/right
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has IDamageable
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(amount);
        }
    }
}
