using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController
{
    public EnemyTankModel enemyTankModel { get; private set; }
    public EnemyTankView enemyTankView { get; private set; }
    public Transform playerTransform { get; private set; }
    public Rigidbody rb { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public Transform bulletSpawnPoint { get; private set; }
    public float health { get; set; }
    private EnemyTankCollisionDamage enemyTankColliionDamage;
    private EnemyTankMovement enemyTankMovement;

    public EnemyTankController(EnemyTankScriptableObject enemyTank, float randomX, float randomZ)
    {
        this.enemyTankModel = new EnemyTankModel(enemyTank);
        enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTank.enemyTankView, new Vector3(Random.Range(-randomX, randomX), 0, Random.Range(-randomZ, randomZ)), Quaternion.identity);
        this.enemyTankModel.SetEnemyTankController(this);
        this.enemyTankView.SetEnemyTankController(this);
        this.enemyTankColliionDamage = new EnemyTankCollisionDamage(this);
        this.enemyTankMovement = new EnemyTankMovement(this);
        this.health = enemyTankModel.health;
        this.rb = enemyTankView.GetRigidbody();
        this.agent = enemyTankView.agent;
        this.bulletSpawnPoint = enemyTankView.GetBulletSpawnPoint();
        playerTransform = EnemyTankService.Instance.GetPlayerTransform();
    }
    public void TakeDamage(float damage)
    {
        enemyTankColliionDamage.TakeDamage(damage);
    }

    public void EnemyTankMovement()
    {
        enemyTankMovement.MoveTowardsPlayer();
    }
}