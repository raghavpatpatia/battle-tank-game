using UnityEngine;

public class BulletController
{
    public BulletModel bulletModel { get; private set; }
    public BulletView bulletView { get; private set; }
    private Rigidbody rb;

    public BulletController(BulletScriptableObject bullet, Transform transform)
    {
        this.bulletModel = new BulletModel(bullet);
        this.bulletView = GameObject.Instantiate<BulletView>(bullet.bulletView, transform.position, transform.rotation);
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);

        rb = this.bulletView.GetRigidbody();
    }

    public void MoveBullet()
    {
        rb.AddForce(rb.transform.forward * bulletModel.range);
    }

    public void HandleCollisions(Collision collision)
    {
        GameObject.Destroy(bulletView.gameObject);
    }

}
