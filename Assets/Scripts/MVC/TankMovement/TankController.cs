using Cinemachine;
using UnityEngine;

public class TankController
{
    private TankModel tankModel;
    private TankView tankView;
    private Rigidbody rb;
    private Joystick joystick;
    private CinemachineVirtualCamera cam;

    public TankController(TankView view, float movementSpeed, float rotationSpeed, Joystick joystick, CinemachineVirtualCamera cam)
    {
        tankModel = new TankModel(movementSpeed, rotationSpeed);

        tankView = GameObject.Instantiate<TankView>(view);
        tankView.SetTankController(this);

        rb = tankView.GetRigidbody();

        this.joystick = joystick;
        this.cam = cam;
    }

    public void FollowPlayer(TankView view)
    {
        cam.Follow = view.transform;
        cam.LookAt = view.transform;
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
