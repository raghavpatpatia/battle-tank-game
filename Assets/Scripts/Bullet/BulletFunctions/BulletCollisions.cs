using UnityEngine;

public class BulletCollisions
{
    private BulletController bulletController;
    public BulletCollisions(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    public void DestroyBulletOnCollision()
    {
        if (bulletController.bulletView != null)
        {
            GameObject.Destroy(bulletController.bulletView.gameObject, 3f);
        }
    }

    public void GroundCollisionCheck(Collision collision)
    {
        GameObject.Destroy(bulletController.bulletView.gameObject);
        ParticleSystems.Instance.PlayParticles(bulletController.bulletView.transform, Particles.BulletDestruction, 2);
    }
}