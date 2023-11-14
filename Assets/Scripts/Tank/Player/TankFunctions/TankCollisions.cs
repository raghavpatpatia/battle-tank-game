using UnityEngine;

public class TankCollisions
{
    private TankController tankController;
    public TankCollisions(TankController tankController)
    {
        this.tankController = tankController;
    }
    public void TakeDamage(int damage)
    {
        tankController.health -= damage;
        if (tankController.health <= 0)
        {
            GameObject.Destroy(tankController.tankView.gameObject);
            ParticleSystems.Instance.PlayParticles(tankController.tankView.transform, Particles.TankExplosion, 2);
        }
    }

    public void HandleCollisions(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletView>() != null)
        {
            TakeDamage(TankService.Instance.GetBulletDamage());
        }
        if (collision.gameObject.GetComponent<EnemyTankView>() != null)
        {
            TakeDamage(TankService.Instance.GetEnemyTankDamage());
        }
    }
}