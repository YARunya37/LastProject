using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBoardPickup : MonoBehaviour
{
    [Header("Tiles")]
    public Transform baseTile;
    public Transform whiteTile;
    public SpriteRenderer whiteRenderer;

    [Header("Settings")]
    public float fillTime = 0.5f;
    public float returnTime = 0.25f;

    private Vector3 baseScale;

    void Awake()
    {
        baseScale = baseTile.localScale;

        // start state
        whiteTile.localScale = new Vector3(1f, 0f, 1f);
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
        baseTile.localScale = baseScale;
        whiteTile.localScale = new Vector3(1f, 0f, 1f);
        SetAlpha(whiteRenderer, 1f);

        // 1. Fill from TOP -> DOWN
        float t = 0f;

        while (t < fillTime)
        {
            t += Time.deltaTime;
            float n = t / fillTime;

            // scale Y grows downward because pivot is top
            whiteTile.localScale = new Vector3(1f, n, 1f);

            yield return null;
        }

        whiteTile.localScale = new Vector3(1f, 1f, 1f);

        // 2. Hold moment (optional tiny delay)
        yield return new WaitForSeconds(0.05f);

        // 3. Return to original color (no burst, no scale effect)
        yield return FadeBack(returnTime);

        // 4. Reset overlay
        whiteTile.localScale = new Vector3(1f, 0f, 1f);
        SetAlpha(whiteRenderer, 0f);
    }

    private IEnumerator FadeBack(float duration)
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
