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
    }

    public void PlayerTank(int index)
    {
        TankScriptableObject tank = tankObject.tankList[index];
        FollowPlayerScript followPlayer = new FollowPlayerScript(cam);
        tankController = new TankController(tank, joystick, followPlayer, spawnPoint);
    }

    public void Shoot(BulletType bulletType, Transform position)
    {
        BulletService.Instance.FireBullet(bulletType, position);
    }

    public Transform GetPlayerTransform()
    {
        return tankController.GetTransform();
    }
}
