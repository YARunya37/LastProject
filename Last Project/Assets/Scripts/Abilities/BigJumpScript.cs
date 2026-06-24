using System.Collections;
using UnityEngine;

public class BigJumpScript : JumpScript
{
	public float JumpForce
	{
		get => bigJumpForce;
		set
		{
			if (value >= 100)
				bigJumpForce = 100;
			else if (value <= 0)
				bigJumpForce = 1;
			else
				bigJumpForce = value;
		}
	}
	[Header("Trail")]
	[SerializeField] private TrailRenderer trailRenderer;
	[Header("Animation")]
	[SerializeField] private float chargeTime = 0.2f;
	[SerializeField] private float crouchDistance = 0.15f;
	[SerializeField] private float crouchTime = 0.08f;

	[Header("Effects")]
	[SerializeField] private ParticleSystem launchRings;
	[SerializeField] private ParticleSystem speedLines;

	private float bigJumpForce;
	private bool isLaunching;

	private PlayerFillAnimation fillAnimation;

	private SpriteRenderer spriteRenderer;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		fillAnimation = GetComponent<PlayerFillAnimation>();

		spriteRenderer = GetComponent<SpriteRenderer>();

	}

	private void Update()
	{
		if (isLaunching)
			return;

		if (Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetButtonDown("Jump"))
		{
			StartCoroutine(LaunchRoutine());
		}
	}

	private IEnumerator LaunchRoutine()
	{
		isLaunching = true;

		if (IsGrounded())
		{
			Launch();
			yield break;
		}

		SetControlsLock(true);

		rb.velocity = Vector2.zero;

		launchRings?.Play();

		yield return AnimateCrouch();

		yield return new WaitForSeconds(chargeTime);

		Launch();
	}

	private IEnumerator AnimateCrouch()
	{
		Vector3 startPos = spriteRenderer.transform.localPosition;
		Vector3 endPos = startPos + Vector3.down * crouchDistance;

		float timer = 0;

		while (timer < crouchTime)
		{
			timer += Time.deltaTime;

			spriteRenderer.transform.localPosition =
				Vector3.Lerp(startPos, endPos, timer / crouchTime);

			yield return null;
		}

		timer = 0;

		while (timer < crouchTime)
		{
			timer += Time.deltaTime;

			spriteRenderer.transform.localPosition =
				Vector3.Lerp(endPos, startPos, timer / crouchTime);

			yield return null;
		}

		spriteRenderer.transform.localPosition = startPos;
	}

	private void Launch()
	{
		// Debug.Log(rb.velocity);
		rb.gravityScale = 2f;

		speedLines?.Play();

		rb.velocity = new Vector2(0, 0);
		rb.AddForce(Vector2.up * bigJumpForce, ForceMode2D.Impulse);

		SetControlsLock(false);

		fillAnimation.PlayFill(Color.white);
		trailRenderer.startColor = Color.white;
		trailRenderer.endColor = Color.white;
		// Debug.Log(rb.velocity);

		isLaunching = false;

		enabled = false;
	}
}