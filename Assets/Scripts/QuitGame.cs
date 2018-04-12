using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour 
{
	void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;

	}

	public void Quit()
	{
		Application.Quit();
	}

	public void Restart(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if (SceneManager.GetActiveScene ().name == "TransitionScene") 
		{
			GameObject.Find("SaltPittButton").GetComponent<Button>().onClick.AddListener(()=>Restart("Salt Pitt High Gym"));
			GameObject.Find("ScholaGrandisButton").GetComponent<Button>().onClick.AddListener(()=>Restart("Schola Grandis Gym"));
			GameObject.Find("MightMainButton").GetComponent<Button>().onClick.AddListener(()=>Restart("MightMain Academy Gym"));
			print ("Buttons Found");
		}
	}
}
