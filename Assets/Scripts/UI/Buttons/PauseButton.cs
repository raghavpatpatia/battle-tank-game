using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private Button button;
    
    private void Start()
    {
        GameManager.Instance.pausePanel.SetActive(false);
        button = GetComponent<Button>();
        button.onClick.AddListener(Pause);
    }

    private void Pause()
    {
        Time.timeScale = 0.0f;
        GameManager.Instance.pausePanel.SetActive(true);
    }
}