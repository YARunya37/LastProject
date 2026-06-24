using System.Collections;
using UnityEngine;

public class PlayerFillAnimation : MonoBehaviour
{
    [Header("Objects")]
    public Transform baseSquare;      // основной квадрат (фон)
    public Transform fillSquare;      // дочерний квадрат (заполняющий)

    [Header("Renderers")]
    public SpriteRenderer playerRenderer;
    public SpriteRenderer fillRenderer;

    [Header("Settings")]
    public float fillTime = 0.5f;

    private Vector3 baseScale;

    void Awake()
    {
        baseScale = baseSquare.localScale;

        // стартовое состояние
        fillSquare.localScale = Vector3.zero;
        SetAlpha(fillRenderer, 1f);
    }

    public void PlayFill(Color color)
    {
        StopAllCoroutines();
        StartCoroutine(FillSequence(color));
    }

    private IEnumerator FillSequence(Color color)
    {
        // ===== RESET =====
        baseSquare.localScale = baseScale;

        fillSquare.localScale = Vector3.zero;

        Color c = color;
        c.a = 1f;
        fillRenderer.color = c;

        // ===== FILL FROM CENTER =====
        float t = 0f;

        while (t < fillTime)
        {
            t += Time.deltaTime;
            float n = t / fillTime;

            // рост дочернего квадрата от центра
            fillSquare.localScale = Vector3.Lerp(Vector3.zero, baseScale, n);

            yield return null;
        }

        fillSquare.localScale = baseScale;
        playerRenderer.color = c;
    }

    private void SetAlpha(SpriteRenderer r, float a)
    {
        Color c = r.color;
        c.a = a;
        r.color = c;
    }
}
