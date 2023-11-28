using Cinemachine;
using UnityEngine;

public class TankService : NonMonoGenericSingleton<TankService>
{
    private TankScriptableObjectList tankObject;
    private Joystick joystick;
    private CinemachineVirtualCamera cam;
    private Transform spawnPoint;
    public TankController tankController { get; private set; }

    public TankService() : base()
    {
        base.Initialize();
    }
    public void Initialization()
    {
        tankObject = GameManager.Instance.tankObject;
        cam = GameManager.Instance.cam;
        joystick = GameManager.Instance.joystick;
        spawnPoint = GameManager.Instance.spawnPoint;
        PlayerTank(Random.Range(0, tankObject.tankList.Length));
    }

    public void Subscribe()
    {
        if (Events.Instance != null)
        {
            Events.Instance.ShootBullet += Shoot;
        }
    }

    public void PlayerTank(int index)
    {
        TankScriptableObject tank = tankObject.tankList[index];
        FollowPlayerScript followPlayer = new FollowPlayerScript(cam);
        tankController = new TankController(tank, joystick, followPlayer, spawnPoint);
    }

    public void Shoot()
    {
        if (tankController.rb != null)
        {
            BulletService.Instance.FireBullet(tankController.tankModel.bulletType, tankController.tankView.BulletSpawnPoint);
        }
    }

    public Transform GetPlayerTransform()
    {
        return tankController.GetTransform();
    }

    public void Unsubscribe()
    {
        Events.Instance.ShootBullet -= Shoot;
    }
}
