using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatManager : MonoBehaviour
{
	public enum ACTION{NONE, THROW, CATCH, GATHER, SKILL1, SKILL2, SKILL3, SKILL4, REST, WAIT}
	public enum PHASE{START, CONFLICT, SELECT, ACTION, TARGET, EXECUTE, RESULTS}

	public struct Combat{public Character character; 
		public ACTION action; 
		public Character target;}

	// Used for storing turn order and actions
	public Combat[] combatQueue;								
	public PHASE currentPhase;
	public Character[] Player;
	public Character[] Enemy;
	public Button[] playerSelect;
	public Button[] enemySelect;
	public Button[] action;
	// This is for debug purposes
	public Text battleText;	
	public Text combatAction;
	public CombatUI CUI;

	// Used to see if balls were caught and by who
	private System.Collections.Generic.List<bool> ballsCaught;
	public int conflictInQueue = -1;
	public bool win = false;
	public bool lose = false;

	public int currentCharacter = 0;
	public float delay = 0f;

	void Start()
	{
		Player = new Character[3];
		Enemy = new Character[3];
		playerSelect = new Button [3];
		enemySelect = new Button [3];
		GameObject[] P = GameObject.FindGameObjectsWithTag("Player");
		GameObject[] E = GameObject.FindGameObjectsWithTag ("Enemy");
		for (int i = 0; i < 3; i++) 
		{
			Player [i] = P [i].GetComponent<Character>();
			Enemy [i] = E [i].GetComponent<Character>();
			GameObject.Find("Player"+i).GetComponent<CharacterSelectUI> ().character = i;
			GameObject.Find("Enemy"+i).GetComponent<CharacterSelectUI> ().character = i;

			playerSelect [i] = GameObject.Find ("Player" + i).GetComponent<Button> ();
			enemySelect [i] = GameObject.Find ("Enemy" + i).GetComponent<Button> ();
			GameObject.Find ("CharacterUI" + i).GetComponent<CharacterUI> ().character = Player [i];
			GameObject.Find ("CharacterUI" + (i+3)).GetComponent<CharacterUI> ().character = Enemy [i];

			P [i].transform.position = playerSelect [i].transform.position;
			E [i].transform.position = enemySelect [i].transform.position;
		}
		action = new Button[7];
		action [0] = GameObject.Find ("ThrowButton").GetComponent<Button> ();
		action [1] = GameObject.Find ("CatchButton").GetComponent<Button> ();
		action [3] = GameObject.Find ("Skill1Button").GetComponent<Button> ();
		action [4] = GameObject.Find ("Skill2Button").GetComponent<Button> ();
		action [5] = GameObject.Find ("Skill3Button").GetComponent<Button> ();
		action [6] = GameObject.Find ("Skill4Button").GetComponent<Button> ();
		battleText = GameObject.Find ("BattleText").GetComponent<Text> ();
		combatAction = GameObject.Find ("CombatAction").GetComponent<Text> ();
		CUI = GameObject.Find ("CombatUI").GetComponent<CombatUI> ();
		ballsCaught = new System.Collections.Generic.List<bool>();
		combatQueue = new Combat[6];
	}

	void Update()
	{
		switch (currentPhase) 
		{
		case(PHASE.START):
			StartQueue ();
			break;
		case(PHASE.CONFLICT):
			Conflict();
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
			Execute ();
			break;
		case(PHASE.RESULTS):
			Results ();
			break;
		}
	}

	// This function is the start of the turn. It orders the characters by stamina
	void StartQueue()								
	{
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
			{
				if (tempChar [j-1].Stamina < tempChar [j].Stamina) 
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
			combatQueue [i].character = tempChar [i];
			combatQueue [i].action = ACTION.NONE;
			combatQueue [i].character.gatherBall ();
		}
		currentPhase = PHASE.CONFLICT;
		CUI.ShowPhase ();
	}


	// This function is used to check if there are still conflicts in the queue and set current phase to the correct phase
	void Conflict()
	{
		// Check if there is a conflict in the queue
		conflictInQueue = -1;
		for(int i = 4; i > -1; i--)
		{
			if (combatQueue[i].action == ACTION.NONE 
				&& combatQueue [i].character.tag == "Player"
				&& combatQueue [i+1].character.tag == "Player"
				&& combatQueue [i].character.Stamina == combatQueue [i+1].character.Stamina) 
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
			if (combatQueue [i].action == ACTION.NONE) 
			{
				firstAction = i;
			}
		}

		if(firstAction != -1 
			&& combatQueue[firstAction].character.findStatus("stun") != -1)
		{
			combatQueue[firstAction].character.action = "None";
			combatQueue [firstAction].character.actionType = "None";
			combatQueue [firstAction].action = ACTION.WAIT;
			combatQueue [firstAction].character.Target = combatQueue [firstAction].character;
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
				if(!combatQueue[firstAction].character.dead)
				{
					if (combatQueue [firstAction].character.tag == "Player") 
					{
						currentPhase = PHASE.ACTION;
					} 
					else 
					{
						EnemyTurn (firstAction);
					}
				}
				else
				{
					// All downed character are given the rest action
					for (int i = firstAction; i < 6; i++) 
					{
						combatQueue [i].action = ACTION.REST;
						combatQueue [i].character.action = "Rest";
						combatQueue [i].character.actionType = "Utility";
						combatQueue [i].character.Target = combatQueue [i].character;
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
				if(combatQueue[i].action == ACTION.CATCH)
				{
					Combat temp = combatQueue [i];
					while (i - k > j) 
					{
						combatQueue [i - k] = combatQueue [i - k - 1];
						k++;
					}
					combatQueue [j] = temp;
					j++;
				}
			}
			currentPhase = PHASE.EXECUTE;
		}
		if (firstAction != -1) 
		{
			currentCharacter = firstAction;
		}
	}


	// This function activates player select buttons if there is a conflict in the queue
	void Select()
	{
		// delegates would help here
		battleText.text = "Choose " + combatQueue[conflictInQueue].character.Name + " or " + combatQueue[conflictInQueue+1].character.Name;
		combatQueue [conflictInQueue].character.gameObject.GetComponent<Button> ().enabled = true;
		combatQueue [conflictInQueue+1].character.gameObject.GetComponent<Button> ().enabled = true;
		// If the player has selected a character to go first
	}


	// This function deactivates player select buttons
	void Action()
	{
		battleText.text = "Choose your action";
		foreach(Button B in playerSelect)
		{
			B.enabled = false;
		}
	}


	// This function effectively does nothing since targets are made availible in actionSelect and the phase is changed in characterSelect
	void Target ()
	{
		battleText.text = "Choose the target";
	}


	// This function has the charcters perform their actions in the correct order
	void Execute()
	{
		CUI.ShowPhase ();
		for (int i = 0; i < 6; i++) 
		{
			print (combatQueue[i].character.Name + combatQueue[i].action);
		}

		for (int i = 0; i < 6; i++) 
		{
			print (combatQueue[i].character.Name+": " + combatQueue[i].character.dead);
			if(! combatQueue[i].character.dead) 
				//&& combatQueue[i].character.findStatus("stun") != -1)
			{
				DoAction (combatQueue [i].character, combatQueue [i].action);
			}
			if(combatQueue[i].character.dead)
			{
				combatQueue[i].character.action = "Rest";
				combatQueue[i].action = ACTION.REST;
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
			if (combatQueue [i].character.dead) 
			{
				combatQueue [i].character.Rest ();
			}
		}
		// rez players as needed
		while (ballsCaught.Count > 0) 
		{
			Resurrect (ballsCaught[0]);
			ballsCaught.RemoveAt (0);
		}

		foreach(Combat C in combatQueue)
		{
			CleanUp(C.character);
		}
		//currentPhase = PHASE.START;
		
		this.enabled = false;
		StartCoroutine(PhaseChange());
	}


	void DoAction(Character character, ACTION action)
	{
		print ("DoAction running");
		switch (action) 
		{
		case(ACTION.THROW):
			StartCoroutine (PrintOut (character.Name + " attacks " + character.Target.Name + "!"));
			if (character.Target.actionType == "Defense") {
				switch (character.Target.action) {
				case("Catch"):
					if (character.Target.catchBall (character)) 
					{
						if (character.tag == "Player") 
						{
							ballsCaught.Add (true);
						} 
						else 
						{
							ballsCaught.Add (false);
						}
						
						StartCoroutine (PrintOut (character.Target.Name + " caught the ball!"));
						Debug.Log (character.Target.Name + " caught the ball!");
					}
					break;
				case("Skill1"):
					character.Target.Skill1 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used Skill " + character.Target.GetActionName (4) + " !"));
					Debug.Log (character.Target.Name + " used Skill " + character.Target.GetActionName (4) + " !");
					break;
				case("Skill2"):
					character.Target.Skill2 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used Skill " + character.Target.GetActionName (5) + " !"));
					Debug.Log (character.Target.Name + " used Skill 2!");
					break;
				case("Skill3"):
					character.Target.Skill3 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used Skill " + character.Target.GetActionName (6) + " !"));
					Debug.Log (character.Target.Name + " used Skill 3!");
					break;
				case("Skill4"):
					character.Target.Skill4 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used Skill " + character.Target.GetActionName (7) + " !"));
					Debug.Log (character.Target.Name + " used Skill 4!");
					break;
				}
			} 
			else 
			{
				character.throwBall (character.Target);
			}
			character.heldBalls--;
			break;
		case(ACTION.CATCH):
			// This can be implemented when the character needs multiple targets designated
			/*
				for(int i = 0; i < 6; i++)
				{
					for(int j = 0; j < 3; j++)
					{
						if(combatQueue[i].character.Target[j] == character.Target[0] 
							&& combatQueue[i].character.actionType == "Offensive")
						{
							combatQueue[i].character.Target[j] = character;
							combatQueue[i].target = character;
						}	
					}
				}
				*/

			for(int i = 0; i < 6; i++)
			{
				if(combatQueue[i].character.Target == character.Target 
					&& combatQueue[i].character.actionType == "Offensive")
				{
					combatQueue[i].character.Target = character;
					combatQueue[i].target = character;
				}
				
				StartCoroutine (PrintOut (character.Name + " is ready to catch!"));
				Debug.Log (character.Name + " is ready to catch!");
			}
			break;
		case(ACTION.GATHER):
			character.gatherBall();
			
			StartCoroutine (PrintOut (character.Name + " picked up a ball!"));
			Debug.Log (character.Name + " picked up a ball!");
			break;
		case(ACTION.SKILL1):
			// check if the action is offensive and the target is using a defensive move.
			
			StartCoroutine (PrintOut (character.Name + " used " + character.GetActionName (4) + " !"));
			Debug.Log (character.Name + " used " + character.GetActionName (4) + " !");
			if (character.actionType == "Offense"
			    && character.Target.actionType == "Defense") {
				switch (character.Target.action) {
				case("Catch"):
					if (character.Target.catchBall (character)) {
						if (character.tag == "Player") {
							ballsCaught.Add (true);
						} else {
							ballsCaught.Add (false);
						}
					}
					character.heldBalls--;
					
					StartCoroutine (PrintOut (character.Target.Name + " caught the ball!"));
					Debug.Log (character.Target.Name + " caught the ball!");
					break;
				case("Skill1"):
					character.Target.Skill1 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used Skill " + character.Target.GetActionName (4) + " !"));
					Debug.Log (character.Target.Name + " used Skill " + character.Target.GetActionName (4) + " !");
					break;
				case("Skill2"):
					character.Target.Skill2 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used Skill " + character.Target.GetActionName (5) + " !"));
					Debug.Log (character.Target.Name + " used Skill 2!");
					break;
				case("Skill3"):
					character.Target.Skill3 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used Skill " + character.Target.GetActionName (6) + " !"));
					Debug.Log (character.Target.Name + " used Skill 3!");
					break;
				case("Skill4"):
					character.Target.Skill4 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used Skill " + character.Target.GetActionName (7) + " !"));
					Debug.Log (character.Target.Name + " used Skill 4!");
					break;
				}
			} 
			else
			{
				character.Skill1 ();
			}
			break;
		case(ACTION.SKILL2):
			
			StartCoroutine (PrintOut (character.Name + " used Skill 2!"));
			Debug.Log (character.Name + " used Skill 2!");
			if (character.actionType == "Offense"
			    && character.Target.actionType == "Defense") {
				switch (character.Target.action) {
				case("Catch"):
					if (character.Target.catchBall (character)) 
					{
						if (character.tag == "Player") 
						{
							ballsCaught.Add (true);
						} 
						else 
						{
							ballsCaught.Add (false);
						}
					}
					character.heldBalls--;
					
					StartCoroutine (PrintOut (character.Target.Name + " caught the ball!"));
					Debug.Log (character.Target.Name + " caught the ball!");
					break;
				case("Skill1"):
					character.Target.Skill1 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (4) + " !"));
					Debug.Log (character.Target.Name + " used " + character.Target.GetActionName (4) + " !");
					break;
				case("Skill2"):
					character.Target.Skill2 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (5) + " !"));
					Debug.Log (character.Target.Name + " used Skill 2!");
					break;
				case("Skill3"):
					character.Target.Skill3 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (6) + " !"));
					Debug.Log (character.Target.Name + " used Skill 3!");
					break;
				case("Skill4"):
					character.Target.Skill4 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (7) + " !"));
					Debug.Log (character.Target.Name + " used Skill 4!");
					break;
				}
			}
			else
			{
				character.Skill2 ();	
			}
			break;
		case(ACTION.SKILL3):
			
			StartCoroutine (PrintOut (character.Name + " used Skill 3!"));
			Debug.Log (character.Name + " used Skill 3!");
			if (character.actionType == "Offense"
			    && character.Target.actionType == "Defense") {
				switch (character.Target.action) {
				case("Catch"):
					if (character.Target.catchBall (character)) 
					{
						if (character.tag == "Player") 
						{
							ballsCaught.Add (true);
						} 
						else 
						{
							ballsCaught.Add (false);
						}
					}
					character.heldBalls--;
					
					StartCoroutine (PrintOut (character.Target.Name + " caught the ball!"));
					Debug.Log (character.Target.Name + " caught the ball!");
					break;
				case("Skill1"):
					character.Target.Skill1 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (4) + " !"));
					Debug.Log (character.Target.Name + " used " + character.Target.GetActionName (4) + " !");
					break;
				case("Skill2"):
					character.Target.Skill2 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (5) + " !"));
					Debug.Log (character.Target.Name + " used Skill 2!");
					break;
				case("Skill3"):
					character.Target.Skill3 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (6) + " !"));
					Debug.Log (character.Target.Name + " used Skill 3!");
					break;
				case("Skill4"):
					character.Target.Skill4 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (7) + " !"));
					Debug.Log (character.Target.Name + " used Skill 4!");
					break;
				}
			}
			else
			{
				character.Skill3 ();	
			}
			break;
		case(ACTION.SKILL4):
			
			StartCoroutine (PrintOut (character.Name + " used Skill 4!"));
			Debug.Log (character.Name + " used Skill 4!");
			if (character.actionType == "Offense"
				&& character.Target.actionType == "Defense") {
				switch (character.Target.action) {
				case("Catch"):
					if (character.Target.catchBall (character)) 
					{
						if (character.tag == "Player") 
						{
							ballsCaught.Add (true);
						} 
						else 
						{
							ballsCaught.Add (false);
						}
					}
					character.heldBalls--;
					
					StartCoroutine (PrintOut (character.Target.Name + " caught the ball!"));
					Debug.Log (character.Target.Name + " caught the ball!");
					break;
				case("Skill1"):
					character.Target.Skill1 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (4) + " !"));
					Debug.Log (character.Target.Name + " used " + character.Target.GetActionName (4) + " !");
					break;
				case("Skill2"):
					character.Target.Skill2 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (5) + " !"));
					Debug.Log (character.Target.Name + " used Skill 2!");
					break;
				case("Skill3"):
					character.Target.Skill3 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (6) + " !"));
					Debug.Log (character.Target.Name + " used Skill 3!");
					break;
				case("Skill4"):
					character.Target.Skill4 ();
					
					StartCoroutine (PrintOut (character.Target.Name + " used " + character.Target.GetActionName (7) + " !"));
					Debug.Log (character.Target.Name + " used Skill 4!");
					break;
				}
			}
			else
			{
				character.Skill4 ();	
			}
			break;
		}
	}

	// This function randomly assigns actions and targets for enemies.
	void EnemyTurn(int current)
	{
		int choice = Random.Range (0, 4);
		switch (choice) 
		{
		case(0):
			combatQueue [current].action = ACTION.THROW;
			combatQueue [current].character.action = "Throw";
			break;
		case(1):
			combatQueue [current].action = ACTION.CATCH;
			combatQueue[current].character.action = "Catch";
			break;
		case(2):
			combatQueue [current].action = ACTION.GATHER;
			combatQueue[current].character.action = "Gather";
			break;
		case(3):
			combatQueue [current].action = ACTION.SKILL1;
			combatQueue[current].character.action = "Skill1";
			break;
		}
		combatQueue [current].character.actionType = combatQueue [current].character.GetActionType (choice + 1);
		if (combatQueue [current].action != ACTION.GATHER) 
		{
			choice = Random.Range (0, 3);
			while (Player [choice].dead) 
			{
				choice = Random.Range (0, 3);
			}
			combatQueue [current].target = Player [choice];
			combatQueue [current].character.Target = Player[choice];
		}
	}


	void CleanUp(Character current)
	{
		current.removeDoneStatusEffects ();
		for (int i = 0; i < current.statusEffects.Length; i++) 
		{
			if(current.statusEffects[i].duration > 0)
			{
				current.statusEffects [i].duration--;
			}
		}
		current.action = "None";
		current.actionType = "None";
		current.Target = current;
		for (int i = 0; i < current.actionCooldowns.Length; i++) 
		{
			if(current.actionCooldowns[i] > 0)
			{
				current.actionCooldowns [i]--;
			}
		}
	}


	// This function puts players back into the game
	void Resurrect(bool player)
	{
		int highestStamina = 0;
		bool Res = false;
		// If the character to be rezzed is an ally
		if (player) 
		{
			// Get the player with the hishest stamina that is benched
			for (int i = 0; i < 3; i++) 
			{
				if(Player[i].dead)
				{
					if (Player [i].Stamina > Player [highestStamina].Stamina 
						&& Player[i].Stamina >= Player[i].Stamina/2) 
					{
						highestStamina = i;
						Res = true;
					}
				}
			}
			// If there is a benched player
			if (Res) 
			{
				Player [highestStamina].dead = false;
			}
		} 
		else 
		{
			// Get the enemy with the hishest stamina that is benched
			for (int i = 0; i < 3; i++) 
			{
				if(Player[i].dead)
				{
					if (Enemy [i].Stamina > Enemy[highestStamina].Stamina 
						&& Enemy[i].Stamina >= Enemy[i].Stamina/2) 
					{
						highestStamina = i;
						Res = true;
					}
				}
			}
			// If there is a benched enemy
			if (Res) 
			{
				Enemy [highestStamina].dead = false;
			}
		}
	}

	IEnumerator PrintOut(string whatToSay)
	{
		delay += 1f;
		print (whatToSay + ", delay is: " + delay);
		yield return new WaitForSeconds (delay);
		combatAction.text = whatToSay;
	}

	IEnumerator PhaseChange()
	{
		this.enabled = false;
		delay += 2f;
		yield return new WaitForSeconds (delay);
		combatAction.text = "";
		delay = 0f;
		this.enabled = true;
		currentPhase = PHASE.START;
	}
}