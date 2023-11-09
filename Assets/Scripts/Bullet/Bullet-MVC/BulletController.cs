using UnityEngine;

public class BulletController
{
    public BulletModel bulletModel { get; private set; }
    public BulletView bulletView { get; private set; }
    public Rigidbody rb { get; private set; }

    private BulletMovement bulletMovement;
    private BulletCollisions bulletCollisions;

    public BulletController(BulletScriptableObject bullet, Transform transform)
    {
        this.bulletView = GameObject.Instantiate<BulletView>(bullet.bulletView, transform.position, transform.rotation);
        this.bulletModel = new BulletModel(bullet);
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);
        this.bulletMovement = new BulletMovement(this);
        this.bulletCollisions = new BulletCollisions(this);

        rb = this.bulletView.GetRigidbody();
    }
    public void MoveBullet()
    {
        bulletMovement.MoveBullet();
    }
    public void DestroyBulletOnCollision()
    {
        bulletCollisions.DestroyBulletOnCollision();
    }
    public void GroundCollisionCheck(Collision collision)
    {
        bulletCollisions.GroundCollisionCheck(collision);
    }
    public int GetBulletDamage()
    {
        return bulletModel.damage;
    }

}
