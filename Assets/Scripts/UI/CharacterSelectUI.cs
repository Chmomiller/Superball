using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelectUI : MonoBehaviour 
{
	public int character;
	public CombatManager CM;
	// Use this for initialization
	void Start () 
	{
		gameObject.GetComponent<Button> ().onClick.AddListener (CharacterSelect);
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();	
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
		if (CM.currentPhase == CombatManager.PHASE.TARGET) 
		{
			if (character < 3) 
			{
				CM.combatQueue [CM.currentCharacter].Target = CM.Player [character];
			} 
			else 
			{
				CM.combatQueue [CM.currentCharacter].Target = CM.Enemy [character - 3];
			}
			CM.currentPhase = CombatManager.PHASE.CONFLICT;
		}
	}
}
