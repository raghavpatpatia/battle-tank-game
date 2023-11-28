using TMPro;
using UnityEngine;

public class AchievementSystemUI : MonoBehaviour
{
    private Animator animator;
    private TextMeshProUGUI text;

    private void Start()
    {
        animator = GetComponent<Animator>();
        text = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void UpdateText(string newText)
    {
        text.text = newText;
        Animate();
    }

    private void Animate()
    {
        animator.SetTrigger("AchievementUnlocked");
    }
}