using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	private GameObject sceneManager; 

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

	public void OnMouseOver()
	{
		Debug.Log("mouse over");
	}
	public void OnMouseExit()
	{
		//The mouse is no longer hovering over the GameObject so output this message each frame
		Debug.Log("Mouse is no longer on GameObject.");
	}
}
