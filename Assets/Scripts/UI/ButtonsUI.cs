using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsUI : MonoBehaviour 
{
	public CombatManager CM;

	// Use this for initialization
	void Start () 
	{
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// This function is called when an action button is selected. It sets the appropriate action for the current character
	public void ActionSelect(int action)
	{
		if(CM.currentPhase == CombatManager.PHASE.ACTION)
		{
			// Check if the action is valid
			if(CM.combatQueue[CM.currentCharacter].character.GetActionCost(action) > CM.combatQueue[CM.currentCharacter].character.heldBalls 
				|| CM.combatQueue[CM.currentCharacter].character.actionCooldowns[action] > 0)
			{
				return;
			}

			CM.combatQueue [CM.currentCharacter].action = (CombatManager.ACTION)(action);
			CM.combatQueue [CM.currentCharacter].character.action = CM.combatQueue [CM.currentCharacter].character.GetAction (action);
			CM.combatQueue [CM.currentCharacter].character.actionType = CM.combatQueue [CM.currentCharacter].character.GetActionType(action);
			CM.combatQueue [CM.currentCharacter].character.targetingType = CM.combatQueue [CM.currentCharacter].character.GetTargetingType(action);	
			if (CM.combatQueue [CM.currentCharacter].character.actionType == "Defense") 
			{
				CM.combatQueue [CM.currentCharacter].character.catching = true;
			}
			switch (CM.combatQueue [CM.currentCharacter].character.GetTargetingType (action)) 
			{
			case(0):
				CM.currentPhase = CombatManager.PHASE.CONFLICT;
				CM.combatQueue [CM.currentCharacter].character.Target = CM.combatQueue [CM.currentCharacter].character;
				break;
			case(1):
				CM.currentPhase = CombatManager.PHASE.TARGET;
				foreach(Button B in CM.enemySelect)
				{
					B.enabled = true;
				}
				break;
			case(2):
				CM.currentPhase = CombatManager.PHASE.TARGET;
				foreach(Button B in CM.playerSelect)
				{
					B.enabled = true;
				}
				break;
			}
		}
	}
}
