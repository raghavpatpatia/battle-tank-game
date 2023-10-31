using UnityEngine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        CameraFollow();
    }

    private void Update()
    {
        TankMovement();
    }

    private void TankMovement()
    {
        tankController.PlayerMovement();
    }

    private void CameraFollow()
    {
        tankController.FollowPlayer(this);
    }

    public void SetTankController(TankController controller)
    {
        tankController = controller;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
