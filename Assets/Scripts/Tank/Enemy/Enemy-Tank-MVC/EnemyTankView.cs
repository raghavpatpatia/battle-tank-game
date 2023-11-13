using UnityEngine;

public class EnemyTankView : MonoBehaviour
{
    public EnemyTankController enemyTankController { get; private set; }
    [SerializeField] private Rigidbody rb;
    [SerializeField] public Transform bulletSpawnPoint;
    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (enemyTankController != null)
        {
            enemyTankController.HandleCollisions(collision);
        }
    }
}