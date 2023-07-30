using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
	GameManager gm;
	void Start() 
	{
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	void OnTriggerStay2D(Collider2D other) 
	{
		if(other.gameObject.CompareTag("Player") && gm.isDashAvaliable)
		{
			gm.canDash = true;
		}	
	}
}
