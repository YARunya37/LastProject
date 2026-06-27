using System.Collections;
using UnityEngine;

public abstract class AbilityActivator : MonoBehaviour
{
    [SerializeField] protected AudioSource audioSource;

    [Header("Cooldown")]
    [SerializeField] private float pickupCooldown = 1f;

    protected AbilityPickupAnimation abilityAnimation;
    protected AbilityBoardPickup boardPickupAnim;

    private bool canPickup = true;

    private void Start()
    {
        abilityAnimation = GetComponent<AbilityPickupAnimation>();
        boardPickupAnim = GetComponent<AbilityBoardPickup>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canPickup)
            return;

        if (!collision.CompareTag("Player"))
            return;

        if (!collision.TryGetComponent(out PlayerAbilities playerAbilities))
            return;

        canPickup = false;
        StartCoroutine(PickupCooldownRoutine());

        abilityAnimation?.PlayPickup();
        boardPickupAnim?.PlayPickup();

        Activate(playerAbilities);

        if(audioSource)
            audioSource?.Play();
    }

    private IEnumerator PickupCooldownRoutine()
    {
        yield return new WaitForSeconds(pickupCooldown);
        canPickup = true;
    }

    protected abstract void Activate(PlayerAbilities playerAbilities);
}