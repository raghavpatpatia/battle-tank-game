using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : GenericSingleton<EnemyTankService>
{
    public EnemyTankController enemyTankController { get; private set; }
    [SerializeField] private int enemyCount;
    [SerializeField] private EnemyTankScriptableObjectList enemyTankObject;
    public List<EnemyTankView> enemyTankViewList = new List<EnemyTankView>();
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
        enemyTankViewList.Add(enemyTankController.enemyTankView);
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

    public IEnumerator DestroyAllEnemies()
    {
        List<EnemyTankView> validEnemies = new List<EnemyTankView>();
        foreach (EnemyTankView enemyTank in enemyTankViewList)
        {
            if (enemyTank != null)
            {
                validEnemies.Add(enemyTank);
            }
        }

        foreach (EnemyTankView enemyTank in validEnemies)
        {
            if (enemyTank != null)
            {
                Destroy(enemyTank.gameObject);
                ParticleSystems.Instance.PlayParticles(enemyTank.transform, Particles.TankExplosion, 2f);
            }
            yield return new WaitForSeconds(1f);
        }

        yield return new WaitForSeconds(2f);
    }

}