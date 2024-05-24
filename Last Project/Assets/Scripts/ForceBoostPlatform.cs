using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ForceBoostPlatform : MonoBehaviour
{
	[SerializeField] float boostForce;
	[SerializeField] Vector2 direction;
   	void OnTriggerEnter2D(Collider2D other)
   	{
		if (other.gameObject.CompareTag("Player"))
		{
			Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
			rb.velocity = Vector3.zero;
			rb.AddForce(direction*boostForce, ForceMode2D.Impulse);
		}
   	}
}
