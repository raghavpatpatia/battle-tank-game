using UnityEngine;

public class EnemyTankController
{
    public EnemyTankModel enemyTankModel { get; private set; }
    public EnemyTankView enemyTankView { get; private set; }
    public float health { get; set; }
    public int enemyTankDamage { get; private set; }
    private EnemyTankCollisions enemyTankCollisions;

    public EnemyTankController(EnemyTankScriptableObject enemyTank, float randomX, float randomZ)
    {
        this.enemyTankModel = new EnemyTankModel(enemyTank);
        enemyTankView = GameObject.Instantiate<EnemyTankView>(enemyTank.enemyTankView, new Vector3(Random.Range(-randomX, randomX), 0, Random.Range(-randomZ, randomZ)), Quaternion.identity);
        this.enemyTankModel.SetEnemyTankController(this);
        this.enemyTankView.SetEnemyTankController(this);
        this.enemyTankCollisions = new EnemyTankCollisions(this);
        this.health = enemyTankModel.health;
        this.enemyTankDamage = enemyTankModel.tankDamage;
    }
    public void TakeDamage(float damage)
    {
        enemyTankCollisions.TakeDamage(damage);
    }

    public void HandleCollisions(Collision collision)
    {
        enemyTankCollisions.HandleCollisions(collision);
    }
}