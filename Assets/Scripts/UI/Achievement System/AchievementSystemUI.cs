using TMPro;
using UnityEngine;

public class AchievementSystemUI : GenericSingleton<AchievementSystemUI>
{
    private Animator animator;
    private TextMeshProUGUI text;
    protected override void Awake()
    {
        base.Awake();
    }

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