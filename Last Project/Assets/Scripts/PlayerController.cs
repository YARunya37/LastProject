using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	protected Rigidbody2D rb;
	float speed = 8;
	protected GameManager gm;
	
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
}
