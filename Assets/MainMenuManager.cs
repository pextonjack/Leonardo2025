using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public FadeManager fadeManager;

    public void Play()
    {
        //StartCoroutine(GameManager.Instance.GotoGame());
        fadeManager.FadeOut();
    }
}
