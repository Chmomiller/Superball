using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour 
{
    public bool hardMode = false;
	public static GameManager instance = null;
    public AudioScript Audio;

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
        if (UnityEngine.Random.Range(0, 20) == 0) {
            UnityEngine.SceneManagement.SceneManager.LoadScene("A New Student 7");
        } else {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
        }
    }
}
