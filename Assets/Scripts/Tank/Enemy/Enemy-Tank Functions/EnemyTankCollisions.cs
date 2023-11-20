using UnityEngine;

public class EnemyTankCollisions
{
    public EnemyTankController enemyTankController { get; private set; }
    public EnemyTankCollisions(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
    }

    public void TakeDamage(float damage)
    {
        enemyTankController.health -= damage;
        if (enemyTankController.health <= 0)
        {
            GameObject.Destroy(enemyTankController.enemyTankView.gameObject);
            ParticleSystems.Instance.PlayParticles(enemyTankController.enemyTankView.transform, Particles.TankExplosion, 2);
        }
    }

    public void HandleCollisions(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(enemyTankController.enemyTankDamage);
        }
    }
}