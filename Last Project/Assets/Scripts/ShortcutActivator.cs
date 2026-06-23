using UnityEngine;

public class ShortcutActivator : MonoBehaviour
{
    [SerializeField] private GameObject shortcut;
    [SerializeField] private AudioSource audioSource;

    private bool activated;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated)
            return;

        if (!collision.CompareTag("Player"))
            return;

        activated = true;

        if(audioSource!= null)
            audioSource?.Play();
        
        shortcut.SetActive(false);
    }
}