using UnityEngine;

public abstract class AbilityActivator : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (!collision.TryGetComponent(out PlayerAbilities playerAbilities))
            return;

        Activate(playerAbilities);

        if(audioSource != null)
            audioSource?.Play();
    }

    protected abstract void Activate(PlayerAbilities playerAbilities);
}