using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody rb;
    private Joystick joystick;
    private FollowPlayerScript followPlayer;

    public TankController(TankView view, TankModel model, Joystick joystick, FollowPlayerScript followPlayer)
    {
        tankModel = model;

        tankView = GameObject.Instantiate<TankView>(view);
        tankView.SetTankController(this);

        this.followPlayer = followPlayer;
        this.followPlayer.FollowPlayer(tankView);

        rb = tankView.GetRigidbody();

        this.joystick = joystick;
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

}
