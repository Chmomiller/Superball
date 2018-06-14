using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatDialogueManager: MonoBehaviour {

    public int count = 0;
	public int error = 0;

	public CombatManager CM;
    public GameObject textOverlay;
	public Text textOverlayT;

	public string[] dialogue = {"The rules of dodgeball are a bit hazy for me, think you could give me a run-down?",
								"So you don’t know how to play <b>dodgeball</b>?",
								"You got me there.",
								"Then listen well! First, when it is a player’s turn, they can do three actions.",
								"One: throw a ball at an enemy!",
								"Two: catch when an enemy throws at them!",
								"And three: use special skills for great effect, but with a cost, of course!",
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


	string[] errorDialogue = { "Looks like you chose the wrong action.\nPress the \"Back\" button.", // Error 1: Shiro didn't catch
							   "Ok...That's the wrong target too...\nLet's go back a step.",				 // Error 2: Shiro didn't target Trevor
							   "Hold up, that's the wrong action, let's try again.",				 // Error 3: Clemence didn't catch
							   "I feel like I should be using Skill 1...",							 // Error 4: Theodore didn't choose skill 1
							   "Why do I have the sudden urge to <b>NOT</> do that?"};				 // Error 5: Theodore didn't target Trevor
	public bool control;
	public bool display;


	// Use this for initialization
	void Start () {
		control = true;
		display = true;
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager>();
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

		// error conditions
		error = (CheckErrors(9, "Shiro", "Throw", "Trevor")+
				  CheckErrors (10, "Clemence", "Catch")+
				  CheckErrors (14, "Theodore", "Skill1", "Trevor"));

		if(error == 0)
		{
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
		}
		// Error if the action is wrong
		else if(error == 1)
		{
			// Error conditions
			if (count != 10 && count != 11 && count != 15 && 
				Input.GetMouseButtonDown(0) == true)
			{
				count--;
				display = true;
			}
		}
		// Error if the target is wrong
		else if(error == 2)
		{
			
		}
		// Critical error, THE ACTING CHARACTER IS WRONG!
		else if(error == 3)
		{
			
		}
		textOverlay.SetActive(true);
		textOverlayT.enabled = true;
		if (display) 
		{
			textOverlayT.text = dialogue[count];
			display = false;
		}
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

	int CheckErrors(int line, string name, string action, string target)
	{
		Debug.Log ("Count: "+count+", Checking for line: "+line+
			"\nIn CheckErrors, currentCharacter: "+CM.combatQueue [CM.currentCharacter].Name+", name should be: "+name+
			"\nAction: "+CM.combatQueue [CM.currentCharacter].action+", checking for: "+action+
			"\nTarget: "+CM.combatQueue [CM.currentCharacter].Target[0].Name+", checking for: "+target);
		Character currentCharacter = CM.combatQueue [CM.currentCharacter];
		if(count == line)
		{
			if(currentCharacter.Name != name)
			{
				return 3;
			}
			else
			{
				if(currentCharacter.action != action &&
					currentCharacter.action != "None")
				{
					Debug.Log ("error 1 found");
					return 1;
				}
				else
				{
					if(currentCharacter.Target[0].Name != target && 
						currentCharacter.Target[0].Name != currentCharacter.Name)
					{
						return 2;
					}
				}
			}
		}
		return 0;
	}

	int CheckErrors(int line, string name, string action)
	{
		Debug.Log ("Count: "+count+", Checking for line: "+line+
					"\nIn CheckErrors, currentCharacter: "+CM.combatQueue [CM.currentCharacter].Name+", name should be: "+name+
					"\nAction: "+CM.combatQueue [CM.currentCharacter].action+", checking for: "+action);
		Character currentCharacter = CM.combatQueue [CM.currentCharacter];
		if(count == line)
		{
			if(currentCharacter.Name != name)
			{
				return 3;
			}
			else
			{
				if(currentCharacter.action != action &&
					currentCharacter.action != "None")
				{
					Debug.Log ("error 1 found");
					return 1;
				}
			}
		}
		return 0;
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
