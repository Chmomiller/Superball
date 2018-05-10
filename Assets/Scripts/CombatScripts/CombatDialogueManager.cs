using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatDialogueManager: MonoBehaviour {

    public int count = 0;
	public CombatManager CM;
    public GameObject ActionManager;
    public GameObject skill1Button;
    public GameObject skill2Button;
    public GameObject skill3Button;
    public GameObject ActionPanel;
    public GameObject PlayerUI;
    public GameObject EnemyUI;
    public GameObject PhasePanel;
    public GameObject CombatPanel;
    public GameObject Character0;
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;
    public GameObject Character5;
    public GameObject throwButton;
    public GameObject catchButton;
    public GameObject skillButton;
    public GameObject textOverlay;
    public GameObject textOverlayT;

	public bool control;
	public bool display;


	// Use this for initialization
	void Start () {
		control = true;
		display = true;

        throwButton = GameObject.Find("ThrowButton");
        //throwButton.SetActive(false);
        catchButton = GameObject.Find("CatchButton");
        //catchButton.SetActive(false);
        skillButton = GameObject.Find("SkillButton");
        //skillButton.SetActive(false);
        skill1Button = GameObject.Find("Skill1Button");
        //skill1Button.SetActive(false);
        skill2Button = GameObject.Find("Skill2Button");
        //skill2Button.SetActive(false);
        skill3Button = GameObject.Find("Skill3Button");
        //skill3Button.SetActive(false);
        ActionPanel = GameObject.Find("ActionPanel");
        //ActionPanel.SetActive(false);
        ActionManager = GameObject.Find("ActionManager");
        //ActionManager.SetActive(false);
        PlayerUI = GameObject.Find("PlayerUI");
        //PlayerUI.SetActive(false);
        EnemyUI = GameObject.Find("EnemyUI");
        //EnemyUI.SetActive(false);
        PhasePanel = GameObject.Find("PhasePanel");
        //PhasePanel.SetActive(false);
        CombatPanel = GameObject.Find("CombatPanel");
        //CombatPanel.SetActive(false);
        Character0 = GameObject.Find("Character0");
        //Character0.SetActive(false);
        Character1 = GameObject.Find("Character1");
        //Character1.SetActive(false);
        Character2 = GameObject.Find("Character2");
        //Character2.SetActive(false);
        Character3 = GameObject.Find("Character3");
        //Character3.SetActive(false);
        Character4 = GameObject.Find("Character4");
        //Character4.SetActive(false);
        Character5 = GameObject.Find("Character5");
        //Character5.SetActive(false);
        textOverlayT = GameObject.Find("textOverlayT");
        //textOverlayT.SetActive(false);
        textOverlay = GameObject.Find("textOverlay");
        //textOverlay.SetActive(false);

		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager>();
}

    // Update is called once per frame
    void Update() {
		if(control)
		{
			control = false;
			StartCoroutine (CombatManagerControl(.1f));
		}
		// Use this code to control dialogue flow via mouse clicks
		// adding count != N to the condition adds a mask for that line of dialogue
		if (count != 1 && count != 2 && Input.GetMouseButtonDown(0) == true)
		{
			count++;
			display = true;
		}
		if (count == 1 && Character0.GetComponent<Character> ().action != "None") 
		{
			count = 2;
			display = true;
		}
		if (count == 2 && Character0.GetComponent<Character> ().action != "None" && Character0.GetComponent<Character> ().Target [0] != Character0.GetComponent<Character> ()) 
		{
			count = 3;
			display = true;
		}
		/*
		if (count == 1) 
		{
			if (Character0.GetComponent<Character> ().action == "Throw") 
			{
				count = 2;
			} 
			else if(Character0.GetComponent<Character> ().action != "None") 
			{
				textOverlayT.GetComponent<Text> ().text = "Woops, wrong action. Try clicking \"Throw\".";
				StartCoroutine (CorrectTarget(Character0.GetComponent<Character>(), "Woops, wrong action. Try clicking \"Throw\"."));
			}
		}
		if (count == 2 && Character0.GetComponent<Character>().Target[0] != Character0.GetComponent<Character>()) count = 3;
		*/
		// Use this code to control flow via a specific character's action and/or target
		// N = the count where you want to check for this condition
		// ACTION = the action name you wnat to chack for(must be a valid )
		//if (count == N && CharacterM.GetComponent<Character>().action == "ACTION" && CharacterM.GetComponent<Character>().Target[0] != CharacterM.GetComponent<Character>()) count = N+1;

        if (count == 0) {
            textOverlay.SetActive(true);
            textOverlayT.SetActive(true);
			if (display) 
			{
				textOverlayT.GetComponent<Text> ().text = "Click the mouse!";
				display = false;
			}
        } else if (count == 1) {
            Character0.SetActive(true);
            textOverlay.transform.position = new Vector3(-3.5F, 3, 0);
			if (display) 
			{
				textOverlayT.GetComponent<Text>().text = "Select Throw";
				display = false;
			}
            //point out shiro
        } else if (count == 2) {
            textOverlay.transform.position = new Vector3(-4.5F, 3, 0);
            Character1.SetActive(true);
            Character2.SetActive(true);
			if (display) 
			{
				if(Character0.GetComponent<Character> ().action != "Throw")
				{
				textOverlayT.GetComponent<Text>().text = "Choose an Enemy"; 
				display = false;
				}
				else
				{
					
				}
			} 
            //introuduce Clemence & Theodore
        } else if (count == 3) {
			StartCoroutine (CombatManagerControl(0f));
			control = true;
            textOverlay.transform.position = new Vector3(0, 0, 0);
			if (display) 
			{
				textOverlayT.GetComponent<Text>().text = "Before we introduce you to the Punks, I would like to show you some important Superball simualtion elements";
				display = false;
			} 
            //more flavor text
        } else if (count == 4) {
            textOverlay.transform.position = new Vector3(0, 4, 0);
            PhasePanel.SetActive(true);
			if (display) 
			{
				textOverlayT.GetComponent<Text>().text = "Here is the phase panel. It gives you information on what combat phase we are in";
				display = false;
			} 
            //point out phase panel
        } else if (count == 5) {
            textOverlay.transform.position = new Vector3(0, 1, 0);
            CombatPanel.SetActive(true);
			{
				textOverlayT.GetComponent<Text>().text = "This is the combat panel. We will see important battle information here";
				display = false;
			} 
            //point out battle text
        } else if (count == 6) {
			CombatPanel.SetActive(true);
			{
				textOverlayT.GetComponent<Text>().text = "Now it is time to see your foes";
				display = false;
			} 
            //introduce enemies
        } else if (count == 7) {
            Character3.SetActive(true);
            textOverlay.transform.position = new Vector3(3, 3, 0);
			{
				textOverlayT.GetComponent<Text>().text = "Tetsou Trevor";
				display = false;
			} 
            //introduce trevor
        } else if (count == 8) {
            textOverlay.transform.position = new Vector3(4, 3, 0);
            Character4.SetActive(true);
			{
				textOverlayT.GetComponent<Text>().text = "Futoi Frank";
				display = false;
			} 
            //introduce trevor
        } else if (count == 9) {
            textOverlay.transform.position = new Vector3(5, 3, 0);
            Character5.SetActive(true);
			{
				textOverlayT.GetComponent<Text>().text = "Gomi Greg";
				display = false;
			} 
            //introduce trevor
        } else if (count == 10) {
            textOverlay.transform.position = new Vector3(0, 5, 0);
			{
				textOverlayT.GetComponent<Text>().text = "They arent the friendliest bunch but I am sure you can defeat them";
				display = false;
			} 
        } else if (count == 11) {
            textOverlay.transform.position = new Vector3(0, -1, 0);
            PlayerUI.SetActive(true);
            EnemyUI.SetActive(true);
			{
				textOverlayT.GetComponent<Text>().text = "here to help is our simlator panels, one for each combatant";
				display = false;
			} 
            //point out portraits
        } else if (count == 12) {
            textOverlay.transform.position = new Vector3(0, 0, 0);
			{
				textOverlayT.GetComponent<Text>().text = "If hovered over, these portaits even give useful information such as the character's status abilities and stats";
				display = false;
			} 
            //point out portrait details
        } else if (count == 13) {
            textOverlay.transform.position = new Vector3(0, 0, 0);
            ActionManager.SetActive(true);
            throwButton.SetActive(true);
            catchButton.SetActive(true);
            skillButton.SetActive(true);
			{
				textOverlayT.GetComponent<Text>().text = "Now onto the actions you can take. These are shown in this 3 segment wheel";
				display = false;
			} 
            //point out basic actions
        } else if (count == 14) {
            throwButton.SetActive(false);
            catchButton.SetActive(false);
            skillButton.SetActive(false);
            skill1Button.SetActive(true);
            skill2Button.SetActive(true);
            skill3Button.SetActive(true);
			{
				textOverlayT.GetComponent<Text>().text = "There are even skills unique to each player that can be accessed by clicking Skills";
				display = false;
			} 
            //point out skills examples
        } else if (count == 10) {
            throwButton.SetActive(true);
            catchButton.SetActive(true);
            skillButton.SetActive(true);
            //point out skills 2
        } else if (count == 11) {
			{
				textOverlayT.GetComponent<Text>().text = "Most moves require a target, which can be specified by clicking on either your allies or enemies";
				display = false;
			} 
            //point out example skill description
        } else if (count == 12) {
			{
				textOverlayT.GetComponent<Text>().text = "Ready to Ball?";
				display = false;
			} 
            //point out different targetting
        } else {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/MapScreen");
        }
        
    }

	void NextDialogue(Vector3 newPosition, string whatToSay)
	{
		textOverlay.SetActive (true);
		textOverlayT.SetActive (true);
		textOverlay.transform.position = newPosition;
		textOverlayT.GetComponent<Text> ().text = whatToSay;
	}

	void ClearDialogue()
	{
		textOverlay.SetActive (false);
		textOverlayT.SetActive (false);
	}

	IEnumerator CombatManagerControl(float delay)
	{
		yield return new WaitForSeconds (delay);
		CM.enabled = !CM.enabled;
	}

	IEnumerator CorrectTarget(Character mistake, string whatToSay)
	{
		textOverlayT.GetComponent<Text> ().text = whatToSay;
		mistake.Target [0] = mistake;
		CM.currentPhase = CombatManager.PHASE.TARGET;
		yield return new WaitForSeconds (.5f);
	}

	IEnumerator CorrectAction(Character mistake, string whatToSay)
	{
		textOverlayT.GetComponent<Text> ().text = whatToSay;
		CM.currentPhase = CombatManager.PHASE.ACTION;
		mistake.action = "None";
		yield return new WaitForSeconds (.5f);
	}
}
