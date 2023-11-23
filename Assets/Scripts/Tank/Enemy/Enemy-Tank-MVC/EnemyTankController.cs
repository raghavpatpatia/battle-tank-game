using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController
{
    public EnemyTankModel enemyTankModel { get; private set; }
    public EnemyTankView enemyTankView { get; private set; }
    public Transform playerTransform { get; private set; }
    public Rigidbody rb { get; private set; }
    public NavMeshAgent agent { get; private set; }
    public float health { get; set; }
    public float playerAttackDistance { get; private set; }
    public float playerChaseDistance { get; private set; }
    private EnemyTankCollisionDamage enemyTankColliionDamage;
    private EnemyTankState enemyTankState;
    private Transform bulletSpawnPoint;

    public EnemyTankController(EnemyTankScriptableObject enemyTank, float randomX, float randomZ)
    {
        this.enemyTankModel = new EnemyTankModel(enemyTank);
        enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTank.enemyTankView, new Vector3(Random.Range(-randomX, randomX), 0, Random.Range(-randomZ, randomZ)), Quaternion.identity);
        this.enemyTankModel.SetEnemyTankController(this);
        this.enemyTankView.SetEnemyTankController(this);
        this.enemyTankColliionDamage = new EnemyTankCollisionDamage(this);
        this.health = enemyTankModel.health;
        this.playerAttackDistance = enemyTankModel.minimumPlayerDistanceToAttack;
        this.playerChaseDistance = enemyTankModel.minimumPlayerDistanceToChase;
        this.rb = enemyTankView.GetRigidbody();
        this.agent = enemyTankView.agent;
        this.bulletSpawnPoint = enemyTankView.GetBulletSpawnPoint();
        playerTransform = EnemyTankService.Instance.GetPlayerTransform();
        this.enemyTankState = new EnemyTankState(this);
    }

    public void UpdateEnemyTankState()
    {
        if (enemyTankState != null)
        {
            enemyTankState.Tick();
        }
    }

    public void ChangeState(EnemyStates state)
    {
        if (enemyTankState != null)
        {
            enemyTankState.OnStateExit();
        }
        switch (state)
        {
            case EnemyStates.Idle:
                enemyTankState = new IdleState(this);
                break;
            case EnemyStates.Patrol:
                enemyTankState = new PatrolState(this);
                break;
            case EnemyStates.Chase:
                enemyTankState = new ChaseState(this);
                break;
            case EnemyStates.Attack:
                enemyTankState = new AttackState(this);
                break;
        }
        enemyTankState.OnStateEnter();
    }

    public void TakeDamage(float damage)
    {
        enemyTankColliionDamage.TakeDamage(damage);
    }

    public void Shoot()
    {
        EnemyTankService.Instance.Shoot(enemyTankModel.bulletType, bulletSpawnPoint);
    }
}