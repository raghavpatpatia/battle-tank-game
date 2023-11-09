using UnityEngine;
using UnityEngine.UI;

public class BulletService : GenericSingleton<BulletService>
{
    [SerializeField] private Button fireButton;
    [SerializeField] private BulletScriptableObjectList bulletList;
    public BulletController bulletController { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        fireButton.onClick.AddListener(Shoot);
    }

    public void Shoot()
    {
        if (bulletController == null) return;
        TankService.Instance.Shoot();
    }

    public void FireBullet(BulletType bulletType, Transform transform)
    {
        bulletController = new BulletController(bulletList.bulletList[(int)bulletType], transform);
    }
}
