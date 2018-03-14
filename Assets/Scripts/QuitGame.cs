using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour 
{
	public void Quit()
	{
		Application.Quit();
	}

	public void Restart(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
}
