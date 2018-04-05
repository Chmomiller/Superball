using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConflictCursorManager : MonoBehaviour 
{
	public CombatManager CM;

	void Start()
	{
		CM = GameObject.Find ("CombatManager").GetComponent<CombatManager> ();
	}

	void Update () 
	{
		if(CM.currentPhase == CombatManager.PHASE.SELECT)
		{
			if (CM.currentCharacter > -1 && CM.currentCharacter < 6) 
			{
				gameObject.transform.position = new Vector3 (CM.combatQueue[CM.conflictInQueue + 1].transform.position.x, 
					CM.combatQueue[CM.conflictInQueue + 1].transform.position.y + 2, -5f);
			}
		}
		else
		{
			gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 1000f);
		}
	}
}
