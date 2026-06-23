using UnityEngine;

public class FloatingAnimation : MonoBehaviour
{
    [SerializeField] private float amplitude = 0.15f;
    [SerializeField] private float frequency = 2f;

    private Vector3 startPosition;
    private float phase;

    private void Start()
    {
        startPosition = transform.position;
        phase = Random.Range(0f, Mathf.PI * 2f);
    }

    private void Update()
    {
        float y = Mathf.Sin(Time.time * frequency + phase) * amplitude;

        transform.position = startPosition + Vector3.up * y;
    }
}

