using System.Collections.Generic;
using UnityEngine;

public class SimpleBulletObjectPool : GenericObjectPool<BulletController>
{
    private BulletScriptableObject bulletData;
    private BulletType bulletType = BulletType.SimpleBullet;

    public SimpleBulletObjectPool() : base()
    {
        base.Initialize();
    }

    public BulletController GetBullet(BulletScriptableObject bulletData)
    {
        this.bulletData = bulletData;
        return GetItem();
    }

    protected override BulletController CreateItem()
    {
        BulletController bulletController = new BulletController(bulletData, bulletType);
        return bulletController;
    }
}