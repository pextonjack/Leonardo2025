using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void Play()
    {
        StartCoroutine(GameManager.Instance.GotoGame());
    }
}
