using UnityEngine;

public class TankModel
{
    private TankController tankController;
    public float moveSpeed { get; private set; }
    public float maxRotation { get; private set; }

    public TankModel(float speed, float rotation)
    {
        moveSpeed = speed;
        maxRotation = rotation;
    }
}
