using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour 
{
    public AudioScript Audio;
	void OnEnable()
	{
        Audio = GameObject.Find("AudioManager").GetComponent<AudioScript>();
        print("loaded");
        SceneManager.sceneLoaded += OnSceneLoaded;

	}

	public void Quit()
	{
		Application.Quit();
	}
    IEnumerator StartBattle(string audioPath, int track, string sceneName) {
        yield return new WaitForSeconds(2);
        Audio.playSFX("_SFX/UI/Referee Whistle 2");
        yield return new WaitForSeconds(1);
        Audio.playAudio(audioPath, track);
        Audio.src0.loop = true;
        SceneManager.LoadScene(sceneName);

    }
    public void Restart(string sceneName)
	{
        Audio.resetAllAudio();
        print("restart");
        switch (sceneName) {
            case "MainMenu":
                Audio.resetAllAudio();
                SceneManager.LoadScene(sceneName);
                /*  When you return to this scene, the buttons lose functionality since GameManager is now in Dont destroy and they cannot find it anymore.
                 *  Weirdly enough, the buttons still work fine so I am guessing witchcraft is afoot
                GameObject.Find("SaltPittButton").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<QuitGame>().Restart("Salt Pitt High Gym"));
                GameObject.Find("ScholaGrandisButton").GetComponent<Button>().onClick.AddListener(() => Restart("Schola Grandis Gym"));
                GameObject.Find("MightMainButton").GetComponent<Button>().onClick.AddListener(() => Restart("MightMain Academy Gym"));
                */            
            break;
            case "MapScreen":
                Audio.playAudio("Concept Sound/80's something", 0);
                Audio.src0.loop = true;
                SceneManager.LoadScene("MapScreen");
                break;
            case "DialogueTest":
                SceneManager.LoadScene("DialogueTest");
                break;

            case "Salt Pitt High Gym":
                Audio.resetAllAudio();
                Audio.playSFX("Voice Acting/Announcer Lines/Saltpitt/Jeff_SaltpittAnnouncer_1");
                StartCoroutine(StartBattle("Salt Pitt Battle", 0, sceneName));
                break;
            case "Schola Grandis Gym":
                Audio.resetAllAudio();
                Audio.playSFX("Voice Acting/Announcer Lines/ScholaGrandis/Brandon_ScholaAnnouncer_8");
                StartCoroutine(StartBattle("TheOneOnTop", 0, sceneName));
                break;
            case "MightMain Academy Gym":
                Audio.resetAllAudio();
                Audio.playSFX("Voice Acting/Announcer Lines/Saltpitt/Alan_SaltpittAnnouncer_4");
                StartCoroutine(StartBattle("MightMain Battle", 0, sceneName));
                break;
            case "Yamato Gym":
                Audio.resetAllAudio();
                Audio.playSFX("Voice Acting/Announcer Lines/Saltpitt/Eric_SaltpittAnnouncer_3");
                StartCoroutine(StartBattle("Yamato Battle", 0, sceneName));
                break;
            case "OpenOcean":
                Audio.resetAllAudio();
                Audio.playSFX("Voice Acting/Announcer Lines/Saltpitt/Eric_SaltpittAnnouncer_3");
                StartCoroutine(StartBattle("Yamato Battle", 0, sceneName));
                break;
            default:
                Audio.resetAllAudio();
                Audio.playAudio("Concept Sound/80's something", 0);
                Audio.src0.loop = true;
                break;
        }
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{
        Audio = GameObject.Find("AudioManager").GetComponent<AudioScript>();
        if (SceneManager.GetActiveScene ().name == "MainMenu") 
		{
			GameObject.Find("SaltPittButton").GetComponent<Button>().onClick.AddListener(()=>Restart("Salt Pitt High Gym"));
			GameObject.Find("ScholaGrandisButton").GetComponent<Button>().onClick.AddListener(()=>Restart("Schola Grandis Gym"));
			GameObject.Find("MightMainButton").GetComponent<Button>().onClick.AddListener(()=>Restart("MightMain Academy Gym"));
            GameObject.Find("Yamato").GetComponent<Button>().onClick.AddListener(() => Restart("Yamato Gym"));
            if(GameObject.Find("MapButton") != null)GameObject.Find("MapButton").GetComponent<Button>().onClick.AddListener(() => Restart("MapScreen"));

            print("Buttons Found");
		}
        if(SceneManager.GetActiveScene().name == "MapScreen") {
            GameObject.Find("SaltPittButton").GetComponent<Button>().onClick.AddListener(() => Restart("Salt Pitt High Gym"));
            GameObject.Find("ScholaGrandisButton").GetComponent<Button>().onClick.AddListener(() => Restart("Schola Grandis Gym"));
            GameObject.Find("MightMainButton").GetComponent<Button>().onClick.AddListener(() => Restart("MightMain Academy Gym"));
            GameObject.Find("Yamato").GetComponent<Button>().onClick.AddListener(() => Restart("Yamato Gym"));
            GameObject.Find("MainMenu").GetComponent<Button>().onClick.AddListener(() => Restart("MainMenu"));
            GameObject.Find("OpenOcean").GetComponent<Button>().onClick.AddListener(() => Restart("OpenOcean"));

        }
    }
}
