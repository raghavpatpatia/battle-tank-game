using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    [SerializeField] private Rigidbody rb;
    [SerializeField] public Transform bulletSpawnPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (tankController != null && GetTankType() == TankTypes.Player)
        {
            TankMovement();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tankController.Shoot(bulletSpawnPoint);
            }
        }
    }

    private void TankMovement()
    {
        tankController.PlayerMovement();
    }

    public void SetTankController(TankController controller)
    {
        tankController = controller;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (tankController != null)
        {
            tankController.HandleCollisions(collision);
        }
    }

    public TankTypes GetTankType()
    {
        return tankController != null ? tankController.tankModel.tankType : TankTypes.None;
    }
}
