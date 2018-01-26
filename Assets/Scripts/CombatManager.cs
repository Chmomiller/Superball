using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatManager : MonoBehaviour
{
	public enum ACTION{THROW, CATCH, GATHER, SKILL, REST}
	public enum PHASE{START, SELECT, ACTION, TARGET, EXECUTE, RESULTS}

	public class Combat{public Character character; 
						public ACTION action; 
						public Character target;}
	
	// Used for storing turn order and actions
	private Combat[] combatQueue;								
	private PHASE currentPhase;
	public Character[] Player;
	public Character[] Enemy;
	public Button[] playerSelect;
	public Button[] enemySelect;
	public Button[] action;
	// This is for debug purposes
	public Text battleText;										
	// true if the player has to choose turn order.
	private bool conflictInQueue;								

	// Used to see if balls were caught and by who
	private int [] ballCaught;
	public bool win = false;
	public bool lose = false;

	void Start()
	{
		conflictInQueue = false;
		Player[0] = GameObject.Find ("player").GetComponent<Character>();
		Player[1] = GameObject.Find ("player (1)").GetComponent<Character>();
		Player[2] = GameObject.Find ("player (2)").GetComponent<Character>();
		Enemy[0] = GameObject.Find ("Enemy").GetComponent<Character>();
		Enemy[1] = GameObject.Find ("Enemy (1)").GetComponent<Character>();
		Enemy[2] = GameObject.Find ("player (2)").GetComponent<Character>();
		//Player.GetComponent<Button>().onClick.AddListener (()=>CharacterSelect (0));
		playerSelect [0].onClick.AddListener (()=>CharacterSelect (Player[0]));
		playerSelect [1].onClick.AddListener (()=>CharacterSelect (Player[1]));
		playerSelect [2].onClick.AddListener (()=>CharacterSelect (Player[2]));
		enemySelect [0].onClick.AddListener (()=>CharacterSelect (Enemy[0]));
		enemySelect [1].onClick.AddListener (()=>CharacterSelect (Enemy[1]));
		enemySelect [2].onClick.AddListener (()=>CharacterSelect (Enemy[2]));
		action[0].onClick.AddListener (()=>ActionSelect(ACTION.THROW));		
		//action[1].onClick.AddListener (()=>ActionSelect(ACTION.CATCH));
		//action[2].onClick.AddListener (()=>ActionSelect(ACTION.GATHER));
		//action[3].onClick.AddListener (()=>ActionSelect(ACTION.SKILL));
		//action[4].onClick.AddListener (()=>ActionSelect(ACTION.REST));
		ballCaught = new int[2];
		ballCaught [0] = 0;
		ballCaught [1] = 0;
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
			if (Player [j].Stamina >= Enemy [k].Stamina) 
			{
				combatQueue [i].character = Player[j];
				j++;
			}
			else if(Player [j].Stamina < Enemy [k].Stamina)
			{
				combatQueue [i].character = Enemy[k];
				k++;
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
							// Player chooses character //
							//conflictInQueue = true;
							//StartCoroutine (PlayerChoice);
						}
					}
					// Get player's action //
					/* switch(combatQueue[i].action)
					{
						case(ACTION.GATHER):
							combatQueue[i].target = null;
							break;
						default:
							// get the target //
					}
					*/
				} 
				else 
				{
					EnemyTurn (combatQueue [i].character);
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

	void EnemyTurn(Character enemy)
	{
		// Enemy AI
	}

	// This is meant to "pause" void Select until the player selects a character
	// it probably doesn't work right
	IEnumerator PlayerChoice()
	{
		while(! conflictInQueue)
		{}
		yield return null;
	}

	// This is where the code for selecting a character with the mouse goes.
	void CharacterSelect(Character character)
	{
		conflictInQueue = false;
	}

	// This is where the code for selecting an action with the mouse goes.
	ACTION ActionSelect(ACTION action)
	{
		return action;
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
					ballCaught[0] += combatQueue [i].character.throwBall (combatQueue [i].target);
				} 
				else 
				{
					ballCaught[1] += combatQueue [i].character.throwBall (combatQueue [i].target);
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
		while (ballCaught [0] > 0) 
		{
			Resurrect ("Player");
			ballCaught [0]--;
		}
		while (ballCaught [1] > 0) 
		{
			Resurrect ("Enemy");
			ballCaught [0]--;
		}
	}

	// This function puts players back into the game
	void Resurrect(string team)
	{
		int highestStamina = 0;
		bool Res = false;
		if (team == "Player") 
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