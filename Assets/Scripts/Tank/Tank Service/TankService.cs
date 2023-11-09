using Cinemachine;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    [SerializeField] TankScriptableObjectList tankObject;
    [SerializeField] TankScriptableObjectList enemyTankObject;
    [SerializeField] int enemyCount;
    [SerializeField] private Joystick joystick;
    [SerializeField] private CinemachineVirtualCamera cam;
    public TankController tankController { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        PlayerTank(Random.Range(0, tankObject.tankList.Length));
        for (int i = 0; i < enemyCount; i++)
        {
            EnemyTank(i);
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
        int tankListSize = enemyTankObject.tankList.Length;
        TankScriptableObject tank = enemyTankObject.tankList[index % tankListSize];
        tankController = new TankController(tank, null, null, 10, 2);
    }

    public void Shoot(BulletType bulletType, Transform position)
    {
        BulletService.Instance.FireBullet(bulletType, position);
    }

    public int GetBulletDamage()
    {
        return BulletService.Instance.GetDamage();
    }
}
