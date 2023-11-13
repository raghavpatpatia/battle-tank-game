using UnityEngine;

public class EnemyTankCollisions
{
    public EnemyTankController enemyTankController { get; private set; }
    public EnemyTankCollisions(EnemyTankController enemyTankController)
    {
        this.enemyTankController = enemyTankController;
    }

    public void TakeDamage(float damage)
    {
        enemyTankController.health -= damage;
        if (enemyTankController.health <= 0)
        {
            GameObject.Destroy(enemyTankController.enemyTankView.gameObject);
        }
    }

    public void HandleCollisions(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletView>() != null)
        {
            if (enemyTankController.enemyTankModel.enemyTankType == EnemyTanks.FullMoonTank)
            {
                TakeDamage(2 * EnemyTankService.Instance.GetBulletDaamge());
            }
            if (enemyTankController.enemyTankModel.enemyTankType == EnemyTanks.DarkKnightTank)
            {
                TakeDamage(0.5f * EnemyTankService.Instance.GetBulletDaamge());
            }
            if (enemyTankController.enemyTankModel.enemyTankType == EnemyTanks.NightSkyTank)
            {
                TakeDamage(EnemyTankService.Instance.GetBulletDaamge());
            }
            GameObject.Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<TankView>() != null)
        {
            TakeDamage(EnemyTankService.Instance.GetTankDamage());
        }
    }
}