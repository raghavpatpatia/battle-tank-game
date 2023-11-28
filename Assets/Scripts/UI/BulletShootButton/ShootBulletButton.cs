using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShootBulletButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Events.Instance.InvokeShootBullet();
        Events.Instance.InvokeBulletsFired(AchievementSystem.Instance.bulletsFired + 1);
    }
}