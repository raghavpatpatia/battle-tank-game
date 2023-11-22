using UnityEngine;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour, IDamageable
{
    public EnemyTankController enemyTankController { get; private set; }
    public NavMeshAgent agent { get; private set; }
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform bulletSpawnPoint;
    private EnemyTankState enemyTankState;
    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public Transform GetBulletSpawnPoint()
    {
        return bulletSpawnPoint;
    }

    private void Update()
    {
        if (enemyTankController != null)
        {
            enemyTankController.EnemyTankMovement();
        }
    }
    public void TakeDamage(float damage)
    {
        enemyTankController.TakeDamage(damage);
    }
}