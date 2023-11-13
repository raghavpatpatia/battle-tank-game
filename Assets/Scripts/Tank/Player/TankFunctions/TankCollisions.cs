using UnityEngine;

public class TankCollisions
{
    private TankController tankController;
    public TankCollisions(TankController tankController)
    {
        this.tankController = tankController;
    }
    public void TakeDamage(int damage)
    {
        tankController.health -= damage;
        if (tankController.health <= 0)
        {
            GameObject.Destroy(tankController.tankView.gameObject);
        }
    }

    public void HandleCollisions(Collision collision)
    {
        //if (collision.gameObject.GetComponent<BulletView>() != null)
        //{
        //    TakeDamage(TankService.Instance.GetBulletDamage());
        //    GameObject.Destroy(collision.gameObject);
        //}
        if (collision.gameObject.GetComponent<EnemyTankView>() != null)
        {
            TakeDamage(TankService.Instance.GetEnemyTankDamage());
        }
    }
}