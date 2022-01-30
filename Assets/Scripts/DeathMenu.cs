using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    private GameObject sceneManager; 

	public void Start() {
		sceneManager = GameObject.FindWithTag("SceneManager");
	}

    public void Retry() 
	{	
		sceneManager.GetComponent<SceneChanger>().PrevScene();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene("Menu");
	}
}
