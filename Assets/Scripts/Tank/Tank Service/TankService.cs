using Cinemachine;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    [SerializeField] TankScriptableObjectList tankObject;
    [SerializeField] TankScriptableObjectList enemyTankObject;
    [SerializeField] int enemyCount;
    [SerializeField] private Joystick joystick;
    [SerializeField] private CinemachineVirtualCamera cam;
    private TankController tankController;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        PlayerTank(Random.Range(0, tankObject.tankList.Length));
        for (int i = 0; i < enemyCount; i++)
        {
            EnemyTank(Random.Range(0, enemyTankObject.tankList.Length));
        }
    }

    public void PlayerTank(int index)
    {
        TankScriptableObject tank = tankObject.tankList[index];
        FollowPlayerScript followPlayer = new FollowPlayerScript(cam);
        tankController = new TankController(tank, joystick, followPlayer);
    }

    public void EnemyTank(int index)
    {
        TankScriptableObject tank = enemyTankObject.tankList[index];
        tankController = new TankController(tank, null, null, 10, 2);
    }

    public void Shoot()
    {
        if (tankController != null)
        {
            BulletService.Instance.FireBullet(tankController.tankModel.bulletType, tankController.tankView.bulletSpawnPoint);
        }
    }
}
