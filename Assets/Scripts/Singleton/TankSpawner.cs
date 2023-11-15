using Cinemachine;
using UnityEngine;

public class TankSpawner : GenericSingleton<TankSpawner>
{
    [SerializeField] private TankView tankView;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private Joystick joystick;
    [SerializeField] private CinemachineVirtualCamera cam;
    private TankController tankController;

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        tankController = new TankController(tankView, moveSpeed, rotationSpeed, joystick, cam);
    }
}
