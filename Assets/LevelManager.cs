using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnLevelLoad();
    }

    public void OnLevelLoad()
    {
        Debug.Log("Level started!");
    }

    public void OnLevelComplete()
    {
        //StartCoroutine(GameManager.Instance.GotoGame());
        FindAnyObjectByType<FadeManager>().FadeOut();
    }
}