using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyingScript : MonoBehaviour
{
	[SerializeField] float destroyDelay;
	[SerializeField] float recoverDelay;
	BoxCollider2D plCol;
	SpriteRenderer spr;
	private void Start()
	{
		if(destroyDelay == 0 || recoverDelay ==0)
		{
			Debug.Log("Not all variables are assigned");
		}
		plCol = GetComponent<BoxCollider2D>();
		spr = GetComponent<SpriteRenderer>();
	}
    void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Invoke("DestroyPlatform", destroyDelay);
		}
	}
	void DestroyPlatform()
	{
		plCol.enabled = false;
		spr.enabled = false;
		StartCoroutine(PlatformRecover());
	}
	IEnumerator PlatformRecover()
	{
		yield return new WaitForSeconds(recoverDelay);
		spr.enabled = true;
		plCol.enabled = true;
	}
}
