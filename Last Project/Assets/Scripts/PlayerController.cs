using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	protected Rigidbody2D rb;
	[SerializeField] float dashForce;
	float speed = 8;
	GameManager gm;
	
	void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		Move(); 	
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

	void Dash()
	{
		if (gm.canDash && Input.GetKeyDown(KeyCode.LeftShift))
		{
			rb.AddForce(new Vector2(dashForce, rb.velocity.y), ForceMode2D.Impulse);
		}
	}
}
