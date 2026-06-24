using System.Collections;
using UnityEngine;

public class PlayerDeathEffect : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private SpriteRenderer faceRenderer;
    [SerializeField] private PlayerFillAnimation fillAnimation;
    [SerializeField] private TrailRenderer trail;

    [Header("Particles")]
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private ParticleSystem respawnParticles;

    [Header("Timings")]
    [SerializeField] private float deathAnimationTime = 0.25f;
    [SerializeField] private float respawnAnimationTime = 0.25f;
    Rigidbody2D rb;
    private DashScript dash;
    private BigJumpScript bigJump;

    private void Awake()
    {
        dash = GetComponent<DashScript>();
        bigJump = GetComponent<BigJumpScript>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void KillAndRespawn(Vector3 respawnPosition)
    {
        StartCoroutine(KillRoutine(respawnPosition));
    }

    private IEnumerator KillRoutine(Vector3 respawnPosition)
    {
        DisableAbilities();

        fillAnimation.PlayFill(Color.red);
        
        rb.constraints = RigidbodyConstraints2D.FreezePosition | rb.constraints;

        yield return new WaitForSeconds(deathAnimationTime);

        if (deathParticles != null)
        {
            deathParticles.transform.position = transform.position;
            deathParticles.Play();
        }

        spriteRenderer.enabled = false;
        faceRenderer.enabled = false;

        if (trail != null)
        {
            trail.enabled = false;
        }
        yield return new WaitForSeconds(deathAnimationTime + 0.05f);

        transform.position = respawnPosition;

        yield return new WaitForSeconds(respawnAnimationTime);
        spriteRenderer.enabled = true;
        faceRenderer.enabled = true;
        
        if (respawnParticles != null)
        {
            respawnParticles.transform.position = transform.position;
            respawnParticles.Play();
        }

        fillAnimation.PlayFill(Color.white);

        // yield return new WaitForSeconds(respawnAnimationTime);

        if (trail != null)
        {
            trail.Clear();
            trail.startColor = Color.white;
            trail.endColor = Color.white;
            trail.enabled = true;
        }

        rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
    }

    private void DisableAbilities()
    {
        if (dash != null)
            dash.enabled = false;

        if (bigJump != null)
            bigJump.enabled = false;
    }
}