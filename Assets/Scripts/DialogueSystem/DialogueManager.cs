using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using TMPro;

public class DialogueManager : MonoBehaviour {

	//dialogue box stuff
	public float fadeDuration = 1.0f;
	public Image dialogueBox;

	bool isSpeaking;
	bool fading;
	float fadeTime;
	bool initialFade;

	//black beginning
	bool blackStart = false;
	int blackFade = 0;
	float bColor =0.0f;

	//transitions

	public GameObject bg;
	public Image screen;
	bool transition= false;
	bool changeBG = false;
	bool fadeIn = false;

	//Speaking characters

	public string[] onScreenChars = {"", "", "", "", "", "" };
	List<string> sceneCharacters;
	string[] group1;
	string[] group2;

	public Image[] charSprites = new Image[6];

	bool newLine = true;
	string prevSpeaker = "";

	//lines
	public Dialogue textLines;
	public string sceneTitle = "test scene";
	string[,] insertText;
	int lineNum = 0;
	int lineI = 0;
	string currentLine = "";
	public float textSpeed = 0.05f;
	float textTime = 0.0f;

	//ending a scene
	public bool combatDialogue = false;
	public string nextScene;

	// Use this for initialization
	void Start () {
		fadeTime = 0;
		fading = true;
		dialogueBox.color = new Color (0.8f,0.8f,0.8f,0.0f);

		isSpeaking = true;
		sceneCharacters = new List<string>();
		textLines = new Dialogue ();
		insertText = textLines.allDialogue[sceneTitle];

		startConvo (sceneTitle);


	}
	
	// Update is called once per frame
	void Update () {

		//fade in
		if (fading && fadeTime < fadeDuration) {
			fadeTime += Time.deltaTime;
			if (initialFade) {
				dialogueBox.color = new Color (1.0f, 1.0f, 1.0f, dialogueBox.color.a + Time.deltaTime / fadeDuration);
			} else if (transition) {
				//bg.GetComponent<SpriteRenderer> ().color = new Color (bg.GetComponent<SpriteRenderer> ().color.r - (Time.deltaTime / fadeDuration)*4,bg.GetComponent<SpriteRenderer> ().color.g - (Time.deltaTime / fadeDuration)*4, bg.GetComponent<SpriteRenderer> ().color.b - (Time.deltaTime / fadeDuration)*4,1.0f);
				screen.color = new Color (0.0f, 0.0f, 0.0f, screen.color.a + Time.deltaTime / fadeDuration);
			} else if (fadeIn) {
				screen.color = new Color (0.0f, 0.0f, 0.0f, screen.color.a - Time.deltaTime / fadeDuration);

			}

		} else {
			fading = false;
			if (fadeIn) {
				fadeIn = false;
				changeBG = true;
				fading = false;
				nextLine ();


			}


			if (transition) {
				bg.GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("Backgrounds/" + insertText [lineNum, 9]) as Sprite;
				bg.GetComponent<FullScreenBG> ().ResetScale ();
				//set next characters
				for(int c=0; c < 6; ++c) {
					if (insertText [lineNum, c] != "") {
						charSprites [c].sprite = Resources.Load<Sprite> ("Characters/" + insertText [lineNum, c]) as Sprite;
						charSprites [c].preserveAspect = true;
						if (c > 2) {

							charSprites [c].GetComponent<RectTransform> ().localScale = new Vector3 (
								charSprites [c].GetComponent<RectTransform> ().localScale.x * -1,
								charSprites [c].GetComponent<RectTransform> ().localScale.y,
								charSprites [c].GetComponent<RectTransform> ().localScale.z


							);
						}
					} else {
						charSprites [c].color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
					}
				}
				//clear text
				dialogueBox.GetComponentInChildren<TextMeshProUGUI> ().SetText("");

				fadeIn = true;
				fading = true;
				fadeTime = 0;
			}
			initialFade = false;
			transition = false;
		}


		if (Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)){
			nextLine ();
		}

		if (!fading) {
			
			if (newLine && lineNum < insertText.GetLength(0)) {
				
				
	


				//set characters on screen
				string[] speakerSet = insertText [lineNum, 7].Split (' ');

				for(int ch=0; ch < 6; ++ch) {
					if (insertText [lineNum, ch] != "") {
						charSprites [ch].sprite = Resources.Load<Sprite> ("Characters/" + insertText [lineNum, ch]) as Sprite;
						charSprites [ch].preserveAspect = true;

						if (ch > 2) {
							charSprites [ch].GetComponent<RectTransform> ().localScale = new Vector3 (
								charSprites [ch].GetComponent<RectTransform> ().localScale.x * -1,
								charSprites [ch].GetComponent<RectTransform> ().localScale.y,
								charSprites [ch].GetComponent<RectTransform> ().localScale.z


							);

						}

						if (speakerSet.Contains (insertText [lineNum, ch])) {
							charSprites [ch].color = new Color (1.0f, 1.0f, 1.0f, 1.0f);
						} else {
							//darken the character that is not speaking

							charSprites [ch].color = new Color (0.8f, 0.8f, 0.8f, 1.0f);

						}

					} else {
						charSprites [ch].color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
					}
				}




				newLine = false;


			}
				
			//next line of dialogue slowly coming out
			//display dialogue
			if (lineNum < insertText.GetLength(0) && isSpeaking) {
			

				textTime += Time.deltaTime;
				if (textTime > textSpeed && lineI < insertText [lineNum, 6].Length) {
					currentLine += insertText [lineNum, 6] [lineI++];
					dialogueBox.GetComponentInChildren<TextMeshProUGUI> ().SetText (insertText [lineNum, 7] + "\n" +currentLine);
					textTime = 0.0f;
				} else if (lineI >= insertText [lineNum, 6].Length) {
					isSpeaking = false;

				}

			} else if (lineNum < insertText.GetLength(0)) {
				currentLine = "";
				lineI = 0;
				dialogueBox.GetComponentInChildren<TextMeshProUGUI> ().SetText (insertText [lineNum, 7] + "\n" + insertText [lineNum, 6]);

			
			} else {
				endConvo ();
			}
		}
		
	}

	public void nextLine(){



		if (isSpeaking && !fading && !transition) {
			isSpeaking = false;
		} else if (lineNum < insertText.GetLength(0) && !fading && !transition){
			
			currentLine = "";
			lineI = 0;
			prevSpeaker = insertText [lineNum, 7];
			lineNum++;
			newLine = true;
			isSpeaking = true;
			//special case transition
			if (lineNum < insertText.GetLength(0)) {
				if (insertText [lineNum, 8] == "transition") {
					transition = true;
					fading = true;
					fadeTime = 0;
				}
			}


		}
		//special cases
		if (bColor < blackFade && isSpeaking && !fading) {
			bColor += 1.0f / blackFade;
			bg.GetComponent<SpriteRenderer> ().color = new Color (bColor,bColor,bColor,1.0f);
		}



		if (changeBG) {
			//bg.GetComponent<SpriteRenderer> ().color = new Color (1.0f,1.0f,1.0f,1.0f);
			screen.color = new Color (0.0f,0.0f,0.0f,0.0f);
			changeBG = false;



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
		if (combatDialogue) {
			dialogueBox.color = new Color (0.8f, 0.8f, 0.8f, 0.0f);
			dialogueBox.gameObject.SetActive (false);
			foreach (Image cha in charSprites) {
				cha.color = new Color (1f, 1f, 1f, 0f);
				cha.gameObject.SetActive (false);
			}
		} else {
			//insert scene change here
			UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
		}

	}

	public void startConvo (string newSceneName){
		sceneTitle = newSceneName;
		fadeTime = 0;
		fading = true;
		initialFade = true;
		dialogueBox.gameObject.SetActive (true);

		dialogueBox.color = new Color (0.8f,0.8f,0.8f,0.0f);

		foreach (Image cha in charSprites) {
			cha.gameObject.SetActive (true);
		}


		isSpeaking = true;

		insertText = textLines.allDialogue[sceneTitle];

		if (insertText [0, 8] == "black") {
			blackStart = true;
			blackFade = int.Parse (insertText [0, 9]);
			bg.GetComponent<SpriteRenderer> ().color = new Color (0.0f,0.0f,0.0f,1.0f);
				
		}


	
		string[] speakerSet = insertText [0, 7].Split (' ');

		//set the character sprites
		for(int c=0; c < 6; ++c) {
			if (insertText [0, c] != "") {
				charSprites [c].sprite = Resources.Load<Sprite> ("Characters/" + insertText [0, c]) as Sprite;
				charSprites [c].preserveAspect = true;
				if (c > 2) {
					
					charSprites [c].GetComponent<RectTransform> ().localScale = new Vector3 (
						charSprites [c].GetComponent<RectTransform> ().localScale.x * -1,
						charSprites [c].GetComponent<RectTransform> ().localScale.y,
						charSprites [c].GetComponent<RectTransform> ().localScale.z


					);
				}
			} else {
				charSprites [c].color = new Color (0.0f, 0.0f, 0.0f, 0.0f);
			}
		}
			
	}
}
