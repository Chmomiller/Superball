using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatManager : MonoBehaviour
{
	public enum ACTION{THROW, CATCH, GATHER, SKILL, REST}
	public enum PHASE{START, SELECT, ACTION, TARGET, EXECUTE, RESULTS}

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
	public Character selection;	
	public ACTION actionSelection;

	// Used to see if balls were caught and by who
	private System.Collections.Generic.List<bool> ballsCaught;
	public bool win = false;
	public bool lose = false;

	void Start()
	{
		//selection = null;
		//actionSelection = null;
		Player = new Character[3];
		Player[0] = GameObject.Find ("Player").GetComponent<Character>();
		Player[1] = GameObject.Find ("Player (1)").GetComponent<Character>();
		Player[2] = GameObject.Find ("Player (2)").GetComponent<Character>();
		Enemy = new Character[3];
		Enemy[0] = GameObject.Find ("Enemy").GetComponent<Character>();
		Enemy[1] = GameObject.Find ("Enemy (1)").GetComponent<Character>();
		Enemy[2] = GameObject.Find ("Enemy (2)").GetComponent<Character>();
		playerSelect = new Button [3];
		playerSelect [0] = GameObject.Find ("Player").GetComponent<Button>();
		playerSelect[1] = GameObject.Find ("Player (1)").GetComponent<Button>();
		playerSelect[2] = GameObject.Find ("Player (2)").GetComponent<Button>();
		playerSelect [0].onClick.AddListener (()=>CharacterSelect (Player[0]));
		playerSelect [1].onClick.AddListener (()=>CharacterSelect (Player[1]));
		playerSelect [2].onClick.AddListener (()=>CharacterSelect (Player[2]));
		enemySelect = new Button [3];
		enemySelect [0] = GameObject.Find ("Enemy").GetComponent<Button>();
		enemySelect[1] = GameObject.Find ("Enemy (1)").GetComponent<Button>();
		enemySelect[2] = GameObject.Find ("Enemy (2)").GetComponent<Button>();
		enemySelect [0].onClick.AddListener (()=>CharacterSelect (Enemy[0]));
		enemySelect [1].onClick.AddListener (()=>CharacterSelect (Enemy[1]));
		enemySelect [2].onClick.AddListener (()=>CharacterSelect (Enemy[2]));
		action = new Button[1];
		action [0] = GameObject.Find ("AttackButton").GetComponent<Button> ();
		action[0].onClick.AddListener (()=>ActionSelect(ACTION.THROW));		
		battleText = GameObject.Find ("BattleText").GetComponent<Text> ();
		//action[1].onClick.AddListener (()=>ActionSelect(ACTION.CATCH));
		//action[2].onClick.AddListener (()=>ActionSelect(ACTION.GATHER));
		//action[3].onClick.AddListener (()=>ActionSelect(ACTION.SKILL));
		//action[4].onClick.AddListener (()=>ActionSelect(ACTION.REST));
		ballsCaught = new System.Collections.Generic.List<bool>();
		combatQueue = new Combat[6];
	}

	void Update()
	{
		switch (currentPhase) 
		{
		case(PHASE.START):						// Currently the coin toss is not implememted
			StartQueue ();
			currentPhase = PHASE.SELECT;
			break;
		case(PHASE.SELECT):
			Select ();
			currentPhase = PHASE.EXECUTE;
			break;
		case(PHASE.EXECUTE):
			Execute ();
			currentPhase = PHASE.RESULTS;
			break;
		case(PHASE.RESULTS):
			Results ();
			currentPhase = PHASE.START;
			break;
		}
	}

	void StartQueue()								
	{
		int j = 0;
		int k = 0;
		for(int i = 0; i < 6; i++)
		{
			// If either array actually gets to the end this causes a problem
			if (j < 3) {
				Debug.Log (Player [j].Stamina);
				Debug.Log (Enemy [j].Stamina);

				if (k > 2 || Player [j].Stamina >= Enemy [k].Stamina) {
					combatQueue [i].character = Player [j];
					j++;
					print ("Character " + i + " is " + combatQueue [i].character.Name);
				}
			}
			if (k < 3) {
				Debug.Log ("in k");
				if (j > 2 || Player [j].Stamina < Enemy [k].Stamina) {
					combatQueue [i].character = Enemy [k];
					k++;
					print ("Character " + i + " is " + combatQueue [i].character.Name);
				}
			}
		}
	}

	void Select()
	{
		for (int i = 0; i < 6; i++) 
		{
			if(! combatQueue[i].character.dead)
			{
				if (combatQueue [i].character.tag == "player") 
				{
					if (i != 5) 
					{
						if (combatQueue [i + 1].character.tag == "player") 
						{
							PlayerChoice (i);
						}
					}
					ActionChoice (i);
				} 
				else 
				{
					EnemyTurn (i);
				}
			} 
			else 
			{
				combatQueue [i].action = ACTION.REST;
				combatQueue [i].target = null;
			}
		}

		// This block is meant to reorder blockers to the front of the queue relative to one another.
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
				// How does garbage collection work in C# for Unity? 
			}
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

	// This is meant to "pause" void Select until the player selects a character
	// it probably doesn't work right
	void PlayerChoice(int first)
	{
		if(currentPhase == PHASE.SELECT)
		{
			while (selection == null) 
			{}
			while(! selection == combatQueue[first].character && ! selection == combatQueue[first+1].character)
			{}
			if (selection == combatQueue [first + 1].character) 
			{
				Character temp = combatQueue [first].character;
				combatQueue [first].character = combatQueue [first + 1].character;
				combatQueue [first + 1].character = temp;
			}
		}
	}

	void ActionChoice(int first)
	{
		if(currentPhase == PHASE.SELECT)
		{
			while (actionSelection == null) //Change this
			{}
			if (currentPhase == PHASE.TARGET && combatQueue [first].action != ACTION.GATHER) 
			{
				currentPhase = PHASE.TARGET;
				while (selection != null) 
				{}
				while (selection.tag != "Enemy") 
				{}
				combatQueue [first].target = selection;
				currentPhase = PHASE.SELECT;
			} 
			else 
			{
				combatQueue [first].target = null;
			}
		}
	}

	// This is where the code for selecting a character with the mouse goes.
	void CharacterSelect(Character character)
	{
		selection = character;
	}

	// This is where the code for selecting an action with the mouse goes.
	void ActionSelect(ACTION action)
	{
		actionSelection = action;
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
				} 
				else 
				{
					battleText.text = "Enemy attacks Player!";
				}
				if (combatQueue [i].character.throwBall ()) {
					if (combatQueue [i].target.catchBall () == 1) {
						if (combatQueue [i].target.tag == "Player") {
							ballsCaught.Add (true);
							battleText.text = "Player caught the ball!";
						} else {
							ballsCaught.Add (false);
							battleText.text = "Enemy caught the ball!";
						}
					}
				}
				break;
			case(ACTION.GATHER):
				// Add a gatherBall() function in Character.cs if the action makes the final cut
				break;
			case(ACTION.CATCH):
				combatQueue [i].character.catching = true;
				break;
			case(ACTION.SKILL):
				combatQueue [i].character.Skill1 ();
				break;
			}
		}
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
		while (ballsCaught.Count > 0) {
			Resurrect (ballsCaught[0]);
			ballsCaught.RemoveAt (0);
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