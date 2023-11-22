using UnityEngine;

public class EnemyTankModel
{
    public EnemyTankController enemyTankController { get; private set; }
    public float moveSpeed { get; private set; }
    public float health { get; private set; }
    public EnemyTanks enemyTankType { get; private set; }
    public BulletType bulletType { get; private set; }
    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
    }

    public EnemyTankModel(EnemyTankScriptableObject enemy)
    {
        this.moveSpeed = enemy.moveSpeed;
        this.health = enemy.health;
        this.enemyTankType = enemy.enemyTankType;
        this.bulletType = enemy.bulletType;
    }
}