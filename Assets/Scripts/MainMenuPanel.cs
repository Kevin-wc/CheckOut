using UnityEngine;

public class MainMenuPanel : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuPanel;

    void Start()
    {
        Time.timeScale = 0f;

        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(true);
        }

        if (PlayerMovement.Instance != null)
        {
            PlayerMovement.Instance.enabled = false;
        }


        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        if (mainMenuPanel != null)
        {
            mainMenuPanel.SetActive(false);
        }

        if (PlayerMovement.Instance != null)
        {
            PlayerMovement.Instance.enabled = true;
        }

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
