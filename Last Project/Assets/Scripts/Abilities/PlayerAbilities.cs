using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class PlayerAbilities : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField]
    private Color dashColor =
        new Color(0.0509804f, 0.3333333f, 0.3568628f);

    [SerializeField]
    private Color jumpColor =
        new Color(0.866666f, 0.3568628f, 0.3568628f);


    private DashScript dashScript;
    private BigJumpScript bigJumpScript;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        dashScript = GetComponent<DashScript>();
        bigJumpScript = GetComponent<BigJumpScript>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void ActivateDash()
    {
        DisableAllAbilities();

        dashScript.enabled = true;

        spriteRenderer.color = dashColor;
    }

    public void ActivateBigJump(float jumpForce)
    {
        DisableAllAbilities();

        bigJumpScript.JumpForce = jumpForce;
        bigJumpScript.enabled = true;

        spriteRenderer.color = jumpColor;
    }

    private void DisableAllAbilities()
    {
        dashScript.enabled = false;
        bigJumpScript.enabled = false;
    }
}