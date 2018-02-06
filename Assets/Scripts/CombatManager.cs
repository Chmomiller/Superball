using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatManager : MonoBehaviour
{
	public enum ACTION{NONE, THROW, CATCH, GATHER, SKILL, REST}
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
	// true if the player has to choose turn order.
	public int selection;	
	public ACTION actionSelection;

	// Used to see if balls were caught and by who
	private System.Collections.Generic.List<bool> ballsCaught;
	private int conflictInQueue = -1;
	public bool win = false;
	public bool lose = false;

	void Start()
	{
		selection = -1;
		Player = new Character[3];
		Enemy = new Character[3];
		playerSelect = new Button [3];
		enemySelect = new Button [3];
		for (int i = 0; i < 3; i++) 
		{
			Player[i] = GameObject.Find ("Player"+i).GetComponent<Character>();
			Enemy[i] = GameObject.Find ("Enemy"+i).GetComponent<Character>();

			playerSelect [i] = GameObject.Find ("Player"+i).GetComponent<Button>();
			playerSelect [i].onClick.AddListener (()=>CharacterSelect (i));
			enemySelect [i] = GameObject.Find ("Enemy"+i).GetComponent<Button>();
			enemySelect [i].onClick.AddListener (()=>CharacterSelect (i));
		}
		action = new Button[1];
		action [0] = GameObject.Find ("AttackButton").GetComponent<Button> ();
		action[0].onClick.AddListener (()=>ActionSelect(0));		
		battleText = GameObject.Find ("BattleText").GetComponent<Text> ();
		//action[1].onClick.AddListener (()=>ActionSelect(ACTION.CATCH));
		//action[2].onClick.AddListener (()=>ActionSelect(ACTION.GATHER));
		//action[3].onClick.AddListener (()=>ActionSelect(ACTION.SKILL));
		ballsCaught = new System.Collections.Generic.List<bool>();
		combatQueue = new Combat[6];
	}

	void Update()
	{
		// Currently the coin toss is not implememted

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


	void StartQueue()								
	{
		Character[] tempChar = new Character[6];
		for (int i = 0; i < 3; i++) 
		{
			tempChar [i] = Player [i];
			tempChar [i + 3] = Enemy [i];
		}

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

		for (int i = 0; i < 6; i++) 
		{
			combatQueue [i].character = tempChar [i];
			combatQueue [i].action = ACTION.NONE;
			Debug.Log("Player " + i + " is " + combatQueue[i].character.name);
		}
		currentPhase = PHASE.CONFLICT;
	}


	// This phase is used to check if there are still conflicts in the queue and set current phase to the correct phase
	void Conflict()
	{
		conflictInQueue = -1;
		for(int i = 4; i > -1; i--)
		{
			Debug.Log (""+combatQueue[i].action+", "+combatQueue[i].character.tag+", "+combatQueue[i+1].character.tag+", "+combatQueue[i].character.Stamina+", "+combatQueue[i+1].character.Stamina);
			if (combatQueue[i].action == ACTION.NONE 
				&& combatQueue [i].character.tag == "Player"
				&& combatQueue [i+1].character.tag == "Player"
				&& combatQueue [i].character.Stamina == combatQueue [i+1].character.Stamina) 
			{
				conflictInQueue = i;
			}
		}
		Debug.Log (combatQueue [0].character.Name+", "+combatQueue [1].character.Name+", "+combatQueue [2].character.Name);
		foreach(Button B in enemySelect)
		{
			B.enabled = false;
		}
		int firstAction = -1;
		for (int i = 5; i > -1; i--)
		{
			if (combatQueue [i].action == ACTION.NONE) 
			{
				firstAction = i;
			}
		}

		Debug.Log("conflictInQueue: " +conflictInQueue + " firstAction: " + firstAction);
		// If there is a conflict in the queue but someone else has priority
		if (conflictInQueue != -1 && firstAction >= conflictInQueue) 
		{
			currentPhase = PHASE.SELECT;
		} 
		else 
		{
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
					for (int i = firstAction; i < 6; i++) 
					{
						combatQueue [i].action = ACTION.REST;
					}
				}
			}
		}		
		if (firstAction == -1) 
		{
			for(int i = 0; i < 6; i++)
			{
				Debug.Log ("CombatQueue["+i+"] is "+ combatQueue[i].character.Name+" performing "+combatQueue[i].action);
			}

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


	void Select()
	{
		// delegates would help here
		battleText.text = "Choose " + combatQueue[conflictInQueue].character.Name + " or " + combatQueue[conflictInQueue+1].character.Name;
		combatQueue [conflictInQueue].character.gameObject.GetComponent<Button> ().enabled = true;
		combatQueue [conflictInQueue+1].character.gameObject.GetComponent<Button> ().enabled = true;
		// If the player has selected a character to go first
	}


	void Action()
	{
		battleText.text = "Choose your action";
		foreach(Button B in playerSelect)
		{
			B.enabled = false;
		}
	}

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
			case(ACTION.SKILL):
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


	public void CharacterSelect(int character)
	{
		if (currentPhase == PHASE.SELECT && character < 3) // The character < 3 is required because of a wierd error where 3 is passed as an argument for no reason after the first click
		{
			if (Player [character] != combatQueue [conflictInQueue].character) 
			{
				Character temp = combatQueue [conflictInQueue].character;
				combatQueue [conflictInQueue].character = combatQueue [conflictInQueue + 1].character;
				combatQueue [conflictInQueue + 1].character = temp;
			}
			conflictInQueue = -1;
			currentPhase = PHASE.ACTION;
		}
		if (currentPhase == PHASE.TARGET) 
		{
			int firstAction = 5;
			for(int i = 5; i > -1; i--)
			{
				if(combatQueue[i].action == ACTION.NONE)
				{
					firstAction = i;
				}
			}
			Debug.Log ("CharacterSelect(): firstAction: " + firstAction + ", character:" + character);
			combatQueue [firstAction - 1].target = Enemy [character - 3];		// I'm not sure why this works.
			currentPhase = PHASE.CONFLICT;
		}
	}


	public void ActionSelect(int action)
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
		}
		if (combatQueue [firstAction].action == ACTION.THROW) 
		{
			currentPhase = PHASE.TARGET;
		} 
		else 
		{
			currentPhase = PHASE.CONFLICT;
		}
	}


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
			combatQueue [current].action = ACTION.SKILL;
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
		if (player) 
		{
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
			if (Res) 
			{
				Player [highestStamina].dead = false;
			}
		} 
		else 
		{
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
			if (Res) 
			{
				Enemy [highestStamina].dead = false;
			}
		}
	}
}