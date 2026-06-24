using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] Canvas canvas;
	[SerializeField] Canvas UI;
	GameObject player;
	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}
	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Time.timeScale = 0f;
			gameObject.SetActive(false);
			canvas.enabled = true;
		}
	}
	public void UnPause()
	{
		Time.timeScale = 1f;
		canvas.enabled = false;
		gameObject.SetActive(true);
	}
	public void SceneLoader(int sceneNum)
	{
		if (sceneNum == 999)
		{
			Application.Quit();
		}
		SceneManager.LoadScene(sceneNum);
	}
}
