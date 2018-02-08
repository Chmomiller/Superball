using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatManager : MonoBehaviour
{
	public enum ACTION{NONE, THROW, CATCH, GATHER, SKILL1, SKILL2, SKILL3, REST}
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

	// Used to see if balls were caught and by who
	private System.Collections.Generic.List<bool> ballsCaught;
	private int conflictInQueue = -1;
	public bool win = false;
	public bool lose = false;

	void Start()
	{
		Player = new Character[3];
		Enemy = new Character[3];
		playerSelect = new Button [3];
		enemySelect = new Button [3];
		for (int i = 0; i < 3; i++) 
		{
			Player[i] = GameObject.Find ("Player"+i).GetComponent<Character>();
			Enemy[i] = GameObject.Find ("Enemy"+i).GetComponent<Character>();

			playerSelect [i] = GameObject.Find ("Player"+i).GetComponent<Button>();
			enemySelect [i] = GameObject.Find ("Enemy"+i).GetComponent<Button>();
		}
		action = new Button[6];
		action [0] = GameObject.Find ("ThrowButton").GetComponent<Button> ();
		action [1] = GameObject.Find ("CatchButton").GetComponent<Button> ();
		action [2] = GameObject.Find ("GatherButton").GetComponent<Button> ();
		action [3] = GameObject.Find ("Skill1Button").GetComponent<Button> ();
		action [4] = GameObject.Find ("Skill2Button").GetComponent<Button> ();
		action [5] = GameObject.Find ("Skill3Button").GetComponent<Button> ();
		battleText = GameObject.Find ("BattleText").GetComponent<Text> ();
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
		}
		currentPhase = PHASE.CONFLICT;
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


	// This function enables all enemy buttons for selection(This will need to be changed when actions that can target allies are implemented)
	void Target ()
	{
		battleText.text = "Choose the target";
		foreach (Button B in enemySelect) 
		{
			B.enabled = true;
		}
	}


	// This function has the charcters perform their actions in the correct order
	void Execute()
	{
		for (int i = 0; i < 6; i++) 
		{
			switch (combatQueue [i].action) 
			{
			case(ACTION.THROW):
				// This calls the charcter's throwBall function and increments ballCaught as necessary for resurrections
				if (combatQueue [i].character.tag == "Player") 
				{
					battleText.text = "Player attacks Enemy!";
					Debug.Log (combatQueue [i].character.Name + " attacks " + combatQueue [i].target.Name + "!");
				} 
				else 
				{
					battleText.text = "Enemy attacks Player!";
					Debug.Log (combatQueue [i].character.Name + " attacks " + combatQueue [i].target.Name + "!");
				}
				if (combatQueue [i].character.throwBall ()) 
				{
					if (combatQueue [i].target.catchBall () == 1) 
					{
						if (combatQueue [i].target.tag == "Player") 
						{
							ballsCaught.Add (true);
							battleText.text = "Player caught the ball!";
							Debug.Log (combatQueue [i].target.Name + " caught the ball!");
						} 
						else 
						{
							ballsCaught.Add (false);
							battleText.text = "Enemy caught the ball!";
							Debug.Log (combatQueue [i].target.Name + " caught the ball!");
						}
					}
				}
				break;
			case(ACTION.GATHER):
				// Add a gatherBall() function in Character.cs if the action makes the final cut
				Debug.Log (combatQueue [i].character.Name + " picked up a ball!");
				break;
			case(ACTION.CATCH):
				combatQueue [i].character.catching = true;
				Debug.Log (combatQueue [i].character.Name + " is ready to catch!");
				break;
			case(ACTION.SKILL1):
				combatQueue [i].character.Skill1 ();
				Debug.Log (combatQueue [i].character.Name + " used Skill!");
				break;
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
		currentPhase = PHASE.START;
	}


	// This function is called when a character button is pressed.
	public void CharacterSelect(int character)
	{
		// If this is the player SELECT phase
		// The (character < 3) is required because of a wierd error where 3 is passed as an argument for no reason after the first click
		if (currentPhase == PHASE.SELECT && character < 3) 
		{
			// If the selected character is not the first one in the combat queue that is also in conflict with another allies position
			if (Player [character] != combatQueue [conflictInQueue].character) 
			{
				// Swap the characters
				Character temp = combatQueue [conflictInQueue].character;
				combatQueue [conflictInQueue].character = combatQueue [conflictInQueue + 1].character;
				combatQueue [conflictInQueue + 1].character = temp;
			}
			conflictInQueue = -1;
			currentPhase = PHASE.ACTION;
		}
		if (currentPhase == PHASE.TARGET) 
		{
			// Get the position of the first actionless character and set this character as the target of the action before that
			int firstAction = 5;
			for(int i = 5; i > -1; i--)
			{
				if(combatQueue[i].action == ACTION.NONE)
				{
					firstAction = i;
				}
			}
			combatQueue [firstAction - 1].target = Enemy [character - 3];
			currentPhase = PHASE.CONFLICT;
		}
	}


	// This function is called when an action button is selected. It sets the appropriate action for the current character
	public void ActionSelect(int action)
	{
		if(currentPhase == PHASE.ACTION)
		{
			int firstAction = 5;
			for(int i = 5; i > -1; i--)
			{
				if(combatQueue[i].action == ACTION.NONE)
				{
					firstAction = i;
				}
			}
			switch (action) 
			{
			case(0):
				combatQueue [firstAction].action = ACTION.THROW;
				break;
			case(1):
				combatQueue [firstAction].action = ACTION.CATCH;
				break;
			case(2):
				combatQueue [firstAction].action = ACTION.GATHER;
				break;
			case(3):
				combatQueue [firstAction].action = ACTION.SKILL1;
				break;
			case(4):
				combatQueue [firstAction].action = ACTION.SKILL2;
				break;
			case(5):
				combatQueue [firstAction].action = ACTION.SKILL3;
				break;
			}
			// This will need to be changed when actions that target allies or non-throw actions that target enemies are added
			if (combatQueue [firstAction].action == ACTION.THROW) 
			{
				currentPhase = PHASE.TARGET;
			} 
			else 
			{
				currentPhase = PHASE.CONFLICT;
			}
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
			break;
		case(1):
			combatQueue [current].action = ACTION.CATCH;
			break;
		case(2):
			combatQueue [current].action = ACTION.GATHER;
			break;
		case(3):
			combatQueue [current].action = ACTION.SKILL1;
			break;
		}
		if (combatQueue [current].action != ACTION.GATHER) 
		{
			choice = Random.Range (0, 3);
			while (Player [choice].dead) 
			{
				choice = Random.Range (0, 3);
			}
			combatQueue [current].target = Player [choice];
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
					if (Player [i].Stamina > Player [highestStamina].Stamina) 
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
					if (Player [i].Stamina > Player [highestStamina].Stamina) 
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
}