using UnityEngine;

public class BulletMovement
{
    private BulletController bulletController;

    public BulletMovement(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    public void MoveBullet()
    {
        if (bulletController.rb != null)
        {
            bulletController.rb.AddForce(bulletController.rb.transform.forward * bulletController.bulletModel.range * Time.deltaTime, ForceMode.Impulse);
        }
    }
}