using Cinemachine;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    [SerializeField] TankScriptableObjectList tankObject;
    [SerializeField] private Joystick joystick;
    [SerializeField] private CinemachineVirtualCamera cam;
    [SerializeField] private Transform spawnPoint;
    public TankController tankController { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        PlayerTank(Random.Range(0, tankObject.tankList.Length));
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

    private void OnDisable()
    {
        Events.Instance.ShootBullet -= Shoot;
    }
}
