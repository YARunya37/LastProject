using System.Collections;
using UnityEngine;

public class DestroyingScript : MonoBehaviour
{
	[Header("Timing")]
	[SerializeField] private float destroyDelay = 1f;
	[SerializeField] private float recoverDelay = 2f;

	[Header("Particles")]
	[SerializeField] private ParticleSystem crackParticles;
	[SerializeField] private ParticleSystem destroyParticles;
	[SerializeField] private ParticleSystem recoverParticles;

	[SerializeField] private int stage1Particles = 3;
	[SerializeField] private int stage2Particles = 6;
	[SerializeField] private int stage3Particles = 10;
	[SerializeField] private int destroyParticlesCount = 40;

	[Header("Audio")]
	[SerializeField] private AudioSource audioSource;
	[SerializeField] private AudioClip crackSound;
	[SerializeField] private AudioClip destroySound;

	[Header("Shake")]
	[SerializeField] private float shakeDistance = 0.03f;
	[SerializeField] private float shakeDuration = 0.08f;

	private BoxCollider2D boxCollider;
	private SpriteRenderer spriteRenderer;

	private Vector3 spriteStartPos;
	private bool isDestroying;

	private void Start()
	{
		boxCollider = GetComponent<BoxCollider2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();

		spriteStartPos = spriteRenderer.transform.localPosition;

		if (destroyDelay <= 0 || recoverDelay <= 0)
			Debug.LogWarning($"{name}: DestroyDelay или RecoverDelay не заданы.");
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (isDestroying)
			return;

		if (!other.gameObject.CompareTag("Player"))
			return;

		StartCoroutine(DestroyRoutine());
	}

	private IEnumerator DestroyRoutine()
	{
		isDestroying = true;

		if (destroyDelay < 0.3f)
		{
			yield return new WaitForSeconds(destroyDelay);
			DestroyPlatform();
			yield break;
		}

		float stage1 = destroyDelay * 0.2f;
		float stage2 = destroyDelay * 0.35f;
		float stage3 = destroyDelay * 0.45f;

		yield return new WaitForSeconds(stage1);

		yield return Stage(stage1Particles);

		yield return new WaitForSeconds(stage2);

		yield return Stage(stage2Particles);

		yield return new WaitForSeconds(stage3);

		yield return Stage(stage3Particles);

		DestroyPlatform();
	}

	private IEnumerator Stage(int particles)
	{
		audioSource?.PlayOneShot(crackSound);

		crackParticles.Emit(particles);

		yield return Shake();

	}

	private IEnumerator Shake()
	{
		float timer = 0f;

		while (timer < shakeDuration)
		{
			timer += Time.deltaTime;

			spriteRenderer.transform.localPosition =
				spriteStartPos +
				(Vector3)Random.insideUnitCircle * shakeDistance;

			yield return null;
		}

		spriteRenderer.transform.localPosition = spriteStartPos;
	}

	private void DestroyPlatform()
	{
		Color color = spriteRenderer.color;
		color.a = 0f;
		spriteRenderer.color = color;

		boxCollider.enabled = false;

		destroyParticles.Emit(destroyParticlesCount);

		audioSource?.PlayOneShot(destroySound);

		StartCoroutine(RecoverRoutine());
	}

	private IEnumerator RecoverRoutine()
	{
		yield return new WaitForSeconds(recoverDelay);

		recoverParticles.Play();

		yield return new WaitForSeconds(0.15f);

		Color color = spriteRenderer.color;
		color.a = 1f;
		spriteRenderer.color = color;

		boxCollider.enabled = true;

		isDestroying = false;
	}
}