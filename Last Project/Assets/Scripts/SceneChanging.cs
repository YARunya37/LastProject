using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChanging : MonoBehaviour
{
	GameManager gm;
	[SerializeField] int lvlNum;
	void Start() 
	{
		gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
	}
	private void OnTriggerEnter2D(Collider2D other) 
	{
		if(other.gameObject.CompareTag("Player"))
		{
			gm.SceneLoader(lvlNum);
		}	
	}
}
