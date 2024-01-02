using UnityEngine;
using UnityEngine.AI;

public class EnemyTankView : MonoBehaviour, IDamageable
{
    public EnemyTankController enemyTankController { get; private set; }
    public NavMeshAgent agent { get; private set; }
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] public HealthBar healthBar;
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
    private void Start()
    {
        enemyTankController.ChangeState(EnemyStates.Idle);
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
        if (enemyTankController != null && enemyTankController.playerTransform != null)
        {
            enemyTankController.UpdateEnemyTankState();
        }
    }
    public void TakeDamage(float damage)
    {
        enemyTankController.TakeDamage(damage);
    }
}