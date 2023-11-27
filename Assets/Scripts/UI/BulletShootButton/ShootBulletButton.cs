using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ShootBulletButton : MonoBehaviour
{
    private Button button;
    private Events events;

    private void Start()
    {
        events = new Events();
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Events.Instance.InvokeShootBullet();
    }
}