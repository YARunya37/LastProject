using UnityEngine;

public class DashActivator : AbilityActivator
{
    protected override void Activate(PlayerAbilities playerAbilities)
    {
        playerAbilities.ActivateDash();
    }
}