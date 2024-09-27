using System.Collections.Generic;
using UnityEngine;

public class RangedBulletObjectPool : GenericObjectPool<BulletController>
{
    private BulletScriptableObject bulletData;
    private BulletType bulletType = BulletType.RangedBullet;

    public RangedBulletObjectPool() : base()
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