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
			desc = CM.combatQueue [CM.currentCharacter].actionDescription [actionNumber];
		}
	}

	// This function is called when an action button is selected. It sets the appropriate action for the current character
	public void ActionSelect()
	{
		// If action phase
		if(CM.currentPhase == CombatManager.PHASE.ACTION)
		{
			// Check if the action is valid
			if(CM.combatQueue[CM.currentCharacter].GetActionCost(actionNumber) > CM.combatQueue[CM.currentCharacter].heldBalls 
				|| CM.combatQueue[CM.currentCharacter].actionCooldowns[actionNumber] > 0)
			{
				return;
			}
				
			// set the current character's action based on actionNumber
			CM.combatQueue [CM.currentCharacter].action = CM.combatQueue [CM.currentCharacter].GetAction (actionNumber);
			CM.combatQueue [CM.currentCharacter].actionType = CM.combatQueue [CM.currentCharacter].GetActionType(actionNumber);
			CM.combatQueue [CM.currentCharacter].targetingType = CM.combatQueue [CM.currentCharacter].GetTargetingType(actionNumber);	

			// If the action is defensive the player is catching (This will need to change if there is a non-catching defensive move)
			if (CM.combatQueue [CM.currentCharacter].actionType == "Defense") 
			{
				CM.combatQueue [CM.currentCharacter].catching = true;
			}
			//if(CM.combatQueue[CM.currentCharacter].tag == "Player")
			//{
				switch (CM.combatQueue [CM.currentCharacter].GetTargetingType (actionNumber)) 
				{
				case(0):
					CM.currentPhase = CombatManager.PHASE.CONFLICT;
					for(int i = 0; i < 3; i ++)
					{
						CM.combatQueue [CM.currentCharacter].Target[i] = CM.combatQueue [CM.currentCharacter];
					}
					break;
				case(1):
					CM.currentPhase = CombatManager.PHASE.TARGET;
					for(int i  = 0; i < 3; i++)
					{
					if(!CM.Enemy[i].dead)
						{	
							CM.enemySelect[i].enabled = true;
						}
					}
					break;
				case(2):
					CM.currentPhase = CombatManager.PHASE.TARGET;
					for (int i = 0; i < 3; i++) {
						if (!CM.Player [i].dead) {	
							CM.playerSelect [i].enabled = true;
						}
					}
					break;
				}/*
			}
			else
			{
				switch (CM.combatQueue [CM.currentCharacter].GetTargetingType (actionNumber)) 
				{
				case(0):
					CM.currentPhase = CombatManager.PHASE.CONFLICT;
					for(int i = 0; i < 3; i ++)
					{
						CM.combatQueue [CM.currentCharacter].Target[i] = CM.combatQueue [CM.currentCharacter];
					}
					break;
				case(1):
					CM.currentPhase = CombatManager.PHASE.TARGET;
					for (int i = 0; i < 3; i++) {
						if (!CM.Player [i].dead) {	
							CM.playerSelect [i].enabled = true;
						}
					}
					break;
				case(2):
					CM.currentPhase = CombatManager.PHASE.TARGET;
					for(int i  = 0; i < 3; i++)
					{
						if(!CM.Enemy[i].dead)
						{	
							CM.enemySelect[i].enabled = true;
						}
					}
					break;
				}
			}*/
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
