using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour 
{
    public AudioScript Audio;
    public GameManager Game;
    public bool loadingScene = false;
	void OnEnable()
	{
        Audio = GameObject.Find("AudioManager").GetComponent<AudioScript>();
        Game = gameObject.GetComponent<GameManager>();
        //The lowercase gameObject is intentional. It refers to the object this script is attached to
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
        loadingScene = false;
        SceneManager.LoadScene(sceneName);
        

    }
    public void Restart(string sceneName)
	{
        print(loadingScene);
        if (loadingScene) return;

        loadingScene = true;
        Audio.resetAllAudio();
        print("restart");
        switch (sceneName) {
            case "MainMenu":
                Audio.resetAllAudio();
                Audio.playSFX("_SFX/Battle sfx/swoosh/swoosh");
                Audio.playAudio("Concept Sound/80s something", 0);
                loadingScene = false;
                SceneManager.LoadScene(sceneName);

                /*  When you return to this scene, the buttons lose functionality since GameManager is now in Dont destroy and they cannot find it anymore.
                 *  Weirdly enough, the buttons still work fine so I am guessing witchcraft is afoot
                GameObject.Find("SaltPittButton").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<QuitGame>().Restart("Salt Pitt High Gym"));
                GameObject.Find("ScholaGrandisButton").GetComponent<Button>().onClick.AddListener(() => Restart("Schola Grandis Gym"));
                GameObject.Find("MightMainButton").GetComponent<Button>().onClick.AddListener(() => Restart("MightMain Academy Gym"));
                */            
            break;
            case "MapScreen":
                Audio.resetAllAudio();
                int random = UnityEngine.Random.Range(0, 100);

                if (random <= 5 && Game.consistency == false) {
                    if (random <= 1) {
                        Audio.playAudio("Concept Sound/Unknown Individuals 2", 0);
                    } else {
                        Audio.playAudio("Concept Sound/Who Am I", 0);
                    }
                } else {
                    Audio.playAudio("Concept Sound/80s something", 1);
                }
                
                Audio.src0.loop = true;
                loadingScene = false;
                SceneManager.LoadScene("MapScreen");
                break;
            case "DialogueMenu":
                loadingScene = false;
                SceneManager.LoadScene("DialogueMenu");
                break;

            case "Salt Pitt High Gym":
                Audio.resetAllAudio();
                Audio.playSFX("Voice Acting/Announcer Lines/Saltpitt/Jeff_SaltpittAnnouncer_1");
                StartCoroutine(StartBattle("Salt Pitt Battle", 0, sceneName));
                break;
            case "Schola Grandis Gym":
                Audio.resetAllAudio();
                Audio.playSFX("Voice Acting/Announcer Lines/ScholaGrandis/Brandon_ScholaAnnouncer_8");
                StartCoroutine(StartBattle("Schola Grandis Battle", 0, sceneName));
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
                print("open");
                Audio.playSFX("Voice Acting/Announcer Lines/Saltpitt/Eric_SaltpittAnnouncer_3");
                StartCoroutine(StartBattle("Yamato Battle", 0, sceneName));
                break;
            default:
                Audio.resetAllAudio();
                Audio.playAudio("Concept Sound/80's something", 0);
                Audio.src0.loop = true;
                loadingScene = false;
                break;
        }
	}

	void OnSceneLoaded(Scene scene, LoadSceneMode mode)
	{

        if(GameObject.Find("MainMenu") != null) GameObject.Find("MainMenu").GetComponent<Button>().onClick.AddListener(() => Restart("MainMenu"));

        Audio = GameObject.Find("AudioManager").GetComponent<AudioScript>();
        if (SceneManager.GetActiveScene().name == "MainMenu") {
            //GameObject.Find("SaltPittButton").GetComponent<Button>().onClick.AddListener(() => Restart("Salt Pitt High Gym"));
            //GameObject.Find("ScholaGrandisButton").GetComponent<Button>().onClick.AddListener(() => Restart("Schola Grandis Gym"));
            //GameObject.Find("MightMainButton").GetComponent<Button>().onClick.AddListener(() => Restart("MightMain Academy Gym"));
            GameObject.Find("MapButton").GetComponent<Button>().onClick.AddListener(() => Restart("MapScreen"));
            GameObject.Find("DialogueMenuButton").GetComponent<Button>().onClick.AddListener(() => Restart("DialogueMenu"));
            GameObject.Find("Difficulty").GetComponent<Button>().onClick.AddListener(() => GameObject.Find("GameManager").GetComponent<GameManager>().swapDifficulties());
            print("Buttons Found");

        } else if (SceneManager.GetActiveScene().name == "MapScreen") {
            GameObject.Find("Yamato").GetComponent<Button>().onClick.AddListener(() => Restart("Yamato Gym"));
            GameObject.Find("MainMenu").GetComponent<Button>().onClick.AddListener(() => Restart("MainMenu"));
            GameObject.Find("OpenOcean").GetComponent<Button>().onClick.AddListener(() => Restart("OpenOcean"));
            GameObject.Find("MainMenu").GetComponent<Button>().onClick.AddListener(() => Restart("MainMenu"));
            //MOST OTHER BUTTONS ARE IN THEIR OWN SCRIPT CALLED MapButtonOptions.cs

        } else if (SceneManager.GetActiveScene().name == "DialogueMenu") {
            GameObject.Find("MainMenu").GetComponent<Button>().onClick.AddListener(() => Restart("MainMenu"));
            GameObject.Find("Prologue").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Prologue"));
            GameObject.Find("A New Student").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("A New Student"));
            GameObject.Find("What Punks").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("What Punks"));
            GameObject.Find("Tutorial").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Tutorial"));
            GameObject.Find("Punk Defeat").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Punk Defeat"));
            GameObject.Find("Three Outstanding Girls").GetComponent<Button>().onClick.AddListener(() => Restart("Three Outstanding Girls"));
            GameObject.Find("Magical Preparation").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Magical Preparation"));
            GameObject.Find("Magical Match").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Magical Match"));
            GameObject.Find("Magical Defeat").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Magical Defeat"));
            GameObject.Find("Punk Ambush").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Punk Ambush"));
            GameObject.Find("Fight Against the Military").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Fight Against the Military"));
            GameObject.Find("Kuro's Trump Card").GetComponent<Button>().onClick.AddListener(() => Restart("Kuro's Trump Card"));
            GameObject.Find("Military Surrender").GetComponent<Button>().onClick.AddListener(() => Game.loadAnyScene("Military Surrender"));

        } else if(SceneManager.GetActiveScene().name == "OptionsMenu") {
            GameObject.Find("BackgroundVolume-").GetComponent<Button>().onClick.AddListener(() => Audio.DecreaseVolume(0));
            GameObject.Find("BackgroundVolume+").GetComponent<Button>().onClick.AddListener(() => Audio.IncreaseVolume(0));
            GameObject.Find("SFXVolume-").GetComponent<Button>().onClick.AddListener(() => Audio.DecreaseVolume(2));
            GameObject.Find("SFXVolume+").GetComponent<Button>().onClick.AddListener(() => Audio.IncreaseVolume(2));
        } else {

            print("QuitGame.cs Warning: QuitGame: No recognized scene found for OnSceneLoaded, this means buttons won't work when you return to this scene from elsewhere");
        }
    }
}
