using UnityEngine;

public class TankModel
{
    public TankController tankController { get; private set; }
    public float moveSpeed { get; private set; }
    public float maxRotation { get; private set; }
    public float health { get; set; }
    public BulletType bulletType { get; private set; }

    public TankModel(TankScriptableObject tank)
    {
        this.moveSpeed = tank.moveSpeed;
        this.maxRotation = tank.maxRotation;
        this.health = tank.health;
        this.bulletType = tank.bulletType;
    }

    public void SetTankController(TankController tankController)
    {
        this.tankController = tankController;
    }
}
