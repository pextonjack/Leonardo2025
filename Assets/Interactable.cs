using UnityEngine;

public class Interactable : MonoBehaviour
{
    private PlayerMovement player;
    private GameObject child;
    private void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>();
        //child = transform.GetChild(0).gameObject;
    }

    /*
    private void FixedUpdate()
    {
        if ((transform.position - player.transform.position).magnitude < 2.5f)
        {
            child.SetActive(true);
        }
        else child.SetActive(false);
    }
    */

    public void Interact()
    {
        Debug.Log("Interacted with!");
        FindAnyObjectByType<LevelManager>().OnLevelComplete();
    }
}
