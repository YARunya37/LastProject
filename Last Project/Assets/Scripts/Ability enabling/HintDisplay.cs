using UnityEngine;

public class HintDisplay : MonoBehaviour
{
    public GameObject hintObject;

    public void HideHint()
    {
        hintObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hintObject.SetActive(true);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            HideHint();
        }
    }
}
