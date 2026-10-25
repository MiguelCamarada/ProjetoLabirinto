using UnityEngine;
using EasyPeasyFirstPersonController;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    public FirstPersonController firstPersonController;

    bool isPaused = false;

    void Start()
    {
        pauseUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);

        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        firstPersonController.enabled = false;
    }

    public void ResumeGame()
    {
        pauseUI.SetActive(false);

        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        firstPersonController.enabled = true;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();

        Debug.Log("Jogo encerrado.");
    }
}