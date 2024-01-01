using UnityEngine;

public class BulletController
{
    public BulletModel bulletModel { get; private set; }
    public BulletView bulletView { get; private set; }
    public Rigidbody rb { get; private set; }

    private BulletMovement bulletMovement;
    private BulletCollisions bulletCollisions;

    public BulletController(BulletScriptableObject bullet, BulletType type)
    {
        this.bulletView = GameObject.Instantiate<BulletView>(bullet.bulletView, BulletService.Instance.transform.position, Quaternion.identity);
        this.bulletModel = new BulletModel(bullet, type);
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
    public void CollisionCheck(Collision collision)
    {
        bulletCollisions.CollisionCheck(collision);
    }
    public int GetBulletDamage()
    {
        return bulletModel.damage;
    }

    public void EnableBullet(Transform transform)
    {
        rb.transform.position = transform.position;
        rb.transform.rotation = transform.rotation;
        rb.gameObject.SetActive(true);
        MoveBullet();
    }
    public void DisableBullet()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.identity;
        rb.gameObject.SetActive(false);
    }
}
