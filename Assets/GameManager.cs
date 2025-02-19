using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool CanPlayerMove => (!PauseManager.isPaused && SceneManager.GetActiveScene().name != "Menu" && !FadeManager.isFading);

    private static GameManager instance;

    public void Update()
    {
        if (CanPlayerMove || FadeManager.isFading)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    // Ensure this instance exists only once in the game
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // If the instance doesn't exist, find it or create it
                instance = FindAnyObjectByType<GameManager>();

                if (instance == null)
                {
                    // Create a new GameObject and attach the GameManager if none exists
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }

                // Mark the instance to persist across scene loads
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    public IEnumerator GotoGame()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!asyncLoad.isDone)
        {
            yield return null; // Wait until the scene is fully loaded
        }
    }

    public IEnumerator GotoMenu()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu");
        while (!asyncLoad.isDone)
        {
            yield return null; // Wait until the scene is fully loaded
        }
    }

    // Ensures that there is only one instance of GameManager
    private void Awake()
    {
        // If the instance already exists and it's not this one, destroy this duplicate
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            // If it's the first instance, set the reference
            instance = this;
            DontDestroyOnLoad(gameObject); // Make sure it doesn't get destroyed on scene change
        }
    }
}