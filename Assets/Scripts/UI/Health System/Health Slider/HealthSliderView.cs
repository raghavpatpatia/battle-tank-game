using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSliderView : MonoBehaviour
{
    [SerializeField] private Slider healthSlider;
    public Slider HealthSlider { get { return healthSlider; } }
    private void OnEnable()
    {
        SetHealthSlider();
    }

    private void SetHealthSlider()
    {

    }
}