using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxRotation;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        Vector3 direction = new Vector3(joystick.direction.x, 0.0f, joystick.direction.y);
        rb.velocity = direction.normalized * moveSpeed * Time.deltaTime;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);
            if (angleDifference > maxRotation)
            {
                float step = maxRotation / angleDifference;
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, step);
            }
            transform.rotation = targetRotation;
        }
    }
}
