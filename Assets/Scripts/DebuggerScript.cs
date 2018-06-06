using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebuggerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UnlockAll()
	{
		SaveManager SM = GameObject.Find ("GameManager").GetComponent<GameManager> ().Save;
		SM.SaltPittDialogue = true;
		SM.SaltPittBattle = true;
		SM.SaltPittBattleHard = true;

		SM.ScholaGrandisDialog = true;
		SM.ScholaGrandisBattle = true;
		SM.ScholaGrandisBattleHard = true;

		SM.MightMainDialog = true;
		SM.MightMainBattle = true;
		SM.MightMainBattleHard = true;

		SM.yamatoDialog = true;
		SM.yamatoBattle = true;
		SM.yamatoBattleHard = true;

		SM.teamSevenDialog = true;
		SM.teamSevenBattle = true;

		SM.beatSuperballRush = true;
		SM.unlockAll = true;
	}

	public void ResetProgress()
	{
		SaveManager SM = GameObject.Find ("GameManager").GetComponent<GameManager> ().Save;
		SM.SaltPittDialogue = false;
		SM.SaltPittBattle = false;
		SM.SaltPittBattleHard = false;

		SM.ScholaGrandisDialog = false;
		SM.ScholaGrandisBattle = false;
		SM.ScholaGrandisBattleHard = false;

		SM.MightMainDialog = false;
		SM.MightMainBattle = false;
		SM.MightMainBattleHard = false;

		SM.yamatoDialog = false;
		SM.yamatoBattle = false;
		SM.yamatoBattleHard = false;

		SM.teamSevenDialog = false;
		SM.teamSevenBattle = false;

		SM.beatSuperballRush = false;
		SM.unlockAll = false;

		SM.shiro.ResetChar ();
		SM.theodore.ResetChar ();
		SM.clemence.ResetChar ();
	}
}
