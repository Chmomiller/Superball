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
	public Text textOverlayT;

	public string[] dialogue = {"The rules of dodgeball are a bit hazy for me, think you could give me a run-down?",
								"So you don’t know how to play <b>dodgeball</b>?",
								"You got me there.",
								"Then listen well! First, when it is a player’s turn, they can do three actions.",
								"One: throw a ball at an enemy!",
								"Two: catch when an enemy throws at them!",
								"And three: use special skills for great effect, but with costs, of course!",
								"The three actions can be chosen here.",
								"To check out how many balls a player has, look at the number on the player’s portrait.",
								"It is now Shiro’s turn. Click the Throw button and aim at Trevor.",
								"Now, it is Clemence’s turn. Press the Catch button.",
								"The box above a character indicates what type of action that character will do.",
								"Shiro and Trevor chose to attack, so they have red icons above them. ",
								"Clemence, Frank, and Greg chose to defend, and so their icons are blue instead.",
								"Now, it is Theodore’s turn. Try using skill 1 against Trevor. Once you do that, look at his portrait carefully.",
								"Notice that the number of balls Theodore holds has changed because he used a skill that costs balls.",
								"Okay, I think I got it now. But who gets to decide who goes first?",
								"Ah, see, here’s the thing. Each player on the field has a certain amount of stamina.",
								"The player with the highest stamina goes first. Then the player with the second-highest stamina goes next, and so on.",
								"Once all the players have decided their actions, we leave the planning phase and enter the execution phase.",
								"That <i>kind of</i> makes sense to me...",
								"Whether it makes sense or not, that’s the rule.",
								"That’s why you went first on the first turn.",
								"All right, I think I got that. But what’s the goal of the game?",
								"The goal is to knock out all the enemies.",
								"If a player’s stamina is at 25% or lower, they can get knocked out of the game, even if their stamina hasn’t reached 0 yet.",
								"Each player’s health is located under their portrait.",
								"Anything else I should know?",
								"Ah, yes, between rounds players gather balls automatically. That always ensures that you can at least throw at an enemy.",
								"I see.",
								"And here’s a tip for you if you want to win. Keep track of your enemies' actions. ",
								"knowing what the enemies’ actions are lets you see what effects they’ll have on you.",
								"Actions are automatically listed on the white box right here. ",
								"To keep track of what actions have been done, look at the Battle Log right here.",
								"Only one thing left to cover. Each player is one of three classes: <b><color=red>thrower</color>, <color=blue>catcher</color>, or <color=yellow>supporter</color></b>.",
								"Oh yeah! If I remember correctly I’m a <color=yellow>supporter</color>!",
								"Oh, really? That’s good! I’m a <color=red>thrower</color>, which means that I excel at dealing damage to enemies.",
								"Clemence is a <color=blue>catcher</color>, which means that he is good at catching for himself and teammates.",
								"And you’re a <color=yellow>supporter</color>, which means that you can help your teammates by buffing, healing, etc.",
								"Now is that all?",
								"I think so Let’s play!"};
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
		textOverlayT = gameObject.GetComponentInChildren<Text>();
        //textOverlayT.SetActive(false);
		textOverlay = gameObject;
        //textOverlay.SetActive(false);

		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager>();
		//CM.enabled = false;
}

    // Update is called once per frame
    void Update() {
		if(CM.currentPhase == CombatManager.PHASE.ACTION && control)
		{
			control = false;
			StartCoroutine (CombatManagerControl(.1f));
		}
		if(count == dialogue.Length)
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Scenes/MapScreen");
		}
		if (count != 9 && count != 10 && count != 14 && 
			Input.GetMouseButtonDown(0) == true)
		{
			count++;
			display = true;
		}
		if(count == 9 && 
		   CM.combatQueue[CM.currentCharacter].Name == "Shiro" && 
		   CM.combatQueue[CM.currentCharacter].action == "Throw" && 
		   CM.combatQueue[CM.currentCharacter].Target[0].Name == "Trevor")
		{
			count++;
			display = true;
			control = true;
			StartCoroutine (CombatManagerControl(.1f));
		}
		if(count == 10 && 
			CM.combatQueue[CM.currentCharacter].Name == "Clemence" && 
			CM.combatQueue[CM.currentCharacter].action == "Catch" && 
			CM.currentPhase == CombatManager.PHASE.CONFLICT)
		{
			count++;
			display = true;
			control = true;
			StartCoroutine (CombatManagerControl(.1f));
		}
		if(count == 14 && 
			CM.combatQueue[CM.currentCharacter].Name == "Theodore" && 
			CM.combatQueue[CM.currentCharacter].action == "Skill1" && 
			CM.combatQueue[CM.currentCharacter].Target[0].Name == "Trevor")
		{
			count++;
			display = true;
			control = true;
			StartCoroutine (CombatManagerControl(.1f));
		}
		textOverlay.SetActive(true);
		textOverlayT.enabled = true;
		if (display) 
		{
			textOverlayT.text = dialogue[count];
			display = false;
		}
		/*
		Dialog for tutorial scene. Note: if line is said by “Narrator”, it means that no one is saying it, and so the text box should not be pointing to any character in particular. Contextually, the Narrator’s box should be placed near the features of the UI that the line is explaining.

0. Shiro: The rules of dodgeball are a bit hazy for me, think you could give me a run-down?
1. Theodore: So you don’t know how to play <b>dodgeball</b>?
2. Shiro: You got me there.
3. Theodore: Then listen well! First, when it is a player’s turn, they can do three actions. 
4. One: throw a ball at an enemy! 
5. Two: catch when an enemy throws at them! 
6. And three: use special skills for great effect, but with costs, of course!
7. Narrator: The three actions can be chosen here. 
8. To check out how many balls a player has, look at the number on the player’s portrait. 
9. It is now Shiro’s turn. Press the Throw button and aim at Trevor.

Player has Shiro choose Trevor when doing Throw option.

10. Narrator: Now, it is Clemence’s turn. Press the Catch button.

Player chooses the Catch option for Clemence. Frank and Greg then choose to catch, and Trevor chooses to attack.

11. Narrator: The box next to a character indicates what type of action that character will do. 
12. Shiro and Trevor chose to attack, and so red boxes next to them have appeared. 
13. Clemence, Frank, and Greg chose to defend, and so their boxes are blue instead. 
//////////////////++++++++++++++++++++++++++++++++?????????????????
13. Now, it is Theodore’s turn. Try using skill 1 against Trevor. Once you do that, look at his portrait carefully.

Player chooses the Skill option for Theodore, and uses the Bishop skill at Trevor. Turn plays out.

14. Narrator: Notice that the number of balls Theodore holds has changed, because he has used a skill that costs balls.
15. Shiro: Okay, I think I got it now. But who gets to decide who goes first?
16. Theodore: Ah, see, here’s the thing. Each player on the field has a certain amount of stamina. The player with the highest stamina goes first. Then the player with the second-highest stamina goes next, and so on. 
17. Once all the players have decided their actions, we leave the planning phase and enter the execution phase.
18. Shiro: That <i>kind of</i> makes sense to me...
19. Theodore: Whether it makes sense or not, that’s the rule. That’s why you went first on the first turn.
20. Shiro: All right, I think I got that. But what’s the point of the game?
21. Theodore: The goal is to knock out all the enemies. 
22. If a player’s stamina is at 25% or lower, they can get knocked out of the game, even if their stamina hasn’t reached 0 yet.
23. Narrator: Each player’s health is located under their portrait.
24. Shiro: Anything else I should know?
25. Theodore: Ah, yes, between rounds players gather balls automatically. That always ensures that you can at least throw at an enemy. 
26. Shiro: I see.
27. Theodore: And here’s one key tip for you if you want to win. Keep track of what goes on. For example, knowing what the enemies’ actions are lets you see what effects they’ll have on you.
28. Narrator: Actions are automatically listed on the white box right here. To keep track of what actions have been done, look at the Battle Log right here.
29. Theodore: Only one thing left to cover. Each player can be of one of three classes: thrower, catcher, and supporter. 
30. Shiro: Oh yeah! If I remember correctly I’m a supporter!
31. Theodore: Oh, really? That’s good! I’m a thrower, which means that I excel at dealing damage at enemies. 
32. Clemence is a catcher, which means that he is good at catching for himself and teammates. 
33. And you’re a supporter, which means that you can help your teammates by buffing, healing, and other useful skills.
34. Shiro: Now is that all?
35. Theodore: I think so! Let’s play!
		*/        
    }

	void NextDialogue(int whatToSay, Vector3 newPosition) 
	{
		textOverlay.SetActive (true);
		textOverlayT.enabled = true;
		textOverlay.transform.position = newPosition;
		textOverlayT.GetComponent<Text> ().text = dialogue[whatToSay];
	}

	void NextDialogue(int whatToSay, Vector3 offSet, Transform origin) 
	{
		textOverlay.SetActive (true);
		textOverlayT.enabled = true;
		textOverlay.transform.position = origin.transform.position + offSet;
		textOverlayT.GetComponent<Text> ().text = dialogue[whatToSay];
	}

	void ClearDialogue()
	{
		textOverlay.SetActive (false);
		textOverlayT.enabled = false;
	}

	IEnumerator CombatManagerControl(float delay)
	{
		yield return new WaitForSeconds (delay);
		CM.enabled = !CM.enabled;
	}

	IEnumerator CorrectTarget(Character mistake, int dialogueLine)
	{
		textOverlayT.GetComponent<Text> ().text = dialogue[dialogueLine];
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
