using UnityEngine;

public class TankCollisions
{
    private TankController tankController;
    public TankCollisions(TankController tankController)
    {
        this.tankController = tankController;
    }
    public void TakeDamage(float damage)
    {
        tankController.health -= damage;
        if (tankController.health <= 0)
        {
            GameObject.Destroy(tankController.tankView.gameObject);
            ParticleSystems.Instance.PlayParticles(tankController.tankView.transform, Particles.TankExplosion, 2);
            levelmanager.Instance.DestroyEverythingCoroutine();
        }
    }

    public void HandleCollisions(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(tankController.tankDamage);
        }
    }
}