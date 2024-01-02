using UnityEngine;

public class EnemyTankCollisionDamage
{
    public EnemyTankController enemyTankController { get; private set; }
    public EnemyTankCollisionDamage(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
    }

    public void TakeDamage(float damage)
    {
        enemyTankController.health -= damage;
        enemyTankController.enemyTankView.healthBar.UpdateHealthBar(enemyTankController.health, enemyTankController.defaultHealth);
        if (enemyTankController.health <= 0)
        {
            GameObject.Destroy(enemyTankController.enemyTankView.gameObject);
            Events.Instance.InvokeEnemiesKilled(AchievementSystem.Instance.totalEnemiesKilled + 1);
            Events.Instance.InvokeGameWon();
            ParticleSystems.Instance.PlayParticles(enemyTankController.enemyTankView.transform, Particles.TankExplosion, 2);
        }
    }
}