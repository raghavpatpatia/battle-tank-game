using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Resume);
    }

    private void Resume()
    {
        Time.timeScale = 1.0f;
        GameManager.Instance.pausePanel.SetActive(false);
    }
}