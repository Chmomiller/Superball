using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlUpTxt : MonoBehaviour {

	public SaveManager saveManager;
	public Character character;
	public string characterName;
	public int newExpTotal = 0;
	public Text characterInfo;
	public Text characterChanges;
	public int currExp = 0;
	public int newExp = 0;
	public bool particleEffectDone = true;
	public RectTransform greenBar;
	public int ogStam;
	public int ogDam;
	public int ogBalls;

	// Use this for initialization
	void Start () {
		//characterInfo = gameObject.GetComponent<Text> ();
		//greenBar.Translate(-50f, 0f, 0f);
		//saveManager = (SaveManager) GameObject.Find ("SaveManager");
		greenBar.sizeDelta = new Vector2 (0, 0);
		if(characterName.Equals("Shiro")) {
			character = saveManager.shiro;
		} else if(characterName.Equals("Clemence")) {
			character = saveManager.clemence;
		} else if(characterName.Equals("Theodore")) {
			character = saveManager.theodore;
		}
		ogStam = character.maxStamina;
		ogDam = character.Damage;
		ogBalls = character.maxBalls;
	}
	
	// Update is called once per frame
	void Update () {
		characterInfo.text = character.name
			+ "\n Level: " + character.Level
			+ "\n Exp: " + currExp%100 + " / 100";
		if (currExp < newExp) {
			if ((currExp % 100) == 0) {
				particleEffectDone = false;
				//particle effect
				newStats();
				if (particleEffectDone == true) {
					currExp++;
					greenBar.Translate (-50f, 0f, 0f);
				}
			} else {
				currExp ++;
				greenBar.sizeDelta = new Vector2(currExp%101 , 20);
				greenBar.Translate (.5f, 0f, 0f);
			}
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			print ("new exp total");
			setNewExp (540);
			greenBar.Translate(-50f, 0f, 0f);
			currExp++;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			character.LevelUp (1);
		}

	}

	public void setNewExp(int newValue){
		newExp = newValue;
	}

	public void newStats(){
		character.LevelUp (1);
		int newStam = character.maxStamina;
		int newDam = character.Damage;
		int newBalls = character.maxBalls;
		characterChanges.text =
			"Stamina:\n" +
			ogStam + "  ->  " + "<color=#24e50a>" + newStam + "</color>" + "\n"
			+ "Damage:\n"
			+ ogDam + "  ->  " + "<color=#24e50a>" + newDam + "</color>" + "\n"
			+ "Balls Held:\n"
			+ ogBalls + "  ->  " + "<color=#24e50a>" + newBalls + "</color>" + "\n";
		particleEffectDone = true;
	}
}
