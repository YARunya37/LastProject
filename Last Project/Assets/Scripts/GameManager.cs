using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public bool isDashAvaliable = false;
	[SerializeField] GameObject shortCut;
	[SerializeField] Canvas canvas;
	int curScene;
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
	
	public void Ability(string plateTag)
	{
		//определяем какую способность используем: если способность такая то скрипт ON 
		if(plateTag == "DashPlate" && isDashAvaliable)
		{
			player.GetComponent<DashScript>().enabled = true;
            player.GetComponent<SpriteRenderer>().color = new Color(0.0509804f, 0.3333333f, 0.3568628f);
		}
		if(plateTag == "Shortcuter")
		{
			shortCut.SetActive(false);
		}
	}
}
