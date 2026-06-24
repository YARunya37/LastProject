using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : PlayerController
{
	[SerializeField] AudioSource jump;
	[SerializeField] float jumpForce = 13f;
	[SerializeField] float startScale = 3;
	[SerializeField] float fallingScale = 2;
	[SerializeField] LayerMask ground;
	float fallingPoint = 0.2f;
	bool isRotating = false;
	PlayerController controller;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		controller = GetComponent<PlayerController>();
	}
	void Update()
	{
		Jump();
	}
	void Jump()
	{
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			rb.gravityScale = startScale;
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

			if (!isRotating)
				StartCoroutine(RotatePlayer());
		}

		if (rb.velocity.y <= fallingPoint)
		{
			rb.gravityScale = fallingScale;
		}
	}
	public bool IsGrounded()
	{
		if (Physics2D.Raycast(transform.position - new Vector3(0, 0.5f), Vector2.down, 0.1f, ground)
			|| Physics2D.Raycast(transform.position - new Vector3(0.5f, 0.5f), Vector2.down, 0.1f, ground)
			|| Physics2D.Raycast(transform.position - new Vector3(-0.5f, 0.5f), Vector2.down, 0.1f, ground))
		{
			return true;
		}

		return false;
	}
	IEnumerator RotatePlayer()
	{
		isRotating = true;

		Quaternion startRot = transform.rotation;
		Quaternion targetRot = Quaternion.Euler(0, 0, transform.eulerAngles.z + (-controller.FacingDirection * 90));

		float duration = 0.25f;
		float t = 0;

		while (t < 1f)
		{
			t += Time.deltaTime / duration;
			transform.rotation = Quaternion.Lerp(startRot, targetRot, t);
			yield return null;
		}

		transform.rotation = Quaternion.Euler(0, 0, 0);

		isRotating = false;
	}
}
