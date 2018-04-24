using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour 
{
	public int character;
	public Image[] status;
	public Sprite[] statusImage;
	public Sprite[] TellImage;
	public CombatManager CM;
	// Use this for initialization
	void Start () 
	{
		gameObject.GetComponent<Button> ().onClick.AddListener (CharacterSelect);
		status = gameObject.GetComponentsInChildren<Image> ();
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();	
	}

	public void Init(CombatManager combatManager)
	{
		CM = combatManager;
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void CharacterSelect()
	{
		// If this is the player SELECT phase
		// The (character < 3) is required because of a wierd error where 3 is passed as an argument for no reason after the first click
		if (CM.currentPhase == CombatManager.PHASE.SELECT && character < 3) 
		{
			// If the selected character is not the first one in the combat queue that is also in conflict with another allies position
			if (CM.Player [character] != CM.combatQueue [CM.conflictInQueue]) 
			{
				// Swap the characters
				Character temp = CM.combatQueue [CM.conflictInQueue];
				CM.combatQueue [CM.conflictInQueue] = CM.combatQueue [CM.conflictInQueue + 1];
				CM.combatQueue [CM.conflictInQueue + 1] = temp;
			}
			CM.conflictInQueue = -1;
			CM.currentPhase = CombatManager.PHASE.ACTION;

		}
		// This block runs for target selection during the TARGET phase and assigns all Targets for the current Character based on the value of int character
		if (CM.currentPhase == CombatManager.PHASE.TARGET) 
		{
			// Numbers 0 - 2 are for players
			if (character < 3) 
			{
				for (int i = 0; i < 3; i++) 
				{
					CM.combatQueue [CM.currentCharacter].Target[i] = CM.Player [character];
				}
			} 
			// Numbers 3 - 5 are for enemies
			else 
			{
				for (int i = 0; i < 3; i++) 
				{
					CM.combatQueue [CM.currentCharacter].Target[i] = CM.Enemy [character - 3];
				}
			}
			CM.currentPhase = CombatManager.PHASE.CONFLICT;
		}
	}

	public void AddStatus(int newStatus)
	{
		bool afflicted = false;
		int stat = 0;
		for(int i = 3; i > 0; i--)
		{
			if(!status[i].enabled)
			{
				stat = i;
			}
			if(status[i].sprite == statusImage[newStatus])
			{
				afflicted = true;
			}
		}
		if(!afflicted)
		{
			status [stat].sprite = statusImage[newStatus];	
			status [stat].enabled = true;
		}
	}

	public void RemoveStatus(int oldStatus)
	{
		for(int i = 0; i < 3; i++)
		{
			if(status[i+1].sprite == statusImage[oldStatus])
			{
				status [i+1].enabled = false;
			}
		}
	}

	public void ShowTell(string type)
	{
		switch(type)
		{
		case("Offense"):
			status [4].enabled = true;
			status[4].sprite = TellImage [0];
			break;
		case("Defense"):
			status [4].enabled = true;
			status[4].sprite = TellImage [1];
			break;
		case("Utility"):
			status [4].enabled = true;
			status[4].sprite = TellImage [2];
			break;
		default:
			status [4].enabled = false;
			break;
		}
	}
}
