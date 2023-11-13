using UnityEngine;

public class TankMovement
{
    private TankController tankContoller;
    public TankMovement(TankController tankContoller)
    {
        this.tankContoller = tankContoller;
    }
    public void PlayerMovement()
    {
        Vector3 direction = new Vector3(tankContoller.joystick.direction.x, 0.0f, tankContoller.joystick.direction.y);
        tankContoller.rb.velocity = direction.normalized * tankContoller.tankModel.moveSpeed * Time.deltaTime;
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            float angleDifference = Quaternion.Angle(tankContoller.tankView.transform.rotation, targetRotation);
            if (angleDifference > tankContoller.tankModel.maxRotation)
            {
                float step = tankContoller.tankModel.maxRotation / angleDifference;
                tankContoller.tankView.transform.rotation = Quaternion.Slerp(tankContoller.tankView.transform.rotation, targetRotation, step);
            }
            tankContoller.tankView.transform.rotation = targetRotation;
        }
    }
}