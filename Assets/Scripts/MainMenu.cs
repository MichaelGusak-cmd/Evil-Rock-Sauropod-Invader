using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public GameObject sceneManager; 

	public void Start() {
		sceneManager = GameObject.FindWithTag("SceneManager");
	}

	public void PlayGame() 
	{	
		sceneManager.GetComponent<SceneChanger>().ChangeScene("level0");
	}

	public void QuitGame()
	{
		Debug.Log("Quit!");
		Application.Quit();
	}
}
