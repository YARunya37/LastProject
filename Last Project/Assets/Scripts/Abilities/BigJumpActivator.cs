using UnityEngine;

public class BigJumpActivator : AbilityActivator
{
    [SerializeField] private float jumpForce = 10f;

    protected override void Activate(PlayerAbilities playerAbilities)
    {
        playerAbilities.ActivateBigJump(jumpForce);
    }
}