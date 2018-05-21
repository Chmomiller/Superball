using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour 
{
	public int character;
	public Image[] status;
	public Image Tell;
	public Sprite[] statusImage;
	public Sprite[] TellImage;
	public CombatManager CM;

	// Use this for initialization
	void Start () 
	{
		gameObject.GetComponent<Button> ().onClick.AddListener (CharacterSelect);
		/*
		Image[] temp = gameObject.GetComponentsInChildren<Image> ();
		status = new Image[3];
		status [0] = temp [1];
		status [1] = temp [3];
		status [2] = temp [5];
		Tell = temp [7];
		*/
		for(int i = 0; i < status.Length; i++)
		{
			status [i].gameObject.SetActive (false);
		}
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();	
	}

	public void Init(CombatManager combatManager)
	{
		CM = combatManager;
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
		for(int i = 2; i > -1; i--)
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
			status [stat].gameObject.SetActive (true);
			status [stat].sprite = statusImage[newStatus];	
			status [stat].enabled = true;
			status [stat].GetComponent<StatusIconUI> ().statusNumber = newStatus;
		}
	}

	public void RemoveStatus(int oldStatus)
	{
		for(int i = 0; i < 3; i++)
		{
			if(status[i].GetComponent<StatusIconUI>().statusNumber == oldStatus)
			{
				status [i].enabled = false;
				status [i].GetComponent<StatusIconUI> ().statusNumber = -1;
				status [i].gameObject.SetActive (false);
			}
		}
	}

	public void ShowTell(string type)
	{
		switch(type)
		{
		case("Offense"):
			Tell.enabled = true;
			Tell.sprite = TellImage [0];
			break;
		case("Defense"):
			Tell.enabled = true;
			Tell.sprite = TellImage [1];
			break;
		case("Utility"):
			Tell.enabled = true;
			Tell.sprite = TellImage [2];
			break;
		default:
			Tell.enabled = false;
			break;
		}
	}
}
