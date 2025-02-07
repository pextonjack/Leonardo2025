using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    private PlayerInput playerInput;

    [Header("Pause Setup")]
    public GameObject pauseMenu;
    public static bool isPaused;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1f;
    }

    void OnEnable()
    {
        isPaused = false;

        playerInput = FindAnyObjectByType<PlayerInput>();
    }

    void TogglePause()
    {
        if (isPaused)
            Unpause();
        else
            Pause();
    }

    public void Update()
    {
        if (playerInput.actions["Pause"].WasPressedThisFrame())
            TogglePause();
    }

    public void Pause()
    {
        isPaused = true;

        Time.timeScale = 0f;

        pauseMenu.SetActive(true);
    }

    public void Unpause()
    {
        isPaused = false;

        Time.timeScale = 1f;

        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        isPaused = false;

        StartCoroutine(GameManager.Instance.GotoMenu());
    }
}
