using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static bool isFading = false;
    [SerializeField] bool fadeOnStart = true;

    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        anim.Play("FadeIn");
        isFading = true;
    }

    public void FadeInDone()
    {
        isFading = false;
    }

    public void FadeOut()
    {
        anim.Play("FadeOut");
        isFading = true;
    }

    public void FadeOutDone()
    {
        isFading = false;
        StartCoroutine(GameManager.Instance.GotoGame());
    }
}
