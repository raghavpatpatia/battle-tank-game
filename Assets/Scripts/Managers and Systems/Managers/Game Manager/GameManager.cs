using Cinemachine;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : GenericSingleton<GameManager>
{
    [Header("Achievement Unlocked")]
    [SerializeField] public AchievementSystemUI achievementSystemUI;
    [SerializeField] public Achievements[] achievement;
    [Header("Player Tank Service")]
    [SerializeField] public TankScriptableObjectList tankObject;
    [SerializeField] public Joystick joystick;
    [SerializeField] public CinemachineVirtualCamera cam;
    [SerializeField] public Transform spawnPoint;
    [Header("Enemy Tank Service")]
    [SerializeField] public int enemyCount;
    [SerializeField] public EnemyTankScriptableObjectList enemyTankObject;
    [Header("Bullet Service")]
    [SerializeField] public BulletScriptableObjectList bulletList;
    
    private Events events;
    private TankService tankService;
    private EnemyTankService enemyTankService;
    private BulletService bulletService;
    private AchievementSystem achievementSystem;
    private SimpleBulletObjectPool bulletObjectPool;

    protected override void Awake()
    {
        base.Awake();
        events = new Events();
        tankService = new TankService();
        enemyTankService = new EnemyTankService();
        bulletService = new BulletService();
        achievementSystem = new AchievementSystem();
        bulletObjectPool = new SimpleBulletObjectPool();
        Initializations();
    }

    private void Initializations()
    {
        tankService.Initialization();
        enemyTankService.Initialization();
        bulletService.Initialization();
        achievementSystem.Initialization();
    }

    private void OnEnable()
    {
        TankService.Instance.Subscribe();
        AchievementSystem.Instance.Subscribe();
    }
    private void Start()
    {
        enemyTankService.SpawnNEnemies();
    }
    private void OnDisable()
    {
        TankService.Instance.Unsubscribe();
        AchievementSystem.Instance.Unsubscribe();
    }
}
