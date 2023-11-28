using UnityEngine;

public class EnemyTankModel
{
    public EnemyTankController enemyTankController { get; private set; }
    public float moveSpeed { get; private set; }
    public float rotationSpeed { get; private set; }
    public float health { get; private set; }
    public int enemyBPM { get; private set; }
    public float minimumPlayerDistanceToAttack { get; private set; }
    public float minimumPlayerDistanceToChase { get; private set; }
    public EnemyTanks enemyTankType { get; private set; }
    public BulletType bulletType { get; private set; }
    public void SetEnemyTankController(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
    }

    public EnemyTankModel(EnemyTankScriptableObject enemy)
    {
        this.moveSpeed = enemy.moveSpeed;
        this.rotationSpeed = enemy.rotationSpeed;
        this.health = enemy.health;
        this.enemyTankType = enemy.enemyTankType;
        this.bulletType = enemy.bulletType;
        this.enemyBPM = enemy.enemyBPM;
        this.minimumPlayerDistanceToAttack = enemy.minimumPlayerDistanceToAttack;
        this.minimumPlayerDistanceToChase = enemy.minimumPlayerDistanceToChase;
    }
}