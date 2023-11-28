using UnityEngine;

public class BulletService : NonMonoGenericSingleton<BulletService>
{
    private BulletScriptableObjectList bulletList;
    private BulletController bulletController;

    public BulletService() : base()
    {
        base.Initialize();
    }

    public void Initialization()
    {
        bulletList = GameManager.Instance.bulletList;
    }

    public void FireBullet(BulletType bulletType, Transform transform)
    {
        bulletController = new BulletController(bulletList.bulletList[(int)bulletType - 1], transform);
    }
}
