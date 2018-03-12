using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsUI : MonoBehaviour 
{
	public float AlphaThreshold = 0.5f;
	public int actionNumber;
	public CombatManager CM;
	public Text actionDescription;
	public string desc;
	public bool menuOpen;

	// Use this for initialization
	void Start () 
	{
		gameObject.GetComponent<Button> ().onClick.AddListener (ActionSelect);
		this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
		actionDescription = GameObject.Find ("ActionPanel").GetComponentInChildren<Text>();
		menuOpen = false;
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (CM.currentPhase == CombatManager.PHASE.ACTION) 
		{
			desc = CM.combatQueue [CM.currentCharacter].character.actionDescription [actionNumber];
		}
	}

	// This function is called when an action button is selected. It sets the appropriate action for the current character
	public void ActionSelect()
	{
		if(CM.currentPhase == CombatManager.PHASE.ACTION)
		{
			// Check if the action is valid
			if(CM.combatQueue[CM.currentCharacter].character.GetActionCost(actionNumber) > CM.combatQueue[CM.currentCharacter].character.heldBalls 
				|| CM.combatQueue[CM.currentCharacter].character.actionCooldowns[actionNumber] > 0)
			{
				return;
			}

			CM.combatQueue [CM.currentCharacter].action = (CombatManager.ACTION)(actionNumber);
			CM.combatQueue [CM.currentCharacter].character.action = CM.combatQueue [CM.currentCharacter].character.GetAction (actionNumber);
			CM.combatQueue [CM.currentCharacter].character.actionType = CM.combatQueue [CM.currentCharacter].character.GetActionType(actionNumber);
			CM.combatQueue [CM.currentCharacter].character.targetingType = CM.combatQueue [CM.currentCharacter].character.GetTargetingType(actionNumber);	
			// This will need to change if there is a non-catching defensive move
			if (CM.combatQueue [CM.currentCharacter].character.actionType == "Defense") 
			{
				CM.combatQueue [CM.currentCharacter].character.catching = true;
			}
			switch (CM.combatQueue [CM.currentCharacter].character.GetTargetingType (actionNumber)) 
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

	void OnMouseOver()
	{
		if(CM.currentPhase == CombatManager.PHASE.ACTION)
		{
			actionDescription.text = desc;
			menuOpen = true;
		}
	}

	void OnMouseExit()
	{
		menuOpen = false;
	}
}
