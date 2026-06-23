using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigJumpScript : JumpScript
{
	public float JumpForce
	{
		get{ return bigJumpForce; }
		set{ 
			if(value >= 100)
				bigJumpForce = 100;
			else if(value <= 0)
				bigJumpForce = 1; 
			else
			 bigJumpForce = value;
			}
	}
	float bigJumpForce;
	[SerializeField] Canvas UI;
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.LeftShift) && !Input.GetButtonDown("Jump"))
		{
			UI.enabled = false;
			gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
			rb.AddForce(new Vector2(0, bigJumpForce), ForceMode2D.Impulse);   
			gameObject.GetComponent<BigJumpScript>().enabled = false;
			gameObject.GetComponent<SpriteRenderer>().color = Color.white;
		}
	}
}
