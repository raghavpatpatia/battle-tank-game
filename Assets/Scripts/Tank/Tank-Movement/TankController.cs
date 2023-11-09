using UnityEngine;

public class TankController
{
    public TankModel tankModel { get; private set; }
    public TankView tankView { get; private set; }
    private float health;
    private Rigidbody rb;
    private Joystick joystick;
    private FollowPlayerScript followPlayer;

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

        rb = tankView.GetRigidbody();

        if (joystick != null)
        {
            this.joystick = joystick;
        }

        health = tankModel.health;
    }


    public void PlayerMovement()
    {
        Vector3 direction = new Vector3(joystick.direction.x, 0.0f, joystick.direction.y);
        rb.velocity = direction.normalized * tankModel.moveSpeed * Time.deltaTime;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float angleDifference = Quaternion.Angle(tankView.transform.rotation, targetRotation);
            if (angleDifference > tankModel.maxRotation)
            {
                float step = tankModel.maxRotation / angleDifference;
                tankView.transform.rotation = Quaternion.Slerp(tankView.transform.rotation, targetRotation, step);
            }
            tankView.transform.rotation = targetRotation;
        }
    } 
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GameObject.Destroy(tankView.gameObject);
        }
    }

    public void HandleCollisions(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletView>() && tankView.GetTankType() == TankTypes.Enemy)
        {
            TakeDamage(TankService.Instance.GetBulletDamage());
        }
    }

    public void Shoot(Transform bulletSpawnPoint)
    {
        TankService.Instance.Shoot(tankModel.bulletType, bulletSpawnPoint);
    }

}
