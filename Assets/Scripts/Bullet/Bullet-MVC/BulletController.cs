using UnityEngine;

public class BulletController
{
    public BulletModel bulletModel { get; private set; }
    public BulletView bulletView { get; private set; }
    private Rigidbody rb;

    public BulletController(BulletScriptableObject bullet, Transform transform)
    {
        this.bulletView = GameObject.Instantiate<BulletView>(bullet.bulletView, transform.position, transform.rotation);
        this.bulletModel = new BulletModel(bullet);
        this.bulletView.SetBulletController(this);
        this.bulletModel.SetBulletController(this);

        rb = this.bulletView.GetRigidbody();
    }

    public void MoveBullet()
    {
        if (rb != null)
        {
            rb.AddForce(rb.transform.forward * bulletModel.range, ForceMode.Impulse);
        }
    }
    public void DestroyBulletOnCollision()
    {
        GameObject.Destroy(bulletView.gameObject);
    }

    public int GetBulletDamage()
    {
        return bulletModel.damage;
    }

}
