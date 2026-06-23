using UnityEngine;

public abstract class AbilityActivator : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;
    protected AbilityPickupAnimation abilityAnimation;
    protected AbilityBoardPickup boardPickupAnim;
    void Start()
    {
        abilityAnimation = GetComponent<AbilityPickupAnimation>();
        boardPickupAnim = GetComponent<AbilityBoardPickup>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
            return;

        if (!collision.TryGetComponent(out PlayerAbilities playerAbilities))
            return;

        if (abilityAnimation)
            abilityAnimation.PlayPickup();
        if (boardPickupAnim)
            boardPickupAnim.PlayPickup();

        Activate(playerAbilities);

        if (audioSource != null)
            audioSource?.Play();
    }

    protected abstract void Activate(PlayerAbilities playerAbilities);
}