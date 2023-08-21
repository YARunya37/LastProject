using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public bool isDashAvaliable;
	GameObject player;
    private void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player");
    }
    public void SceneLoader(int sceneNum)
	{
		SceneManager.LoadScene(sceneNum);
	}
	public void Ability(string plateTag)
	{
		//определяем какую способность используем: если способность такая то скрипт ON 
		if(plateTag == "DashPlate")
		{
			player.GetComponent<DashScript>().enabled = true;
		}
	}
}
