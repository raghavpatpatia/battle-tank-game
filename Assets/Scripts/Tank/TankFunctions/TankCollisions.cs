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
        if (collision.gameObject.GetComponent<BulletView>() != null && tankController.tankView.GetTankType() == TankTypes.Enemy)
        {
            TakeDamage(TankService.Instance.GetBulletDamage());
            GameObject.Destroy(collision.gameObject);
        }
    }
}