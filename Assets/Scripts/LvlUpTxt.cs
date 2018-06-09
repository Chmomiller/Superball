using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlUpTxt : MonoBehaviour {

	public GameManager gameManager;
	public SaveManager saveManager;
	public Character character;
	public string characterName;
	public int newExpTotal = 0;
	public Text characterInfo;
	public Text characterChanges;
	public int currExp = 0;
	public int newExp = 1;
	public RectTransform greenBar;
	public int ogStam;
	public int ogDam;
	public int ogBalls;
	public RectTransform backdropBar;
	bool backdropBarResized = false;
	public bool newXpGranted = false;

	// Use this for initialization
	void Start () {
		gameManager = FindObjectOfType<GameManager> ();
		saveManager = gameManager.GetComponent<SaveManager>();
		switch(characterName)

		{
			case("Shiro"):
				character = saveManager.shiro;
			break;
			case("Theodore"):
				character = saveManager.theodore;
			break;
			case("Clemence"):
				character = saveManager.clemence;
			break;
		}
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
		if ((Time.time > .9f) && !newXpGranted) {
			newExp = 301;
			newXpGranted = true;
			greenBar.Translate(-50f, 0f, 0f);
			currExp++;
		}
		characterInfo.text = character.name
			+ "\n Level: " + character.Level
			+ "\n Exp: " + currExp%100 + " / 100";
		if (currExp < newExp) {
			if ((currExp % 100) == 0) {
				//particle effect
				newStats();
				currExp++;
				greenBar.Translate (-50f, 0f, 0f);
				greenBar.sizeDelta = new Vector2 (0f, 20);
			} else {
				currExp ++;
				greenBar.sizeDelta = new Vector2(currExp%101 , 20);
				greenBar.Translate (.5f, 0f, 0f);
			}
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			print ("new exp total");
			newExp = 540;
			greenBar.Translate(-50f, 0f, 0f);
			currExp++;
		}

	}
		

	public void newStats(){
		character.LevelUp (1);
		if (!backdropBarResized) {
			backdropBar.Translate (0f, -50f, 0f);
			backdropBar.sizeDelta = new Vector2 (100f, 148);
			backdropBarResized = true;
		}
		int newStam = character.maxStamina;
		int newDam = character.Damage;
		int newBalls = character.maxBalls;
		characterChanges.text =
			"Stamina:\n" +
			ogStam + "  ->  " + "<color=#25a913>" + newStam + "</color>" + "\n"
			+ "Damage:\n"
			+ ogDam + "  ->  " + "<color=#25a913>" + newDam + "</color>" + "\n"
			+ "Balls Held:\n"
			+ ogBalls + "  ->  " + "<color=#25a913>" + newBalls + "</color>" + "\n";
	}
}
