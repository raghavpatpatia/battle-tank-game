using UnityEditor.iOS;
using UnityEngine;

public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }
    public Rigidbody rb { get; private set; }
    public Joystick joystick { get; private set; }
    public float health { get; set; }
    public float defaultHealth { get; private set; }
    private FollowPlayerScript followPlayer;
    private TankMovement tankMovement;
    private TankCollisionDamage tankCollisionDamage;

    public TankController(TankScriptableObject tank, Joystick joystick, FollowPlayerScript followPlayer, Transform SpawnPoint)
    {
        tankModel = new TankModel(tank);
        tankView = GameObject.Instantiate<TankView>(tank.tankView, SpawnPoint);
        this.followPlayer = followPlayer;
        this.followPlayer.FollowPlayer(tankView);

        tankView.SetTankController(this);
        tankModel.SetTankController(this);

        this.tankMovement = new TankMovement(this);
        this.tankCollisionDamage = new TankCollisionDamage(this);

        rb = tankView.GetRigidbody();

        this.joystick = joystick;

        health = tankModel.health;
        defaultHealth = tankModel.health;
    }


    public void PlayerMovement()
    {
        tankMovement.PlayerMovement();
    } 
    
    public void TakeDamage(float damage)
    {
        tankCollisionDamage.TakeDamage(damage);
    }

    public Transform GetTransform()
    {
        return rb.transform;
    }

}
