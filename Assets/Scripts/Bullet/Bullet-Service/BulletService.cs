﻿using UnityEngine;

public class BulletService : GenericSingleton<BulletService>
{
    [SerializeField] private BulletScriptableObjectList bulletList;
    public BulletController bulletController { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }
    public void FireBullet(BulletType bulletType, Transform transform)
    {
        bulletController = new BulletController(bulletList.bulletList[(int)bulletType - 1], transform);
    }
}
