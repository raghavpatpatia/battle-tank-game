using UnityEngine;

public class EnemyTankService : GenericSingleton<EnemyTankService>
{
    public EnemyTankController enemyTankController { get; private set; }
    [SerializeField] private int enemyCount;
    [SerializeField] private EnemyTankScriptableObjectList enemyTankObject;
    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy(i);
        }
    }

    private void SpawnEnemy(int index)
    {
        int enemyTankListSize = enemyTankObject.enemyTankList.Length;
        EnemyTankScriptableObject enemyTank = enemyTankObject.enemyTankList[index % enemyTankListSize];
        enemyTankController = new EnemyTankController(enemyTank, -30, -23);
    }

    public int GetBulletDaamge()
    {
        return BulletService.Instance.GetDamage();
    }

    public void Shoot(BulletType bulletType, Transform position)
    {
        BulletService.Instance.FireBullet(bulletType, position);
    }

    public int GetEnemyTankDamage()
    {
        return enemyTankController.enemyTankDamage;
    }

    public int GetTankDamage()
    {
        return TankService.Instance.GetTankDamage();
    }
}