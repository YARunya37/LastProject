using UnityEngine;

public class ShortcutActivator : MonoBehaviour
{
    [SerializeField] private GameObject shortcut;
    [SerializeField] private AudioSource audioSource;
    AbilityBoardPickup activatedAnimation;
    private bool activated;

    void Start()
    {
        activatedAnimation = GetComponent<AbilityBoardPickup>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (activated)
            return;

        if (!collision.CompareTag("Player"))
            return;

        activatedAnimation.PlayPickup();
        activated = true;

        if (audioSource != null)
            audioSource?.Play();

        shortcut.SetActive(false);
    }
}