using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTankService : NonMonoGenericSingleton<EnemyTankService>
{
    public EnemyTankController enemyTankController { get; private set; }
    private int enemyCount;
    private EnemyTankScriptableObjectList enemyTankObject;
    private List<EnemyTankView> enemyTankViewList = new List<EnemyTankView>();

    public EnemyTankService() : base()
    {
        base.Initialize();
    }

    public void Initialization()
    {
        enemyCount = GameManager.Instance.enemyCount;
        enemyTankObject = GameManager.Instance.enemyTankObject;
    }

    public void SpawnNEnemies()
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

    public void Shoot(BulletType bulletType, Transform position)
    {
        BulletService.Instance.FireBullet(bulletType, position);
    }

    public Transform GetPlayerTransform()
    {
        return TankService.Instance.GetPlayerTransform();
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
                GameObject.Destroy(enemyTank.gameObject);
                ParticleSystems.Instance.PlayParticles(enemyTank.transform, Particles.TankExplosion, 2f);
            }
            yield return new WaitForSeconds(2f);
        }
        yield return new WaitForSeconds(2f);
    }

}