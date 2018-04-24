using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greg: Character
{
	public Character trevor;

    void Start()
    {
        Name = "Greg";
        Stamina = maxStamina;
        
        Role = "Support";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Terrapin", "Pass Off", "Skill3", "Rest" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
										  "Catch any balls thrown at you and pass them off to Trevor", 
										  "Pass off all balls to target ally", "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Defense", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 2, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 2, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };

		base.Start ();
		/*
		foreach (Character C in enemies) 
		{
			if(C.Name == "Trevor")
			{
				trevor = C;
			}
		}
		foreach (Character C in allies) 
		{
			if(C.Name == "Trevor")
			{
				trevor = C;
			}
		}*/
    }


    void Update() {
		base.Update ();
		/*
        if (allegiance == 1) {
            this.targetingTypes = alternateTargetingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            this.targetingTypes = defaultTargetingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
        */
    }
    

	public new void Init(CombatManager CM, CharacterSelectUI combatUI)
	{
		base.Init (CM, combatUI);

		foreach (Character C in enemies) 
		{
			if(C.Name == "Trevor")
			{
				trevor = C;
			}
		}
		foreach (Character C in allies) 
		{
			if(C.Name == "Trevor")
			{
				trevor = C;
			}
		}
	}

	// This skill is Greg's Terrapin skill
	// If a hit is successful against Greg and terrapin has been used it rebounds into Trevor's ball pool
	// Is there a cost for this?
	public override bool Skill1()
    {
		if (trevor != null) {
			//recall this is a defense skill so it is called to see if you get hit, ignoring what the enemie's ability is. If they throw multiple balls, then Terrapin happens multiple times
			if (trevor.heldBalls < trevor.maxBalls)
				trevor.heldBalls++;
			actionCooldowns [4] = 3;

			for (int i = 0; i < combat.combatQueue [combat.currentCharacter].actionNames.Length; i++) {
				if (combat.combatQueue [combat.currentCharacter].action == combat.combatQueue [combat.currentCharacter].actionNames [i]) {
					combat.combatQueue [combat.currentCharacter].heldBalls -= combat.combatQueue [combat.currentCharacter].GetActionCost (i);
				}
			}
		}
		return false;
    }
	/*
    public override bool Skill2() {
       int diff = Target[0].maxBalls - Target[0].heldBalls;
        while (diff > 0 && this.heldBalls > 0) {
            Target[0].heldBalls++;
            diff = Target[0].maxBalls - Target[0].heldBalls;
        }
		return true;
    }
    */
}
