using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public GameManager instance;
	void Start() 
	{
		instance = GetComponent<GameManager>();	
	}
	public void SceneLoader(int sceneNum)
	{
		SceneManager.LoadScene(sceneNum);
	}
}
