using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
	public void PlayGame() 
	{	
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
