using UnityEngine;

public class TankModel
{
    public TankController tankController { get; private set; }
    public float moveSpeed { get; private set; }
    public float maxRotation { get; private set; }
    public float health { get; set; }
    public TankTypes tankType { get; private set; }
    public BulletType bulletType { get; private set; }

    public TankModel(TankScriptableObject tank)
    {
        this.moveSpeed = tank.moveSpeed;
        this.maxRotation = tank.maxRotation;
        this.health = tank.health;
        this.bulletType = tank.bulletType;
        this.tankType = tank.tankType;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
