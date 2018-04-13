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
	public Character[] combatQueue;								
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

	public TemporaryUIIntegration[] tempUI;

	// Used to see if balls were caught and by who
	private System.Collections.Generic.List<bool> ballsCaught;
	public int conflictInQueue = -1;
	public bool win = false;
	public bool lose = false;

	public int currentCharacter = 0;
	public float delay = 0f;

	void Start()
	{
		GameObject[] CharUI = new GameObject[3];
		GameObject[] EnemyUI = new GameObject[3];
		Player = new Character[3];
		Enemy = new Character[3];
		playerSelect = new Button [3];
		enemySelect = new Button [3];
		for (int i = 0; i < 3; i++) 
		{
			Player[i] = GameObject.Find("Character"+i).GetComponent<Character>();
			Enemy [i] = GameObject.Find ("Character" + (i + 3)).GetComponent<Character> ();
			Player [i].combat = this;
			Enemy [i].combat = this;
			GameObject.Find("Player"+i).GetComponent<CharacterSelectUI> ().character = i;
			GameObject.Find("Player"+i).GetComponent<CharacterSelectUI> ().CM = this;
			GameObject.Find("Enemy"+i).GetComponent<CharacterSelectUI> ().character = i+3;
			GameObject.Find("Enemy"+i).GetComponent<CharacterSelectUI> ().CM = this;

			playerSelect [i] = GameObject.Find ("Player" + i).GetComponent<Button> ();
			enemySelect [i] = GameObject.Find ("Enemy" + i).GetComponent<Button> ();

			CharUI [i] = GameObject.Find ("CharacterUI" + i);
			CharUI [i].GetComponent<CharacterUI> ().Init(Player [i]);
			EnemyUI [i] = GameObject.Find ("CharacterUI" + (i + 3));
			EnemyUI [i].GetComponent<CharacterUI> ().Init(Enemy [i]);

			Player[i].transform.position = new Vector3(playerSelect [i].transform.position.x, playerSelect [i].transform.position.y, 90);
			Enemy [i].transform.position = new Vector3(enemySelect [i].transform.position.x, enemySelect [i].transform.position.y, 90);
		}
		action = new Button[8];
		action [0] = GameObject.Find ("ThrowButton").GetComponent<Button> ();
		action [1] = GameObject.Find ("CatchButton").GetComponent<Button> ();
		action [2] = GameObject.Find ("Skill1Button").GetComponent<Button> ();
		action [3] = GameObject.Find ("Skill2Button").GetComponent<Button> ();
		action [4] = GameObject.Find ("Skill3Button").GetComponent<Button> ();
		action [5] = GameObject.Find ("Skill4Button").GetComponent<Button> ();
		action [6] = GameObject.Find ("Skill5Button").GetComponent<Button> ();
		action [7] = GameObject.Find ("Skill6Button").GetComponent<Button> ();
		battleText = GameObject.Find ("BattleText").GetComponent<Text> ();
		combatAction = GameObject.Find ("CombatAction").GetComponent<Text> ();
		CUI = GameObject.Find ("CombatUI").GetComponent<CombatUI> ();
		ballsCaught = new System.Collections.Generic.List<bool>();
		combatQueue = new Character[6];
		for (int i = 0; i < action.Length; i++) 
		{
			action [i].GetComponent<ButtonsUI> ().CM = this;
		}
			
		for(int i = 0; i < 3; i++)
		{
			CharUI [i].GetComponentInChildren<TemporaryUIIntegration> ().Init(Player [i]);
			EnemyUI [i].GetComponentInChildren<TemporaryUIIntegration> ().Init(Enemy [i]);
			for (int j =0; j <3; j++)
			{
				Player [i].allies [j] = Player [j];
				Player [i].enemies [j] = Enemy [j];
				Enemy [i].allies [j] = Enemy [j];
				Enemy [i].enemies [j] = Player [j];
			}
		}
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
			//Execute ();
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
				//The first clause orders by stamina, the second ignores the case where j is out but j-1 is active
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
			combatQueue [i].action = "None";
			combatQueue [i].gatherBall ();
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
			if (combatQueue [i].action == "None") 
			{
				firstAction = i;
			}
		}

		// This block will run when findstatus can work properly
		/*
		if(firstAction != -1
			&& combatQueue[firstAction].character.findStatus("stun") != -1)
		{
			combatQueue[firstAction].character.action = "None";
			combatQueue [firstAction].character.actionType = "None";
			combatQueue [firstAction].action = ACTION.WAIT;
			combatQueue [firstAction].character.Target = combatQueue [firstAction].character;
			return;
		}
		*/

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
					else 
					{
						// This allows the player to control enemy actions for now
						currentPhase = PHASE.ACTION;
						//EnemyTurn (firstAction);
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
			currentPhase = PHASE.EXECUTE;
			Execute ();
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
		battleText.text = "Choose " + combatQueue[conflictInQueue].Name + " or " + combatQueue[conflictInQueue+1].Name;
		for(int i = 0; i < 3; i++)
		{
			if(combatQueue[conflictInQueue] == Player[i] 
				|| combatQueue[conflictInQueue+1] == Player[i])
			{
				playerSelect [i].enabled = true;
			}
		}
		//combatQueue [conflictInQueue].character.gameObject.GetComponent<Button> ().enabled = true;
		//combatQueue [conflictInQueue+1].character.gameObject.GetComponent<Button> ().enabled = true;
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
		for (currentCharacter = 0; currentCharacter < 6; currentCharacter++) 
		{
			if(! combatQueue[currentCharacter].dead) 
				//&& combatQueue[i].character.findStatus("stun") != -1)
			{
				DoAction (combatQueue [currentCharacter], combatQueue [currentCharacter].action);
			}
			if(combatQueue[currentCharacter].dead)
			{
				combatQueue[currentCharacter].action = "Rest";
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
				combatQueue [i].Rest ();
			}
		}
		// rez players as needed
		while (ballsCaught.Count > 0) 
		{
			Resurrect (ballsCaught[0]);
			ballsCaught.RemoveAt (0);
		}
			
		foreach(Character C in combatQueue)
		{
			C.cleanUp();
		}
		
		//currentPhase = PHASE.START;
		
		this.enabled = false;
		StartCoroutine(PhaseChange());
	}


	public void DoAction(Character character, string action)
	{
		// This bool determines if character does their action after checking what the target's action is.
		// performAction is intended to be set by Character functions which should return bools
		bool performAction = false;
		switch (action) 
		{
		case("Throw"):
			StartCoroutine (PrintOut (character.Name + " attacks " + character.Target[0].Name + "!"));
			if (character.Target[0].actionType == "Defense") {
				switch (character.Target[0].action) {
				case("Catch"):
					//character.heldBalls--;
					if (character.Target[0].catchBall (character)) 
					{
						if (character.Target[0].tag == "Player") 
						{
							ballsCaught.Add (true);
						} 
						else 
						{
							ballsCaught.Add (false);
						}
						
						StartCoroutine (PrintOut (character.Target[0].Name + " caught the ball!"));
						Debug.Log (character.Target[0].Name + " caught the ball!");
					}
					else
					{
						performAction = true;
					}
					break;
				case("Skill1"):
					performAction = character.Target[0].Skill1 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (4) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (4) + " !");
					break;
				case("Skill2"):
					performAction = character.Target[0].Skill2 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (5) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 2!");
					break;
				case("Skill3"):
					performAction = character.Target[0].Skill3 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (6) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 3!");
					break;
				case("Skill4"):
					performAction = character.Target[0].Skill4 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (7) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 4!");
					break;
				}
				if (performAction) 
				{
					character.throwBall (character.Target[0]);
				}
			} 
			else 
			{
				character.throwBall (character.Target[0]);
			}
			break;
		case("Catch"):
			for(int i = 0; i < 6; i++)
			{
				
				for(int j = 0; j < 3; j++)
				{
					bool targetFound = false;
					if(combatQueue[i].Target[j] == character.Target[0] 
						&& combatQueue[i].actionType == "Offensive"
						&& !targetFound)
					{
						combatQueue[i].Target[j] = character;
						targetFound = true;
					}
				}
			}
			StartCoroutine (PrintOut (character.Name + " is ready to catch!"));
			Debug.Log (character.Name + " is ready to catch!");
			break;
		case("Gather"):
			character.gatherBall();
			
			StartCoroutine (PrintOut (character.Name + " picked up a ball!"));
			Debug.Log (character.Name + " picked up a ball!");
			break;
		case("Skill1"):
			// check if the action is offensive and the Target[0] is using a defensive move.
			//character.heldBalls -= character.GetActionCost(4);
			StartCoroutine (PrintOut (character.Name + " used " + character.GetActionName (4) + " !"));
			Debug.Log (character.Name + " used " + character.GetActionName (4) + " !");
			if (character.actionType == "Offense"
			    && character.Target[0].actionType == "Defense") {
				switch (character.Target[0].action) {
				case("Catch"):
					if (character.Target [0].catchBall (character)) {
						if (character.Target[0].tag == "Player") {
							ballsCaught.Add (true);
						} else {
							ballsCaught.Add (false);
						}
					}
					else
					{
						performAction = true;
					}
					
					StartCoroutine (PrintOut (character.Target[0].Name + " caught the ball!"));
					Debug.Log (character.Target[0].Name + " caught the ball!");
					break;
				case("Skill1"):
					performAction = character.Target[0].Skill1 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (4) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (4) + " !");
					break;
				case("Skill2"):
					performAction = character.Target[0].Skill2 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (5) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 2!");
					break;
				case("Skill3"):
					performAction = character.Target[0].Skill3 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (6) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 3!");
					break;
				case("Skill4"):
					performAction = character.Target[0].Skill4 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used Skill " + character.Target[0].GetActionName (7) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 4!");
					break;
				}
				if(performAction)
				{
					character.Skill1 ();	
				}
			} 
			else
			{
				character.Skill1 ();
			}
			break;
		case("Skill2"):
			//character.heldBalls -= character.GetActionCost(5);
			StartCoroutine (PrintOut (character.Name + " used Skill 2!"));
			Debug.Log (character.Name + " used Skill 2!");
			if (character.actionType == "Offense"
			    && character.Target[0].actionType == "Defense") {
				switch (character.Target[0].action) {
				case("Catch"):
					if (character.Target [0].catchBall (character)) {
						if (character.Target [0].tag == "Player") {
							ballsCaught.Add (false);
						} else {
							ballsCaught.Add (true);
						}
					}
					else
					{
						performAction = false;
					}
					
					StartCoroutine (PrintOut (character.Target[0].Name + " caught the ball!"));
					Debug.Log (character.Target[0].Name + " caught the ball!");
					break;
				case("Skill1"):
					performAction = character.Target[0].Skill1 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (4) + " !"));
					Debug.Log (character.Target[0].Name + " used " + character.Target[0].GetActionName (4) + " !");
					break;
				case("Skill2"):
					performAction = character.Target[0].Skill2 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (5) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 2!");
					break;
				case("Skill3"):
					performAction = character.Target[0].Skill3 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (6) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 3!");
					break;
				case("Skill4"):
					performAction = character.Target[0].Skill4 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (7) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 4!");
					break;
				}
				if(performAction)
				{
					character.Skill2 ();
				}
			}
			else
			{
				character.Skill2 ();	
			}
			break;
		case("Skill3"):
			//character.heldBalls -= character.GetActionCost (6);
			StartCoroutine (PrintOut (character.Name + " used Skill 3!"));
			Debug.Log (character.Name + " used Skill 3!");
			print (character.Name + " actionType: " + character.actionType + ", " 
				+ character.Target[0].Name + " actionType: " + character.Target[0].actionType);
			if (character.actionType == "Offense"
			    && character.Target[0].actionType == "Defense") {
				switch (character.Target[0].action) {
				case("Catch"):
					if (character.Target[0].catchBall (character)) 
					{
						if (character.Target [0].tag == "Player") 
						{
							ballsCaught.Add (true);
						} 
						else 
						{
							ballsCaught.Add (false);
						}
					}
					else
					{
						performAction = true;
					}
						
					
					StartCoroutine (PrintOut (character.Target[0].Name + " caught the ball!"));
					Debug.Log (character.Target[0].Name + " caught the ball!");
					break;
				case("Skill1"):
					performAction = character.Target[0].Skill1 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (4) + " !"));
					Debug.Log (character.Target[0].Name + " used " + character.Target[0].GetActionName (4) + " !");
					break;
				case("Skill2"):
					performAction = character.Target[0].Skill2 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (5) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 2!");
					break;
				case("Skill3"):
					performAction = character.Target[0].Skill3 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (6) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 3!");
					break;
				case("Skill4"):
					performAction = character.Target[0].Skill4 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (7) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 4!");
					break;
				}
				if(performAction)
				{
					character.Skill3 ();
				}
			}
			else
			{
				character.Skill3 ();	
			}
			break;
		case("Skill4"):
			//character.heldBalls -= character.GetActionCost (7);
			StartCoroutine (PrintOut (character.Name + " used Skill 4!"));
			Debug.Log (character.Name + " used Skill 4!");
			if (character.actionType == "Offense"
				&& character.Target[0].actionType == "Defense") {
				switch (character.Target[0].action) {
				case("Catch"):
					if (character.Target[0].catchBall (character)) 
					{
						if (character.Target [0].tag == "Player") 
						{
							ballsCaught.Add (true);
						} 
						else 
						{
							ballsCaught.Add (false);
						}
					}
					else
					{
						performAction = true;
					}
					
					StartCoroutine (PrintOut (character.Target[0].Name + " caught the ball!"));
					Debug.Log (character.Target[0].Name + " caught the ball!");
					break;
				case("Skill1"):
					performAction = character.Target[0].Skill1 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (4) + " !"));
					Debug.Log (character.Target[0].Name + " used " + character.Target[0].GetActionName (4) + " !");
					break;
				case("Skill2"):
					performAction = character.Target[0].Skill2 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (5) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 2!");
					break;
				case("Skill3"):
					performAction = character.Target[0].Skill3 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (6) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 3!");
					break;
				case("Skill4"):
					performAction = character.Target[0].Skill4 ();
					
					StartCoroutine (PrintOut (character.Target[0].Name + " used " + character.Target[0].GetActionName (7) + " !"));
					Debug.Log (character.Target[0].Name + " used Skill 4!");
					break;
				}
				if(performAction)
				{
					character.Skill4 ();
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
		//combatQueue [current].action = "Throw";
		int choice = Random.Range (0, 4);
		/*
		switch (choice) 
		{
		case(0):
			combatQueue [current].action = "Throw";
			break;
		case(1):
			combatQueue[current].action = "Catch";
			break;
		case(2):
			combatQueue[current].action = "Gather";
			break;
		case(3):
			combatQueue[current].action = "Skill1";
			break;
		}

		combatQueue [current].actionType = combatQueue [current].GetActionType (choice);
		if (combatQueue [current].GetTargetingType(choice) != 0) 
		{
			if (combatQueue [current].GetTargetingType(choice) == 1) 
			{
				choice = Random.Range (0, 3);
				while (Player [choice].dead) 
				{
					choice = Random.Range (0, 3);
				}
				combatQueue [current].Target = Player [choice];
			}
			if (combatQueue [current].GetTargetingType(choice) == 2) 
			{
				choice = Random.Range (0, 3);
				while (Enemy [choice].dead) 
				{
					choice = Random.Range (0, 3);
				}
				combatQueue [current].Target = Enemy [choice];
			}
		}
		else
		{
			combatQueue [current].action = "None";
			combatQueue [current].actionType = combatQueue [current].GetActionType (choice);
		}
		*/

		combatQueue [current].action = "Throw";
		combatQueue [current].actionType = "Offense";

		choice = Random.Range (0, 3);
		while (Player [choice].dead) 
		{
			choice = Random.Range (0, 3);
		}
		for(int i = 0; i < 3; i++)
		{
			combatQueue [current].Target[i] = Player [choice];
		}
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
		Debug.Log (whatToSay + ", delay is: " + delay);
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