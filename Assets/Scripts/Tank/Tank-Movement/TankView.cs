using UnityEngine;
using Cinemachine;

public class TankView : MonoBehaviour
{
    private TankController tankController;
    [SerializeField] private Rigidbody rb;

    private void Update()
    {
        TankMovement();
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
}
