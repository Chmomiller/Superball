using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
    public bool hardMode = false;
	public static GameManager instance = null;
	public SaveManager Save;
    public AudioScript Audio;

    public bool consistency = false; //Disables any random/easter egg content when true

    public static string globalString = "NA";
    public static int globalInt = 0;
    public static bool globalBool = false;
	void Awake()
	{
        Audio = GameObject.Find("AudioManager").GetComponent<AudioScript>();
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

		SceneManager.sceneLoaded += OnSceneLoaded;
	}

    public void swapDifficulties() {
        hardMode = !hardMode;

        if (hardMode) {
            GameObject.Find("DodgeCity").GetComponent<SpriteRenderer>().color = new Color32(155, 155, 155, 255);
            GameObject.Find("DodgeCity 1").GetComponent<SpriteRenderer>().color = new Color32(155, 155, 155, 255);
        } else {
            GameObject.Find("DodgeCity").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
            GameObject.Find("DodgeCity 1").GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

        }
    }

    public void loadAnyScene(string name) {
        GameObject.Find("AudioManager").GetComponent<AudioScript>().resetAllAudio();
        if (UnityEngine.Random.Range(0, 20) == 0 && consistency == false) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("A New Student 7");
        } else {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }
    }

	// This function is called when a scene is loaded and is used to activate buttons on the map screen
	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
		if(scene.name == "MapScreen")
		{
			GameObject SaltPittButton = GameObject.Find ("SaltPittButton");
			GameObject ScholaGrandisButton = SaltPittButton.GetComponent<MapButtonOptions> ().ScholaGrandisButton;
			GameObject MightMainButton = SaltPittButton.GetComponent<MapButtonOptions>().MightMainButton;
			GameObject YamatoButton = SaltPittButton.GetComponent<MapButtonOptions>().Yamato;

			// Activate Salt Pitt buttons
			if(Save.SaltPittDialogue)
			{
				SaltPittButton.GetComponent<MapButtonOptions> ().saltPittProgress = 1;
			}
			// Activate Schola Grandis buttons
			if(Save.SaltPittBattle)
			{
				SaltPittButton.GetComponent<MapButtonOptions> ().saltPittProgress = 2;
				if(Save.SaltPittDialogue)
				{
					SaltPittButton.GetComponent<MapButtonOptions> ().scholaGrandisProgress = 1;
				}
			}
			// Activate MightMain Academy buttons
			if(Save.ScholaGrandisBattle)
			{
				SaltPittButton.GetComponent<MapButtonOptions> ().scholaGrandisProgress = 2;

				if(Save.ScholaGrandisDialog)
				{
					SaltPittButton.GetComponent<MapButtonOptions> ().mightMainProgress = 1;
				}
			}
			// Activate Yamato buttons
			if(Save.MightMainBattle)
			{
				SaltPittButton.GetComponent<MapButtonOptions> ().mightMainProgress = 2;

			}
		}
		/*
		if(scene.name == "SlugCon MightMain Academy Gym")
		{
			Audio.playAudio ("Mightmain Battle", 0);
		}
		*/
	}
}
