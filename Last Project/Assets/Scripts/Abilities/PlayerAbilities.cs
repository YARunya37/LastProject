using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PlayerAbilities : MonoBehaviour
{
    [Header("Trail")]
    [SerializeField] TrailRenderer trailRenderer;

    [Header("Colors")]
    [SerializeField]
    private Color dashColor =
        new Color(0.0509804f, 0.3333333f, 0.3568628f);

    [SerializeField]
    private Color jumpColor =
        new Color(0.866666f, 0.3568628f, 0.3568628f);

    private PlayerFillAnimation fillAnimation;
    private DashScript dashScript;
    private BigJumpScript bigJumpScript;

    void Start()
    {
        dashScript = GetComponent<DashScript>();
        bigJumpScript = GetComponent<BigJumpScript>();
        fillAnimation = GetComponent<PlayerFillAnimation>();
    }

    public void ActivateDash()
    {
        if (!dashScript.enabled)
        {
            fillAnimation.PlayFill(dashColor);
            trailRenderer.startColor = dashColor;
            trailRenderer.endColor = dashColor;
        }
        DisableAllAbilities();

        dashScript.enabled = true;
    }

    public void ActivateBigJump(float jumpForce)
    {
        if (!bigJumpScript.enabled)
        {
            fillAnimation.PlayFill(jumpColor);
            trailRenderer.startColor = jumpColor;
            trailRenderer.endColor = jumpColor;
        }
        DisableAllAbilities();

        bigJumpScript.JumpForce = jumpForce;
        bigJumpScript.enabled = true;
    }

    private void DisableAllAbilities()
    {
        dashScript.enabled = false;
        bigJumpScript.enabled = false;
    }
}