using System;

public class Events : NonMonoGenericSingleton<Events>
{
    public Events() : base()
    {
        base.Initialize();
    }

    public event Action ShootBullet;
    public event Action<int> BulletsFired;
    public event Action<int> EnemiesKilled;

    public void InvokeShootBullet()
    {
        ShootBullet?.Invoke();
    }

    public void InvokeBulletsFired(int bulletsFired)
    {
        BulletsFired?.Invoke(bulletsFired);
    }

    public void InvokeEnemiesKilled(int enemies)
    {
        EnemiesKilled?.Invoke(enemies);
    }
}