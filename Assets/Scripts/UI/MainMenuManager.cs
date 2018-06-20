using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
	
	public SaveManager save;
	public GameObject newGame;
	public GameObject continueGame;

	// Use this for initialization
	void Start () 
	{
		save = GameObject.FindObjectOfType<SaveManager> ();
		if(save.SaltPittDialogue)
		{
			continueGame.SetActive (true);
		}
	}

	public void MainMenuReset()
	{
		if (save.SaltPittDialogue) 
		{
			newGame.SetActive (true);
		} 
		else 
		{
			SceneManager.LoadScene ("Dialogue Scenes/Prologue");
		}
	}

	public void NewGame()
	{
		save.SaltPittDialogue = false;
		save.SaltPittBattle = false;
		save.SaltPittBattleHard = false;

		save.ScholaGrandisDialog = false;
		save.ScholaGrandisBattle = false;
		save.ScholaGrandisBattleHard = false;

		save.MightMainDialog = false;
		save.MightMainBattle = false;
		save.MightMainBattleHard = false;

		save.yamatoDialog = false;
		save.yamatoBattle = false;
		save.yamatoBattleHard = false;

		save.teamSevenDialog = false;
		save.teamSevenBattle = false;

		save.beatSuperballRush = false;
		save.unlockAll = false;

		save.shiro.ResetChar ();
		save.theodore.ResetChar ();
		save.clemence.ResetChar ();

		SceneManager.LoadScene ("Dialogue Scenes/Prologue");
	}

	public void CancelNewGame()
	{
		newGame.SetActive (false);
	}

	public void Continue()
	{
		SceneManager.LoadScene ("Scenes/MapScreen");
	}
}
