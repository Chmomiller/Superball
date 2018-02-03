using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour {

	//dialogue box stuff
	public float fadeDuration = 1.0f;
	public Image dialogueBox;

	bool isSpeaking;
	bool fading;
	float fadeTime;

	//Speaking characters
	public string character1 = "";
	public string character2 = "";
	List<string> sceneCharacters;
	public Image char1Sprite;
	public Image char2Sprite;
	bool newLine = true;
	string prevSpeaker = "";

	Dictionary<string, Image> charSprites;

	//lines
	public Dialogue textLines;
	public string sceneTitle = "test scene";
	string[,] insertText;
	int lineNum = 0;
	int lineI = 0;
	string currentLine = "";
	public float textSpeed = 0.05f;
	float textTime = 0.0f;

	// Use this for initialization
	void Start () {
		fadeTime = 0;
		fading = true;
		dialogueBox.color = new Color (0.8f,0.8f,0.8f,0.0f);

		isSpeaking = true;
		sceneCharacters = new List<string>();
		textLines = new Dialogue ();
		insertText = textLines.allDialogue[sceneTitle];
		foreach (string c in textLines.characters[sceneTitle]) {
			sceneCharacters.Add (c);
		}

		if (insertText [0, 0] != "" ) {
			char1Sprite.sprite = Resources.Load<Sprite> (insertText [0, 0]) as Sprite;
			character1 = insertText [0, 0];
		}else{
			char1Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
			character1 = "";
		}

		if (insertText [0, 1] != ""){
			char2Sprite.sprite = Resources.Load<Sprite> (insertText [0, 1]) as Sprite;
			character2 = insertText [0, 1];
		}else{
			char2Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
			character2 = "";
		
		}


	}
	
	// Update is called once per frame
	void Update () {

		//fade in
		if (fading && fadeTime < fadeDuration) {
			fadeTime += Time.deltaTime;
			dialogueBox.color = new Color (1.0f, 1.0f, 1.0f, dialogueBox.color.a + Time.deltaTime / fadeDuration);
		} else {
			fading = false;
		}


		if (Input.GetKeyDown("space")){
			nextLine ();
		}

		if (!fading) {
			
			if (newLine && lineNum < insertText.GetLength(0)) {
				
				if (insertText [lineNum, 0] != character1 && insertText [lineNum, 0] != character2) {
					if (insertText [lineNum, 1] == character1) {
						char2Sprite.sprite = Resources.Load<Sprite> (insertText [lineNum, 0]) as Sprite;
						character2 = insertText [lineNum, 0];
					} else if (insertText [lineNum, 1] == character2) {
						char1Sprite.sprite = Resources.Load<Sprite> (insertText [lineNum, 0]) as Sprite;
						character1 = insertText [lineNum, 0];

					} else {
						char1Sprite.sprite = Resources.Load<Sprite> (insertText [lineNum, 0]) as Sprite;
						character1 = insertText [lineNum, 0];
						char2Sprite.sprite = Resources.Load<Sprite> (insertText [lineNum, 1]) as Sprite;
						character2 = insertText [lineNum, 1];
					}
				}



				//should check if one is speaking to another
				if (insertText [lineNum, 1] != character1 && insertText [lineNum, 1] != character2) {
					if (insertText [lineNum, 0] == character1) {
						char2Sprite.sprite = Resources.Load<Sprite> (insertText [lineNum, 1]) as Sprite;
						character2 = insertText [lineNum, 1];
					} else if (insertText [lineNum, 0] == character2) {
						char1Sprite.sprite = Resources.Load<Sprite> (insertText [lineNum, 1]) as Sprite;
						character1 = insertText [lineNum, 1];

					} /*else {
						char1Sprite.sprite = Resources.Load<Sprite> (insertText [lineNum, 0]) as Sprite;
						character1 = insertText [lineNum, 0];
						char2Sprite.sprite = Resources.Load<Sprite> (insertText [lineNum, 1]) as Sprite;
						character2 = insertText [lineNum, 1];
					}*/
				}

					

				//darken the character that is not speaking
				if (insertText [lineNum, 0] == character1) {
					char1Sprite.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
					char2Sprite.color = new Color (0.8f, 0.8f, 0.8f, 1.0f);
				} else if (insertText [lineNum, 0] == character2) {
					char2Sprite.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
					char1Sprite.color = new Color (0.8f, 0.8f, 0.8f, 1.0f);
				} else if (insertText [lineNum, 0] == character1 + " " + character2) {
					char2Sprite.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
					char1Sprite.color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
				} else {
					char1Sprite.color = new Color (0.8f, 0.8f, 0.8f, 1.0f);
					char2Sprite.color = new Color (0.8f, 0.8f, 0.8f, 1.0f);
				}

				//if only one or none is talking
				if (insertText [lineNum, 1] == "" || insertText [lineNum, 0] == "") {

					if (insertText [lineNum, 0] == "" && insertText [lineNum, 1] == "") {
						char1Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
						character1 = "";
						char2Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
						character2 = "";
					} else if (insertText [lineNum, 0] == character1 && insertText [lineNum, 1] == "") {
						char2Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
						character2 = "";
					} else if (insertText [lineNum, 0] == character2 && insertText [lineNum, 1] == "") {
						char1Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
						character1 = "";
					}else if (insertText [lineNum, 1] == character1) {
						char2Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
						character2 = "";
					}else if (insertText [lineNum, 1] == character2){
						char1Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
						character1 = "";
					}


					/* else {
						//just in case of exposition
						char1Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
						character1 = "";
						char2Sprite.color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
						character2 = "";
					}*/
				}



				newLine = false;


			}
				
			//next line of dialogue slowly coming out
			//display dialogue
			if (lineNum < insertText.GetLength(0) && isSpeaking) {
			

				textTime += Time.deltaTime;
				if (textTime > textSpeed && lineI < insertText [lineNum, 2].Length) {
					currentLine += insertText [lineNum, 2] [lineI++];
					dialogueBox.GetComponentInChildren<TextMeshProUGUI> ().SetText (insertText [lineNum, 0] + "\n" +currentLine);
					textTime = 0.0f;
				} else if (lineI >= insertText [lineNum, 2].Length) {
					isSpeaking = false;

				}

			} else if (lineNum < insertText.GetLength(0)) {
				currentLine = "";
				lineI = 0;
				dialogueBox.GetComponentInChildren<TextMeshProUGUI> ().SetText (insertText [lineNum, 0] + "\n" + insertText [lineNum, 2]);
			} else {
				endConvo ();
			}
		}
		
	}

	public void nextLine(){
		if (isSpeaking) {
			isSpeaking = false;
		} else if (lineNum < insertText.GetLength(0)){
			currentLine = "";
			lineI = 0;
			prevSpeaker = insertText [lineNum, 0];
			lineNum++;
			newLine = true;
			isSpeaking = true;

		}

	}

	void AnimateText(string strComplete){
		int i = 0;
		string str = "";
		while(i < strComplete.Length){
			str += strComplete[i++];
			new WaitForSeconds(0.5f);
		}
	}


	public void endConvo(){

	}
}
