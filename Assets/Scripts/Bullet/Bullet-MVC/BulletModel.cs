﻿using UnityEngine;

public class BulletModel
{
    public BulletController bulletController { get; private set; }
    public int range { get; private set; }
    public int damage { get; private set; }
    public BulletType type { get; private set; }
    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }

    public BulletModel(BulletScriptableObject bullet, BulletType type)
    {
        this.damage = bullet.damage;
        this.range = bullet.range;
        this.type = type;
    }
}
