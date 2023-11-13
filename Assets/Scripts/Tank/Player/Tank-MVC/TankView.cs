using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public Transform bulletSpawnPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (tankController != null && tankController.tankType == TankType.Player)
        {
            TankMovement();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tankController.Shoot(bulletSpawnPoint);
            }
        }
    }

    private void TankMovement()
    {
        tankController.PlayerMovement();
    }

    public void SetTankController(TankController controller)
    {
        tankController = controller;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tankController != null)
        {
            tankController.HandleCollisions(collision);
        }
    }
}
