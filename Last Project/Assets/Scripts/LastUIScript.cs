using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastUIScript : MonoBehaviour
{
    [SerializeField] Canvas UI;
    private void Update()
    {
        if(GameObject.FindGameObjectWithTag("End") == null && SceneManager.GetSceneByBuildIndex(1).isLoaded)
        {
            UI.enabled = true; 
        }
    }
}
