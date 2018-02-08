using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance = null;

	void Awake()
	{
		// This block makes sure that there is only one GameManager when a level is loaded and that the GameManager is persistent.
		if(instance == null)
		{
			instance = this;
		}
		else if(instance != this)
		{
			Destroy (gameObject);
		}
		DontDestroyOnLoad (gameObject);
	}
}
