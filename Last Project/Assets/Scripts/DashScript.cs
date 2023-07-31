using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : PlayerController
{
	[SerializeField] float dashForce;
	private void Start() 
	{
		rb = GetComponent<Rigidbody2D>();
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	void Update() 
	{
		Dash();
	}
	void Dash()
	{
		if(Input.GetKeyDown(KeyCode.LeftShift) && gm.canDash)
		{
			
		}
	}
}
