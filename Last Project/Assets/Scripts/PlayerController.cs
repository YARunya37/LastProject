using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField] LayerMask walls;
	protected Rigidbody2D rb;
	protected GameManager gm;
	float speed = 8;
    void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
		rb = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		Move();
		Cheats();
	}
	void Move()
	{
        if (Input.GetButton("Horizontal") && CanMove())
		{
			CanMove();
			rb.velocity = new Vector2(speed * Input.GetAxis("Horizontal"), rb.velocity.y);
		}
		else
		{
			rb.velocity = new Vector2(0, rb.velocity.y);
		}
	}
	bool CanMove()
	{
        for (float i = 0.5f; i >= -0.5f; i -= 0.5f)
		{
			if(Physics2D.Raycast(transform.position - new Vector3(-0.5f, i), Vector2.right, 0.02f, walls) && Input.GetAxis("Horizontal") > 0)
			{
				return false;
			}
			else if(Physics2D.Raycast(transform.position - new Vector3(0.5f, i), Vector2.left, 0.02f, walls) && Input.GetAxis("Horizontal") < 0)
			{
				return false;
			}
		}
		return true;
	}
	protected float GetDirection()
	{
		if (Input.GetAxis("Horizontal") == 1)
		{
			return 1;
		}
		else
		{
			return -1;
		}
	}
	void Cheats()
	{
		if (Input.GetKeyDown(KeyCode.K))
		{
			gm.isDashAvaliable = true;
		}
	}
}
