using UnityEngine;

public class BulletService : NonMonoGenericSingleton<BulletService>
{
    private BulletScriptableObjectList bulletList;
    private SimpleBulletObjectPool simpleBulletObjectPool;
    private RangedBulletObjectPool rangedBulletObjectPool;
    public Transform transform;
    BulletController bulletController;

    public BulletService() : base()
    {
        base.Initialize();
    }

    public void Initialization()
    {
        bulletList = GameManager.Instance.bulletList;
        simpleBulletObjectPool = new SimpleBulletObjectPool();
        rangedBulletObjectPool = new RangedBulletObjectPool();
    }

    public void FireBullet(BulletType bulletType, Transform transform)
    {
        this.transform = transform;
        if (bulletType == BulletType.SimpleBullet)
        {
            bulletController = simpleBulletObjectPool.GetBullet(bulletList.bulletList[(int)bulletType - 1]);
        }
        if (bulletType == BulletType.RangedBullet)
        {
            bulletController = rangedBulletObjectPool.GetBullet(bulletList.bulletList[(int)bulletType - 1]);
        }
        bulletController.EnableBullet(transform);
    }

    public void BulletCollision(BulletController bulletController, BulletType bulletType)
    {
        bulletController.DisableBullet();
        switch (bulletType)
        {
            case BulletType.SimpleBullet:
                simpleBulletObjectPool.ReturnItem(bulletController);
                break;
            case BulletType.RangedBullet:
                rangedBulletObjectPool.ReturnItem(bulletController);
                break;
            default: break;
        }
    }
}
