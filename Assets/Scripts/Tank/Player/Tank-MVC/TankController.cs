using UnityEditor.iOS;
using UnityEngine;

public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }
    public Rigidbody rb { get; private set; }
    public Joystick joystick { get; private set; }
    public float health { get; set; }
    public int tankDamage { get; private set; }
    public TankType tankType { get; private set; }
    private FollowPlayerScript followPlayer;
    private TankMovement tankMovement;
    private TankCollisions tankCollisions;

    public TankController(TankScriptableObject tank, Joystick joystick, FollowPlayerScript followPlayer, Transform SpawnPoint)
    {
        tankModel = new TankModel(tank);
        tankView = GameObject.Instantiate<TankView>(tank.tankView, SpawnPoint);
        this.followPlayer = followPlayer;
        this.followPlayer.FollowPlayer(tankView);

        tankView.SetTankController(this);
        tankModel.SetTankController(this);

        this.tankMovement = new TankMovement(this);
        this.tankCollisions = new TankCollisions(this);

        rb = tankView.GetRigidbody();

        this.joystick = joystick;

        health = tankModel.health;
        tankDamage = tankModel.tankDamage;
        tankType = tankModel.tankType;
    }


    public void PlayerMovement()
    {
        tankMovement.PlayerMovement();
    } 
    
    public void TakeDamage(int damage)
    {
        tankCollisions.TakeDamage(damage);
    }

    public void HandleCollisions(Collision collision)
    {
        tankCollisions.HandleCollisions(collision);
    }

    public void Shoot(Transform bulletSpawnPoint)
    {
        TankService.Instance.Shoot(tankModel.bulletType, bulletSpawnPoint);
    }

}
