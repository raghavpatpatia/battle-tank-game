using System;

public class Events : NonMonoGenericSingleton<Events>
{
    public Events() : base()
    {
        base.Initialize();
    }

    public event Action ShootBullet;

    public void InvokeShootBullet()
    {
        ShootBullet?.Invoke();
    }
}