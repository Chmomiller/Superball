using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatManager : MonoBehaviour
{
	public enum PHASE{START, CONFLICT, SELECT, ACTION, TARGET, EXECUTE, RESULTS}

	// CombatQueue stores turn order
	public Character[] combatQueue;								
	public PHASE currentPhase;
	public Character[] Player;
	public Character[] Enemy;
	// The buttons for selecting the players and enemies
	public Button[] playerSelect;
	public Button[] enemySelect;

	public CombatUI CUI;
	// This is for debug purposes
	public Text combatAction;
	public TargetCursor tCursor;

	public CombatLog combatLog;

	public EnemyAI AI;

	// Used to see if balls were caught and by who
	//private System.Collections.Generic.List<bool> ballsCaught;
	// Used when two players are at the same stamina at the start of the round
	public int conflictInQueue = -1;
	// Used so the UI can get the current character
	public int currentCharacter = 0;
	// This bool is a debug tool that switches control of enemy moves off and on
	// true = AI control, false = player control
	public bool enemyControl = true;
	// This bool switches the CombatManager on and off, similar to this.enabled
	public bool combatControl = true;
	public int turn = 0;
	public bool win = false;
	public bool lose = false;
	public string fightName;

	// Used to stagger the order of actions taken during the execute phase
	private float delay = 0f;

	void Start()
	{
		combatQueue = new Character[6];

		CUI = GameObject.Find ("CombatUI").GetComponent<CombatUI> ();
		tCursor = GameObject.Find ("TargetCursors").GetComponent<TargetCursor> ();
		GameObject[] CharUI = new GameObject[3];
		GameObject[] EnemyUI = new GameObject[3];
		Player = new Character[3];
		Enemy = new Character[3];
		playerSelect = new Button [3];
		enemySelect = new Button [3];

		// his block sets up the the characters and character select buttons 
		for (int i = 0; i < 3; i++) 
		{
			// set up the Character select buttons
			CharacterSelectUI PlayerSUI = GameObject.Find("Player"+i).GetComponent<CharacterSelectUI> ();
			CharacterSelectUI EnemySUI = GameObject.Find ("Enemy" + i).GetComponent<CharacterSelectUI> ();
			PlayerSUI.Init (this);
			EnemySUI.Init (this);

			// Set up the players
			Player[i] = GameObject.Find("Character"+i).GetComponent<Character>();
			Enemy [i] = GameObject.Find ("Character" + (i + 3)).GetComponent<Character> ();
			Player [i].Init (this, PlayerSUI);
			Enemy [i].Init (this, EnemySUI);

			playerSelect [i] = GameObject.Find ("Player" + i).GetComponent<Button> ();
			enemySelect [i] = GameObject.Find ("Enemy" + i).GetComponent<Button> ();

			// Set up each character's UI
			CharUI [i] = GameObject.Find ("CharacterUI" + i);
			CharUI [i].GetComponent<CharacterUI> ().Init(Player [i]);
			EnemyUI [i] = GameObject.Find ("CharacterUI" + (i + 3));
			EnemyUI [i].GetComponent<CharacterUI> ().Init(Enemy [i]);

			// Set the character's positions to the buttons
			Player[i].transform.position = new Vector3(playerSelect [i].transform.position.x, playerSelect [i].transform.position.y, 98);
			Enemy [i].transform.position = new Vector3(enemySelect [i].transform.position.x, enemySelect [i].transform.position.y, 98);
		}  

		// Get the action buttons and set them up
		Button[] action = new Button[8];
		action [0] = GameObject.Find ("ThrowButton").GetComponent<Button> ();
		action [1] = GameObject.Find ("CatchButton").GetComponent<Button> ();
		action [2] = GameObject.Find ("Skill1Button").GetComponent<Button> ();
		action [3] = GameObject.Find ("Skill2Button").GetComponent<Button> ();
		action [4] = GameObject.Find ("Skill3Button").GetComponent<Button> ();
		action [5] = GameObject.Find ("Skill4Button").GetComponent<Button> ();
		action [6] = GameObject.Find ("Skill5Button").GetComponent<Button> ();
		action [7] = GameObject.Find ("Skill6Button").GetComponent<Button> ();
		for (int i = 0; i < action.Length; i++) 
		{
			action [i].GetComponent<ButtonsUI> ().CM = this;
		}

		// Get text components and the end buttons
		combatAction = GameObject.Find ("CombatAction").GetComponent<Text> ();
		combatLog = GameObject.Find ("CombatLog").GetComponentInChildren<CombatLog> ();			
		//ballsCaught = new System.Collections.Generic.List<bool>();

		// This sets up the character's healthbars and sets their allies and enemies internally
		for(int i = 0; i < 3; i++)
		{
			for (int j =0; j <3; j++)
			{
				Player [i].allies [j] = Player [j];
				Player [i].enemies [j] = Enemy [j];
				Enemy [i].allies [j] = Enemy [j];
				Enemy [i].enemies [j] = Player [j];
			}
		}
		AI = gameObject.GetComponentInChildren<EnemyAI> ();
	}

	void Update()
	{
		if(combatControl)
		{
			if(!win && !lose)
			{
				switch (currentPhase) {
				case(PHASE.START):
					StartQueue ();
					break;
				case(PHASE.CONFLICT):
					Conflict ();
					break;
				case(PHASE.SELECT):
					Select ();
					break;
				case(PHASE.ACTION):
					Action ();
					break;
				case(PHASE.TARGET):
					Target ();
					break;
				case(PHASE.EXECUTE):
				//Execute ();
					break;
				case(PHASE.RESULTS):
					Results ();
					break;
				}
			}
			else
			{
				if (win) 
				{
					GameManager GM = GameObject.Find ("GameManager").GetComponent<GameManager> ();
					if(GM.hardMode)
					{
						switch(fightName)
						{
							case("Salt Pitt"):
								GameObject.Find ("GameManager").GetComponent<SaveManager> ().SaltPittBattleHard = true;
								break;
							case("Schola Grandis"):
								GameObject.Find ("GameManager").GetComponent<SaveManager> ().ScholaGrandisBattleHard = true;
								break;
							case("MightMain"):
								GameObject.Find ("GameManager").GetComponent<SaveManager> ().MightMainBattleHard = true;
								break;
							case("Yamato"):
								GameObject.Find ("GameManager").GetComponent<SaveManager> ().yamatoBattleHard = true;
								break;
							default:
							break;
						}
					}
					else
					{
						switch(fightName)
						{
						case("Salt Pitt"):
							GameObject.Find ("GameManager").GetComponent<SaveManager> ().SaltPittBattle = true;
							break;
						case("Schola Grandis"):
							GameObject.Find ("GameManager").GetComponent<SaveManager> ().ScholaGrandisBattle = true;
							break;
						case("MightMain"):
							GameObject.Find ("GameManager").GetComponent<SaveManager> ().MightMainBattle = true;
							break;
						case("Yamato"):
							GameObject.Find ("GameManager").GetComponent<SaveManager> ().yamatoBattle = true;
							break;
						default:
							break;
						}
					}
					combatAction.text = "You Win!";
				}
				else
				{
					combatAction.text = "You Lose.";
				}
			}
		}
		else
		{
			currentPhase = PHASE.CONFLICT;
		}
	}

	// This function is the start of the turn. It orders the characters by stamina
	public void StartQueue()								
	{
		turn++;
		combatLog.UpdateLog ("-----Turn "+turn+" Start-----");

		// Create a temperary array of charcters
		Character[] tempChar = new Character[6];
		for (int i = 0; i < 3; i++) 
		{
			tempChar [i] = Player [i];
			tempChar [i + 3] = Enemy [i];
		}

		// Sort the temperary array by stamina
		for (int i = 0; i < 6; i++) 
		{
			for (int j = i+1; j < 6; j++) 
			{				//The first clause orders by stamina, the second ignores the case where j is out but j-1 is active
				if (tempChar [j-1].Stamina < tempChar [j].Stamina && !(tempChar [j].dead && !tempChar [j-1].dead)) 
				{
					Character temp = tempChar [j];
					tempChar [j] = tempChar [j - 1];
					tempChar [j - 1] = temp;
				}
			}
		}
		// Assign each element of the temperary array to the approrpiate element in CombatQueue
		for (int i = 0; i < 6; i++) 
		{
			combatQueue [i] = tempChar [i];
			combatQueue [i].gatherBall ();
		}
		currentPhase = PHASE.CONFLICT;
		CUI.ShowPhase ();
	}


	// This function is used to check if there are still conflicts in the queue and set current phase to the correct phase
	void Conflict()
	{
		tCursor.ClearTargets ();
		// Check if there is a conflict in the queue
		conflictInQueue = -1;
		for(int i = 4; i > -1; i--)
		{
			if (combatQueue[i].action == "None" 
				&& combatQueue [i].tag == "Player"
				&& combatQueue [i+1].tag == "Player"
				&& combatQueue [i].Stamina == combatQueue [i+1].Stamina) 
			{
				conflictInQueue = i;
			}
		}

		// Disable all enemy buttons
		foreach(Button B in enemySelect)
		{
			B.enabled = false;
		}
		// Get the position of the first player without an action
		int firstAction = -1;
		for (int i = 5; i > -1; i--)
		{
			if (combatQueue [i].action == "None" 
				&& !combatQueue[i].dead) 
			{
				firstAction = i;
			}
		}
		// This block will run when findstatus can work properly
		if(firstAction != -1
			&& combatQueue[firstAction].findStatus(Character.STATUS.STUN) != -1)
		{
			combatQueue[firstAction].action = "Wait";
			combatQueue [firstAction].actionType = "None";
			combatQueue [firstAction - 1].CallTell ();
			return;
		}


		// If there is a conflict in the queue but someone else has priority
		if (conflictInQueue != -1 && firstAction >= conflictInQueue) 
		{
			currentPhase = PHASE.SELECT;
		} 
		else 
		{
			// If there is a character without an action
			if(firstAction != -1)
			{
				if(!combatQueue[firstAction].dead)
				{
					if (combatQueue [firstAction].tag == "Player") 
					{
						currentPhase = PHASE.ACTION;
					} 
					else if(combatQueue[firstAction].tag == "Enemy")
					{
						// This allows the player to control enemy actions for now
						currentPhase = PHASE.ACTION;
						// This bool is used for debugging in the inspector
						if(enemyControl)
						{
							//AI.FullRandomAI (combatQueue [firstAction]);
							EnemyTurn(combatQueue[firstAction]);
						}
						combatQueue [firstAction].CallTell ();

					}
				}
				else
				{
					// All downed character are given the rest action
					for (int i = firstAction; i < 6; i++) 
					{
						combatQueue [i].action = "Rest";
						combatQueue [i].actionType = "Utility";
						for(int j = 0; j < combatQueue[i].Target.Length; j++)
						{
							combatQueue [i].Target[j] = combatQueue [i];
						}
					}
				}
			}
		}
		// If there are no characters without actions
		if (firstAction == -1) 
		{
			// This block does a stable sort to move the players who are catching to the front of the queue
			int j = 0;
			for (int i = 0; i < 6; i++) 
			{
				int k = 0;
				if(combatQueue[i].action == "Catch")
				{
					Character temp = combatQueue [i];
					while (i - k > j) 
					{
						combatQueue [i - k] = combatQueue [i - k - 1];
						k++;
					}
					combatQueue [j] = temp;
					j++;
				}
			}
			// This is a brute force way to make sure the last character's tell is shown, even if they aren't last in the queue
			foreach(Character C in combatQueue)
			{
				C.CallTell ();
			}
			currentPhase = PHASE.EXECUTE;
			Execute ();
		}
		if (firstAction != -1) 
		{
			currentCharacter = firstAction;
			if (firstAction > 0) 
			{
				combatQueue [firstAction - 1].CallTell ();
			}
		}
	}


	// This function activates player select buttons if there is a conflict in the queue
	void Select()
	{
		// delegates would help here
		combatAction.text = "Choose " + combatQueue[conflictInQueue].Name + " or " + combatQueue[conflictInQueue+1].Name;
		for(int i = 0; i < 3; i++)
		{
			if(combatQueue[conflictInQueue] == Player[i] 
				|| combatQueue[conflictInQueue+1] == Player[i])
			{
				playerSelect [i].enabled = true;
			}
		}
	}

 

	// This function deactivates player select buttons
	void Action()
	{
		combatAction.text = "Choose your action";
		foreach(Button B in playerSelect)
		{
			B.enabled = false;
		}
	}


	// This function effectively does nothing since targets are made availible in actionSelect and the phase is changed in characterSelect
	void Target ()
	{
		combatAction.text = "Choose the target";
	}


	// This function has the charcters perform their actions in the correct order
	void Execute()
	{
		currentCharacter = 0;
		// Show the execute phase
		for(int i = 0; i < combatQueue.Length-1; i++)
		{
			for(int j = i+1; j < combatQueue.Length; j++)
			{
				if(combatQueue[i].actionType != "Defense" && 
					combatQueue[j].actionType == "Defense")
				{
					combatQueue [j].catching = true;
					Character swap = combatQueue [i];
					combatQueue [i] = combatQueue [j];
					combatQueue [j] = swap;
				}
			}
		}
		CUI.ShowPhase ();
		for (int i = 0; i < 6; i++) 
		{ 
			delay += 2;
			StartCoroutine( DoAction (combatQueue [i], combatQueue [i].action, delay));
			if(combatQueue[i].dead)
			{
				//combatQueue[currentCharacter].action = "Rest";
			}
		}
		currentPhase = PHASE.RESULTS;

	}


	// This function checks to see if either team lost, heals any benched players, and rezs in that order.
	void Results()
	{
		// Check if either team lost
		if(Player[0].dead && Player[1].dead && Player[2].dead)
		{
			lose = true;
		}
		if(Enemy[0].dead && Enemy[1].dead && Enemy[2].dead)
		{
			win = true;
		}
		// Heal benched characters
		for (int i = 0; i < 6; i++) 
		{
			if (combatQueue [i].dead) 
			{
				//combatQueue [i].Rest ();
			}
		}
		/*
		// rez players as needed
		while (ballsCaught.Count > 0) 
		{
			Resurrect (ballsCaught[0]);
			ballsCaught.RemoveAt (0);
		}
		*/

		// Clean up each character
		foreach(Character C in combatQueue)
		{
			C.cleanUp();
		}
		
		this.enabled = false;
		StartCoroutine(PhaseChange());
	}

	// This coroutine executes the character's actions and any reaction actions as a result and displays it
	IEnumerator DoAction(Character character, string action, float finish)
	{
		string readOut = "";
		int damage = 0;
		enabled = false;
		yield return new WaitForSeconds (finish);
		// If the characcter is not KO'd or stunned, perform their action
		if(! (character.dead || character.findStatus(Character.STATUS.STUN) != -1))
		{
			// This bool determines if character does their action after checking what the target's action is.
			// performAction is intended to be set by Character functions which should return bools
			bool performAction = false;

			// The initial attack text
			switch (action) 
			{
			case("Throw"):
				readOut = character.Name + " attacks " + character.Target [0].Name + "!";
				break;
			case("Skill1"):
				readOut = character.Name + " used " + character.GetActionName (4) + " !";
				break;
			case("Skill2"):
				readOut = character.Name + " used " + character.GetActionName (5) + " !";
				break;
			case("Skill3"):
				readOut = character.Name + " used " + character.GetActionName (6) + " !";
				break;
			case("Skill4"):
				readOut = character.Name + " used " + character.GetActionName (7) + " !";
				break;
			default:
				readOut = character.Name + " does nothing.";
				break;
			}
			combatAction.text = readOut;

			// Check if the player is catching and prepair to catch
			if(action == "Catch")
			{
				for(int i = 0; i < 6; i++)
				{
					for(int j = 0; j < 3; j++)
					{
						bool targetFound = false;
						if(combatQueue[i].Target[j] == character.Target[0] 
							&& combatQueue[i].actionType == "Offense"
							&& !targetFound)
						{
							combatQueue[i].Target[j] = character;
							targetFound = true;
						}
					}
				}
				readOut = character.Name + " is ready to catch!";
				combatAction.text = readOut;
			}
			else
			{
				// the character is attacking and the target is defending
				if (character.actionType == "Offense") 
				{
					if(character.Target[0].actionType == "Defense") 
					{
						switch (character.Target[0].action) 
						{
						case("Catch"):
							//character.heldBalls--;
							if (character.Target[0].catchBall (character)) 
							{
								if (character.Target[0].tag == "Player") 
								{
									//ballsCaught.Add (true);
								} 
								else 
								{
									//ballsCaught.Add (false);
								}

								readOut += " but "+character.Target[0].Name + " caught the ball!";
								combatAction.text = readOut;
							}
							else
							{
								performAction = true;
							}
							break;
						case("Skill1"):
							damage = character.Target [0].Skill1 ();
							if (damage > 0) 
							{
								performAction = true;
								readOut += " but " + character.Target [0].Name + 
									" used " + character.Target [0].GetActionName (4) + 
									" dealing " + damage + " damage !";
							}
							else
							{
								readOut += " but " + character.Target [0].Name + 
										   " used " + character.Target [0].GetActionName (4) + "!";
							}
							combatAction.text = readOut;
							break;
						case("Skill2"):
							damage = character.Target [0].Skill2 ();
							if (damage > 0) 
							{
								performAction = true;
								readOut += " but " + character.Target [0].Name + 
									" used " + character.Target [0].GetActionName (5) + 
									" dealing " + damage + " damage !";
							}
							else
							{
								readOut += " but " + character.Target [0].Name + 
									       " used " + character.Target [0].GetActionName (5) + "!";
							}
							combatAction.text = readOut;
							break;
						case("Skill3"):
							damage = character.Target [0].Skill3 ();
							if (damage > 0) 
							{
								performAction = true;
								readOut += " but " + character.Target [0].Name + 
									" used " + character.Target [0].GetActionName (6) + 
									" dealing " + damage + " damage !";
							}
							else
							{
								readOut += " but " + character.Target [0].Name + 
									       " used " + character.Target [0].GetActionName (6) + "!";
							}
							combatAction.text = readOut;
							break;
						case("Skill4"):
							damage = character.Target [0].Skill4 ();
							if (damage > 0) 
							{
								performAction = true;
								readOut += " but " + character.Target [0].Name + 
									" used " + character.Target [0].GetActionName (7) + 
									" dealing " + damage + " damage !";
							}
							else
							{
								readOut += " but " + character.Target [0].Name + 
										   " used " + character.Target [0].GetActionName (7) + "!";
							}
							combatAction.text = readOut;
							break;
						}
						if(damage == 0)
						{
							performAction = true;
						}
						else
						{
							performAction = false;
						}
						if (performAction) 
						{
							// These perform skills after a defensive action
							switch(action)
							{
							case("Throw"):
								readOut += character.Name + " deals " + character.throwBall (character.Target[0]) + " damage!";
								break;
							case("Skill1"):
								readOut += character.Name + " deals " + character.Skill1 () + " damage!";
								break;
							case("Skill2"):
								readOut += character.Name + " deals " + character.Skill2 () + " damage!";
								break;
							case("Skill3"):
								readOut += character.Name + " deals " + character.Skill3 () + " damage!";
								break;
							case("Skill4"):
								readOut += character.Name + " deals " + character.Skill4 () + " damage!";
								break;
							default:
								break;
							}
						}
					}
					else 
					{
						// These perform skills if the target doesn't have a defensive action
						switch(action)
						{
						case("Throw"):
							readOut += " dealing " + character.throwBall (character.Target[0]) + " damage!";
							break;
						case("Skill1"):
							readOut += " dealing " + character.Skill1 () + " damage!";
							break;
						case("Skill2"):
							readOut += " dealing " + character.Skill2 () + " damage!";
							break;
						case("Skill3"):
							readOut += " dealing " + character.Skill3 () + " damage!";
							break;
						case("Skill4"):
							readOut += " dealing " + character.Skill4 () + " damage!";
							break;
						default:
							break;
						}
					}
				}
				// If the action was not offensive, perform the action
				else
				{
					switch(action)
					{
					case("Skill1"):
						character.Skill1 ();
						break;
					case("Skill2"):
						character.Skill2 ();
						break;
					case("Skill3"):
						character.Skill3 ();
						break;
					case("Skill4"):
						character.Skill4 ();
						break;
					default:
						break;
					}
				}
			}
		}
		// If the player is KO'd or stunned show the appropriate text
		else
		{
			if(character.dead)
			{
				readOut = character.Name+" was hit and couldn't act!";
				combatAction.text = readOut;
			}
			else
			{
				readOut = character.Name+" is stunned!";
				combatAction.text = readOut;
			}
		}

		// Update the combatLog
		combatLog.UpdateLog (readOut);
		combatAction.text = readOut;

		// If this is the last action, enable CombatManager
		if(finish == delay)
		{
			enabled = true;
		}
		currentCharacter++;
	}

	// This function randomly assigns actions and targets for enemies.
	void EnemyTurn(Character actor)
	{
		int count = 0;
		int choice = Random.Range (1, 7);
		actor.action = actor.actions [choice];
		actor.actionType = actor.actionTypes [choice];

        //Check if you can actually do the skill. IE, No cooldown and you have the balls.
        while (actor.actionCooldowns[choice] > 0 || actor.heldBalls <= actor.actionCosts[count]) {
            choice = Random.Range(1, 7);
            actor.action = actor.actions[choice];
            actor.actionType = actor.actionTypes[choice];
        }

        currentPhase = PHASE.TARGET;
		switch(actor.GetTargetingType(choice))
		{
		case(2):
			choice = Random.Range(0,3);
			for(int i = 0; i < 3; i++)
			{
				actor.Target[i] = Enemy[choice];
			}
			break;
		case(1):
			choice = Random.Range(0,3);
			for(int i = 0; i < 3; i++)
			{
				actor.Target[i] = Player[choice];
			}
			break;
		default:
			break;
		}
		currentPhase = PHASE.CONFLICT;
	}


	// This function puts players back into the game
	void Resurrect(bool player)
	{
		int highestStamina = -100000;
		int current = 0;
		bool Res = false;
		// If the character to be rezzed is an ally
		if (player) 
		{
			// Get the player with the hishest stamina that is benched
			for (int i = 0; i < 3; i++) 
			{
				if(Player[i].dead)
				{
					if (Player [i].Stamina > highestStamina 
						&& Player[i].Stamina >= Player[i].maxStamina/2) 
					{
						current = i;
						Res = true;
					}
				}
			}
			// If there is a benched player
			if (Res) 
			{
				Player [current].dead = false;
			}
		} 
		else 
		{
			// Get the enemy with the hishest stamina that is benched
			for (int i = 0; i < 3; i++) 
			{
				if(Enemy[i].dead)
				{
					if (Enemy [i].Stamina > highestStamina 
						&& Enemy[i].Stamina >= Enemy[i].maxStamina/2) 
					{
						current = i;
						Res = true;
					}
				}
			}
			// If there is a benched enemy
			if (Res) 
			{
				Enemy [current].dead = false;
			}
		}
	}

	IEnumerator PrintOut(string whatToSay)
	{
		delay += 2f;
		yield return new WaitForSeconds (delay);
		combatAction.text = whatToSay;
	}

	IEnumerator PhaseChange()
	{
		this.enabled = false;
		//delay += 2f;
		yield return new WaitForSeconds (2);
		combatAction.text = "";
		delay = 0f;
		this.enabled = true;
		currentPhase = PHASE.START;
	}
}