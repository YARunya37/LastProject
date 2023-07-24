using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float jumpForce;
	[SerializeField] float startScale;
	[SerializeField] float fallingScale;
	[SerializeField] LayerMask ground;
	float fallingPoint;
	Rigidbody2D rb;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		fallingPoint = 0.2f;
	}
	void Update()
	{
		Move();
		Jump();
	}
	void Move()
	{
		if (Input.GetButton("Horizontal"))
		{
			rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
		}
		else
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
	}
	void Jump()
	{
		if (Input.GetButtonDown("Jump") && IsGrounded())
		{
			rb.gravityScale = startScale;
			rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
		}
		if(rb.velocity.y <= fallingPoint)
		{
			rb.gravityScale = fallingScale;
		}
	}
	bool IsGrounded()
	{

		if (Physics2D.Raycast(transform.position - new Vector3(0, 0.5f), Vector2.down, 0.1f, ground))
		{
			return true;
		}
		return false;
	}
}
