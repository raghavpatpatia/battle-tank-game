using Cinemachine;
using UnityEngine;

public class TankService : GenericSingleton<TankService>
{
    [SerializeField] private TankView tankView;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private CinemachineVirtualCamera cam;
    private TankController tankController;
    private TankModel tankModel;
    private FollowPlayerScript followPlayer;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        tankModel = new TankModel(moveSpeed, rotationSpeed);
        followPlayer = new FollowPlayerScript(cam);
        tankController = new TankController(tankView, tankModel, joystick, followPlayer);
    }
}
