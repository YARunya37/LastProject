using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
	[SerializeField] AudioSource au;
	[SerializeField] Transform spawnPoint;
	private void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player") && !other.isTrigger)
		{
			other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
			DisableAllAbilities();
			au.Play();
			other.gameObject.transform.position = spawnPoint.position + new Vector3(0, 1, 0);
			Invoke("ChangeColour", 0.5f);
		}
	}
	void ChangeColour()
	{
		GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>().color = Color.white;
	}
	void DisableAllAbilities()
	{
		GameObject pl = GameObject.FindGameObjectWithTag("Player");
		pl.GetComponent<DashScript>().enabled = false;
		pl.GetComponent<BigJumpScript>().enabled = false;
	}
}
