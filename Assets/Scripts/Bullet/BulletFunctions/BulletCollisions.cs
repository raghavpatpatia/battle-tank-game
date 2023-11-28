using UnityEngine;

public class BulletCollisions
{
    private BulletController bulletController;
    public BulletCollisions(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    public void CollisionCheck(Collision collision)
    {
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.TakeDamage(bulletController.GetBulletDamage());
        }
        GameObject.Destroy(bulletController.bulletView.gameObject);
        ParticleSystems.Instance.PlayParticles(bulletController.bulletView.transform, Particles.BulletDestruction, 2);
    }
}