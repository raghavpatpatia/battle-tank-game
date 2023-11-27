using UnityEngine;

public class TankView : MonoBehaviour, IDamageable
{
    private TankController tankController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint { get { return bulletSpawnPoint; } }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (tankController != null)
        {
            TankMovement();
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

    public void TakeDamage(float damage)
    {
        tankController.TakeDamage(damage);
    }
}
