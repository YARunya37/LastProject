using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public bool isDashAvaliable;
	public bool canDash;
	public void SceneLoader(int sceneNum)
	{
		SceneManager.LoadScene(sceneNum);
	}
}
