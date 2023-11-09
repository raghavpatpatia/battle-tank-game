using UnityEngine;

public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }
    public Rigidbody rb { get; private set; }
    public Joystick joystick { get; private set; }
    public float health { get; set; }
    private FollowPlayerScript followPlayer;
    private TankMovement tankMovement;
    private TankCollisions tankCollisions;

    public TankController(TankScriptableObject tank, Joystick joystick = null, FollowPlayerScript followPlayer = null, float randomX = 0, float randomZ = 0)
    {
        tankModel = new TankModel(tank);

        if (tankModel.tankType == TankTypes.Player)
        {
            tankView = GameObject.Instantiate<TankView>(tank.tankView);
            this.followPlayer = followPlayer;
            this.followPlayer.FollowPlayer(tankView);
        }
        else
        {
            tankView = GameObject.Instantiate<TankView>(tank.tankView, new Vector3(Random.Range(-randomX, randomX), 0, Random.Range(-randomZ, randomZ)), Quaternion.identity);
        }

        tankView.SetTankController(this);
        tankModel.SetTankController(this);

        this.tankMovement = new TankMovement(this);
        this.tankCollisions = new TankCollisions(this);

        rb = tankView.GetRigidbody();

        if (joystick != null)
        {
            this.joystick = joystick;
        }

        health = tankModel.health;
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
