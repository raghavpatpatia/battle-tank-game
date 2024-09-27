using Cinemachine;
using TMPro;
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
    [Header("UI Elements")]
    [SerializeField] public GameObject pausePanel;
    [SerializeField] public GameObject GameWinorLosePanel;
    [SerializeField] public TextMeshProUGUI GameWinorLoseText;
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
        Events.Instance.GameWon += GameWon;
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.pausePanel.SetActive(false);
        GameManager.Instance.GameWinorLosePanel.SetActive(false);
        enemyTankService.SpawnNEnemies();
    }

    private void GameWon()
    {
        if (achievementSystem.totalEnemiesKilled == enemyCount)
        {
            GameWinorLoseText.text = "Game Won";
            GameWinorLosePanel.SetActive(true);
        }
    }

    private void OnDisable()
    {
        TankService.Instance.Unsubscribe();
        AchievementSystem.Instance.Unsubscribe();
        Events.Instance.GameWon -= GameWon;
    }
}
