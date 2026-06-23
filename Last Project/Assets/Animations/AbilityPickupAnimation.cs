using System.Collections;
using UnityEngine;

public class AbilityPickupAnimation : MonoBehaviour
{
    [Header("Objects")]
    public Transform baseCircle;
    public Transform whiteCircle;

    [Header("Renderers")]
    public SpriteRenderer whiteRenderer;

    [Header("Settings")]
    public float fillTime = 0.5f;
    public float pulseScale = 1.15f;
    public float burstScale = 1.35f;

    private Vector3 baseScale;
    private Vector3 whiteStartScale;

    void Awake()
    {
        baseScale = baseCircle.localScale;
        whiteStartScale = Vector3.zero;

        whiteCircle.localScale = whiteStartScale;
        SetAlpha(whiteRenderer, 0f);
    }

    public void PlayPickup()
    {
        StopAllCoroutines();
        StartCoroutine(Sequence());
    }

    private IEnumerator Sequence()
    {
        // reset
        baseCircle.localScale = baseScale;
        whiteCircle.localScale = Vector3.zero;
        SetAlpha(whiteRenderer, 1f);

        // 1. Fill from center (scale up white circle)
        float t = 0f;

        while (t < fillTime)
        {
            t += Time.deltaTime;
            float n = t / fillTime;

            whiteCircle.localScale = Vector3.Lerp(Vector3.zero, baseScale, n);
            yield return null;
        }

        whiteCircle.localScale = baseScale;

        // 2. Pulse effect
        yield return ScaleTo(baseCircle, baseScale, baseScale * pulseScale, 0.12f);

        // 3. Burst expand
        yield return ScaleTo(baseCircle, baseCircle.localScale, baseScale * burstScale, 0.15f);

        // white overlay fade out during burst
        yield return FadeWhite(0.15f);

        // 4. Reset
        whiteCircle.localScale = Vector3.zero;
        SetAlpha(whiteRenderer, 0f);
        baseCircle.localScale = baseScale;
    }

    private IEnumerator ScaleTo(Transform target, Vector3 from, Vector3 to, float duration)
    {
        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            target.localScale = Vector3.Lerp(from, to, t / duration);
            yield return null;
        }

        target.localScale = to;
    }

    private IEnumerator FadeWhite(float duration)
    {
        float t = 0f;
        Color c = whiteRenderer.color;
        float startA = c.a;

        while (t < duration)
        {
            t += Time.deltaTime;
            float n = t / duration;

            c.a = Mathf.Lerp(startA, 0f, n);
            whiteRenderer.color = c;

            yield return null;
        }

        c.a = 0f;
        whiteRenderer.color = c;
    }

    private void SetAlpha(SpriteRenderer r, float a)
    {
        Color c = r.color;
        c.a = a;
        r.color = c;
    }
}