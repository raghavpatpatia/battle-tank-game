using UnityEngine;

public class BulletView : MonoBehaviour
{
    public BulletController bulletController { get; private set; }
    [SerializeField] private Rigidbody rb;
    public void SetBulletController(BulletController bulletController)
    {
        this.bulletController = bulletController;
    }
    public Rigidbody GetRigidbody()
    {
        return rb;
    }
    private void Start()
    {
        bulletController.MoveBullet();
    }
    private void OnCollisionEnter(Collision collision)
    {
        bulletController.DestroyBulletOnCollision();
    }
}