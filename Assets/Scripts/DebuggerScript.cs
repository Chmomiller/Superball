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
		SaveManager SM = GameObject.Find ("GameManager").GetComponent<SaveManager> ();
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

        gameObject.SetActive(false);
	}
}
