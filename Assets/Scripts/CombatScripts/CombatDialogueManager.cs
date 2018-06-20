using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatDialogueManager: MonoBehaviour {

    public int count = 0;
	public bool correction = false;

	public CombatManager CM;
    public GameObject textOverlay;
	public Text textOverlayT;
	public GameObject[] characters;
	public GameObject[] pointOfInterest;

	static string[,] tutorialDialogue = new string[,]{

		// {
		//	"Character speaking, or point of interest. EX: "Character0" or "POI0",
		//	"Dialogue",
		//	"Advancement check: "", "Action", "Target" ("" means click to continue)",
		//  "Advancement character"
		//	"Advancement condition. EX: "Throw" or "Character3" ",
		//  "Error Dialogue" 
		//	"Style: "Character" or "Narrator" (defaults to Chracter)"
		//  "Special condition: Action, Target, Status"
		//  "Special Argument1: The one the effect is being applied to",
		//  "Special Argument2: The effect being applied"
		// }

		// POI0 = Action wheel
		// POI1 = Character Portrait
		{//	0
			"Shiro", "The rules of dodgeball are a bit hazy for me, think you could give me a run-down?", 
			"Click", "", "", "",
			"", 
			"", "",	""
		},
		{//	1
			"Theodore", "So you don’t know how to play <b>dodgeball</b>?",
			"Click","","", "",
			"", 
			"", "",	""
		},
		{// 2
			"Shiro", "You got me there.",
			"Click", "", "", "",
			"", 
			"", "",	""
		},
		{//	3
			"Theodore", "Then listen well! First, when it is a player’s turn, they can do three actions.",
			"Click", "", "", "",
			"", 
			"", "",	""
		},
		{//	4
			"Theodore", "One: throw a ball at an enemy!",
			"Click", "", "", "",
			"", 
			"", "",	""
		},
		{//	5
			"Theodore", "Two: catch when an enemy throws at them!",
			"Click", "", "", "",
			"", 
			"", "",	""
		},
		{//	6
			"Theodore", "And three: use special skills for great effect, but with a cost, of course!",
			"Click", "", "", "",
			"", 
			"", "",	""
		},
		{//	7
			"Action", "The three actions can be chosen here.",
			"Click", "", "", "",
			"", 
			"", "",	""
		},
		{//	8
			"Character0 Portrait", "To check out how many balls a player has, look at the number on the player’s portrait.",
			"Click", "", "", "",
			"OutOfCharacter", 
			"", "", ""
		},
		{//	9
			"Shiro", "It is now Shiro’s turn. Click the Throw button and aim at Trevor.",
			"Action", "Shiro", "Throw", "Looks like you chose the wrong action.\nPress the \"Back\" button.",
			"OutOfCharacter", 
			"", "", ""
		},
		{//	10
			"Shiro", "It is now Shiro’s turn. Click the Throw button and aim at Trevor.",
			"Target", "Shiro", "Trevor", "Ok...That's the wrong target too...\nLet's go back a step.",
			"OutOfCharacter", 
			"", "", ""
		},
		{//	11
			"Action", "Now, it is Clemence’s turn. Press the Catch button.",
			"Action", "Clemence", "Catch", "Hold up, that's the wrong action, let's try again.",
			"OutOfCharacter", 
			"", "", ""
		},
		{//	12
			"Action", "Now, it is Clemence’s turn. Press the Catch button.",
			"Phase", "Clemence", "Conflict", "Hold up, that's the wrong action, let's try again.",
			"OutOfCharacter", 
			"", "", ""
		},
		{//	13
			"Action", "Now, it is Clemence’s turn. Press the Catch button.",
			"", "Frank", "", "",
			"OutOfCharacter", 
			"", "", ""
		},
		{//	14
			"Clemence", "The box above a character indicates what type of action that character will do.",
			"Click", "", "", "",
			"OutOfCharacter", 
			"Action", "Character3", "Throw"
		},
		{//	15
			"Enemy1", "Shiro and Trevor chose to attack, so they have red icons above them. ",
			"Click", "", "", "",
			"OutOfCharacter", 
			"Action", "Character4", "Catch"
		},
		{//	16
			"Enemy2", "Clemence, Frank, and Greg chose to defend, and so their icons are blue instead.", 
			"Click", "", "", "",
			"OutOfCharacter", 
			"Action", "Character5", "Catch"
		},
		{//	17
			"Theodore", "Now, it is Theodore’s turn. Try using skill 1 against Trevor. Once you do that, look at his portrait carefully.",
			"Action", "Theodore", "Skill1", "I feel like I should be using Skill 1...",
			"OutOfCharacter", 
			"", "",	""
		},
		{//	18
			"Theodore", "Now, it is Theodore’s turn. Try using skill 1 against Trevor. Once you do that, look at his portrait carefully.",
			"Target", "Theodore", "Trevor", "Why do I have the sudden urge to <b>NOT</> do that?",
			"OutOfCharacter", 
			"", "",	""
		},
		{//	19
			"Character1 Portrait", "Notice that the number of balls Theodore holds has changed because he used a skill that costs balls.",
			"Click","","","",
			"OutOfCharacter",
			"","",""
		},
		{//	20
			"Shiro", "Okay, I think I got it now. But what decides who goes first?",
			"Click","","","",
			"",
			"","",""
		},
		{//	21
			"Theodore", "Ah, see, here’s the thing. Each player on the field has a certain amount of stamina.",
			"Click","","","",
			"",
			"","",""
		},
		{//	22
			"Theodore", "The player with the highest stamina goes first. Then the player with the second-highest stamina goes next, and so on.",
			"Click","","","",
			"",
			"","",""
		},
		{//	23
			"Theodore", "Once all the players have decided their actions, we leave the planning phase and enter the execution phase.",
			"Click","","","",
			"",
			"","",""
		},
		{//	24
			"Shiro", "That <i>kind of</i> makes sense to me...",
			"Click","","","",
			"",
			"","",""
		},
		{//	25
			"Theodore", "Whether it makes sense or not, that’s the rule.",
			"Click","","","",
			"",
			"","",""
		},
		{//	26
			"Theodore", "That’s why you went first on the first turn.",
			"Click","","","",
			"",
			"","",""
		},
		{//	27
			"Shiro", "All right, I think I got that. But what’s the goal of the game?",
			"Click","","","",
			"",
			"","",""
		},
		{//	28
			"Theodore", "The goal is to knock out all the enemies.",
			"Click","","","",
			"",
			"","",""
		},
		{//	29
			"Character0 Portrait", "If a player’s stamina is at 25% or lower, they can get knocked out of the game, even if their stamina hasn’t reached 0 yet.",
			"Click","","","",
			"OutOfCharacter",
			"","",""
		},
		{//	30
			"Character0 Portrait", "Each player’s health is located under their portrait.",
			"Click","","","",
			"OutOfCharacter",
			"","",""
		},
		{//	31
			"Shiro", "Anything else I should know?",
			"Click","","","",
			"",
			"","",""
		},
		{//	32
			"Theodore", "Ah, yes, between rounds players gather balls automatically. That always ensures that you can at least throw at an enemy.",
			"Click","","","",
			"",
			"","",""
		},
		{//	33
			"Shiro", "I see.",
			"Click","","","",
			"",
			"","",""
		},
		{//	34
			"Theodore", "And here’s a tip for you if you want to win. Keep track of your enemies' skills. ",
			"Click","","","",
			"",
			"","",""
		},
		{//	35
			"Theodore", "knowing what the enemies’ skills are lets you see what effects they’ll have on you.",
			"Click","","","",
			"",
			"","",""
		},
		{//	36
			"Character0 Portrait", "Skills are listed when you hover over a character's portrait.",
			"Click","","","",
			"OutOfCharacter",
			"","",""
		},
		{//	37
			"Battle Log", "To keep track of what actions have been done, look at the Battle Log right here.",
			"Click","","","",
			"OutOfCharacter",
			"","",""
		},
		{//	38
			"Theodore", "Only one thing left to cover. Each player is one of three classes: <b><color=red>thrower</color>, <color=blue>catcher</color>, or <color=yellow>supporter</color></b>.",
			"Click","","","",
			"",
			"","",""
		},
		{//	39
			"Shiro", "Oh yeah! If I remember correctly I’m a <color=yellow>supporter</color>!",
			"Click","","","",
			"",
			"","",""
		},
		{//	40
			"Theodore", "Oh, really? That’s good! I’m a <color=red>thrower</color>, which means that I excel at dealing damage to enemies.",
			"Click","","","",
			"",
			"","",""
		},
		{//	41
			"Clemence", "And I'm a <color=blue>catcher</color>, which means I'm good at catching for myself and teammates.",
			"Click","","","",
			"",
			"","",""
		},
		{//	42
			"Theodore", "And you’re a <color=yellow>supporter</color>, which means that you can help your teammates by buffing, healing, etc.",
			"Click","","","",
			"",
			"","",""
		},
		{//	43
			"Shiro", "Now is that all?",
			"Click","","","",
			"",
			"","",""
		},
		{//	44
			"Theodore", "I think so Let’s play!",
			"Click","","","",
			"",
			"","", ""
		},
		{//	45
			"", "",
			"","","","",
			"",
			"Transition","Scenes/MapScreen", ""
		}
	};
		
	public bool control;
	public bool display;


	// Use this for initialization
	void Start () {
		control = false;
		display = true;
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager>();
	}

    // Update is called once per frame
    void Update() {
		if(control)
		{
			CM.combatControl = false;
		}
		else
		{
			CM.combatControl = true;
		}
		if(tutorialDialogue[count, 7] == "Transition")
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene (tutorialDialogue[count, 8]);
		}
		if(AdvanceDialogue(tutorialDialogue[count, 2], tutorialDialogue[count, 4]))
		{
			count++;
		}
		if(count != 0 && CM.currentCharacter != 0)
		{
			if(CheckErrors(tutorialDialogue[count-1, 3], tutorialDialogue[count-1, 2], tutorialDialogue[count-1, 4]))
			{
				DisplayDialogue (tutorialDialogue[count, 1], tutorialDialogue[count, 0], tutorialDialogue[count, 6]);
				correction = false;
			}
			else
			{
				control = false;
				DisplayDialogue (tutorialDialogue[count-1, 5], tutorialDialogue[count-1, 0], tutorialDialogue[count-1, 6]);
				// Correct Errors
			}
		}
		else
		{
			DisplayDialogue (tutorialDialogue[count, 1], tutorialDialogue[count, 0], tutorialDialogue[count, 6]);
			correction = false;
		}
		SpecialInstructions (tutorialDialogue[count, 7], tutorialDialogue[count, 8], tutorialDialogue[count, 9]);
    }
		
	bool AdvanceDialogue(string statement, string condition)
	{
		switch(statement)
		{
			case("Click"):
				control = true;
				if(Input.GetMouseButtonDown(0))
				{
					return true;
				}
				break;
			case("Action"):
				control = false;
				if(CM.combatQueue[CM.currentCharacter].action == condition)
				{
					return true;
				}
				break;
			case("Target"):
				control = false;
				if(CM.combatQueue[CM.currentCharacter].Target[0].Name == condition)
				{
					return true;
				}
				break;
			case("Phase"):
				control = false;
				switch(condition)
				{
				case("Start"):
					return CM.currentPhase == CombatManager.PHASE.START;
					break;
				case("Conflict"):
					return CM.currentPhase == CombatManager.PHASE.CONFLICT;
					break;
				case("Select"):
					return CM.currentPhase == CombatManager.PHASE.SELECT;
					break;
				case("Action"):
					return CM.currentPhase == CombatManager.PHASE.ACTION;
					break;
				case("Target"):
					return CM.currentPhase == CombatManager.PHASE.TARGET;
					break;
				case("Execute"):
					return CM.currentPhase == CombatManager.PHASE.EXECUTE;
					break;
				case("Results"):
					return CM.currentPhase == CombatManager.PHASE.RESULTS;
					break;
				default:
					Debug.Log ("No phase passed in AdvanceDialogue");
					return true;
					break;
				}
				break;
			default:
				Debug.Log ("AdvanceDialogue called on line " + count + " with statement: " + statement + " and condition: " + condition);
				control = true;
				return true;
				break;
		}
		return false;
	}

	bool CheckErrors(string name, string statement, string condition)
	{
		if(statement == "Click")
		{
			return true;
		}
		if(CM.currentPhase == CombatManager.PHASE.CONFLICT || CM.currentPhase == CombatManager.PHASE.TARGET)
		{
			control = true;
		}

		Character activeCharacter = CM.combatQueue [CM.currentCharacter];
		if(activeCharacter.Name != name)
		{
			activeCharacter = CM.combatQueue [CM.currentCharacter - 1];
			if(activeCharacter.Name != name)
			{
				Debug.Log ("No character with name: "+name+" was found");
				if(!correction)
				{
					StartCoroutine (CorrectErrors(activeCharacter));
				}
				return false;
			}
			else
			{
				switch(statement)
				{
				case("Action"):
					if(condition == "Any")
					{
						return true;
					}
					return activeCharacter.action == condition;
					// correct errors
					break;
				case("Target"):
					if(condition == "Any")
					{
						return true;
					}
					return activeCharacter.Target [0].Name == condition;
					// correct errors
					break;
				default:
					Debug.Log ("No statement given");
					return true;
					break;

				}
			}
			if(!correction)
			{
				StartCoroutine (CorrectErrors(activeCharacter));
			}
			return false;
		}
		else
		{
			switch(statement)
			{
				case("Action"):
					if(condition == "Any")
					{
						return true;
					}
					return activeCharacter.action == condition;
					// correct errors
					break;
				case("Target"):
					if(condition == "Any")
					{
						return true;
					}
					return activeCharacter.Target [0].Name == condition;
					// correct errors
					break;
				default:
					Debug.Log ("No statement given");
					return true;
					break;
			}
		}
	}


	void DisplayDialogue(string line, string target, string style)
	{
		switch(target)
		{
			case("Shiro"):
				textOverlay.transform.position = new Vector3 (characters[0].transform.position.x, 
															  characters[0].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Theodore"):
				textOverlay.transform.position = new Vector3 (characters[1].transform.position.x, 
															  characters[1].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Clemence"):
				textOverlay.transform.position = new Vector3 (characters[2].transform.position.x, 
															  characters[2].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Enemy1"):
				textOverlay.transform.position = new Vector3 (characters[3].transform.position.x, 
															  characters[3].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Enemy2"):
				textOverlay.transform.position = new Vector3 (characters[4].transform.position.x, 
															  characters[4].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Enemy3"):
				textOverlay.transform.position = new Vector3 (characters[5].transform.position.x, 
															  characters[5].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Action"):
				textOverlay.transform.position = new Vector3 (pointOfInterest[0].transform.position.x, 
															  pointOfInterest[0].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Character0 Portrait"):
				textOverlay.transform.position = new Vector3 (pointOfInterest[1].transform.position.x, 
				pointOfInterest[1].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Character1 Portrait"):
				textOverlay.transform.position = new Vector3 (pointOfInterest[2].transform.position.x, 
															  pointOfInterest[2].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Character2 Portrait"):
				textOverlay.transform.position = new Vector3 (pointOfInterest[3].transform.position.x, 
															  pointOfInterest[3].transform.position.y + 3.5f, 
															  this.transform.position.z);
				break;
			case("Battle Log"):
				textOverlay.transform.position = new Vector3 (pointOfInterest[4].transform.position.x, 
															  pointOfInterest[4].transform.position.y - 3.5f, 
															  this.transform.position.z);
				break;
			default:
				Debug.Log ("No target given for dialogue on line "+count);
				break;
		}
		switch(style)
		{
			case("InCharacter"):
				break;
			case("OutOfCharacter"):
				break;
			default:
			break;
		}
		textOverlayT.text = line;
	}
		
	void SpecialInstructions(string instruction, string arg1, string arg2)
	{
		switch(instruction)
		{
			case("Action"):
				switch(arg1)
				{
					case("Any"):
						break;
					default:
						Character actor = GameObject.Find (arg1).GetComponent<Character> ();
						for(int i = 0; i < actor.actions.Length; i++)
						{
							if(actor.actions[i] == arg2)
							{
								actor.actionType = actor.actionTypes [i];
								actor.CallTell ();
							}
						}
						actor.action = arg2;
						break;
				}
				break;
			case("Target"):
			switch(arg2)
			{
				case("Any"):
					break;
				default:
					Character actor = GameObject.Find (arg1).GetComponent<Character> ();
					Character target = GameObject.Find (arg2).GetComponent<Character> ();
					for(int i =0; i < actor.Target.Length; i++)
					{
						actor.Target [i] = target;
					}
					break;
			}
				break;
			default:
				break;
		}
	}


	IEnumerator CorrectErrors(Character activeCharacter)
	{
		correction = true;
		yield return new WaitForSeconds (.9f);
		activeCharacter.action = "None";
		for(int i = 0; i < 3; i++)
		{
			activeCharacter.Target [i] = activeCharacter;
		}
		count--;
		control = false;
		yield return new WaitForSeconds (.1f);
		correction = false;
	}
}
