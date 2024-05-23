using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
	[SerializeField] AudioSource au;
	[SerializeField] float jumpForce;
	GameManager gm;
	private void Start()
	{
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.CompareTag("Player") && gameObject.tag == "JumpPlate")
		{
			gm.Ability(gameObject.tag, au);
			collision.gameObject.GetComponent<BigJumpScript>().JumpForce = jumpForce;
		}  
		else if(collision.gameObject.CompareTag("Player"))
		{
			gm.Ability(gameObject.tag, au);
		}
	}
} 

