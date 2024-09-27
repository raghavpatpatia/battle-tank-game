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
    public event Action GameWon;
    public event Action ChangeScene;
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

    public void InvokeGameWon()
    {
        GameWon?.Invoke();
    }

    public void InvokeChangeScene()
    {
        ChangeScene?.Invoke();
    }
}