using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image joystick_handle;
    private Image joystick_bg;
    private Vector2 positionInput;
    public Vector2 direction { get { return new Vector2(InputHorizontal(), InputVertical()); } }

    private void Start()
    {
        joystick_bg = GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joystick_bg.rectTransform, eventData.position, eventData.pressEventCamera, out positionInput))
        {
            positionInput.x = positionInput.x / (joystick_bg.rectTransform.sizeDelta.x);
            positionInput.y = positionInput.y / (joystick_bg.rectTransform.sizeDelta.y);

            // Normalize 
            if (positionInput.magnitude > 1.0f)
            {
                positionInput = positionInput.normalized;
            }

            // Joystick_handle movement
            joystick_handle.rectTransform.anchoredPosition = new Vector2(positionInput.x * (joystick_bg.rectTransform.sizeDelta.x / 2), positionInput.y * (joystick_bg.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        positionInput = Vector2.zero;
        joystick_handle.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float InputHorizontal()
    {
        if (positionInput.x != 0)
        {
            return positionInput.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    public float InputVertical()
    {
        if (positionInput.y != 0)
        {
            return positionInput.y;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }
    }
}
