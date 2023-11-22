using UnityEngine;

public class TankCollisionDamage
{
    private TankController tankController;
    public TankCollisionDamage(TankController tankController)
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
}