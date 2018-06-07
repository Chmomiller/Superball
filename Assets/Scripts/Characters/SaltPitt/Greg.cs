using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greg: Character
{
	public Character trevor;

    new void Start()
    {
        Name = "Greg";
        Stamina = maxStamina;
        
        Role = "Support";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Terrapin", "Hide", "Steal", "Roller Derby" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
										  "Become immune to all attacks for 1 turn, sending any balls aimed at you to trevor", 
										  "Block incoming attacks, but become <color = orange>stunned</color> on next turn",
                                          "Reduce an enemy's ball count by <color = red>2</color> and increase your own by <color = red>2</color>",
                                          "Reduce an enemy's stamina by 25%" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Defense", "Defense", "Offense", "Offense" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 1, 1 };
		alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 2, 2 };
		actionCosts = new int[]{ 0, 1, 0, 0, 1, 0, 0, 3 };



		base.Start ();

		trevor = GameObject.FindObjectOfType<Trevor> ();
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


    new void Update() {
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
	public override int Skill1()
    {
		if (trevor) {
			//recall this is a defense skill so it is called to see if you get hit, ignoring what the enemie's ability is. If they throw multiple balls, then Terrapin happens multiple times
			if (trevor.heldBalls < trevor.maxBalls)
				trevor.heldBalls++;
			actionCooldowns [4] = 3;
			Debug.Log ("combat.combatQueue [combat.currentCharacter].actionNames.Length: " + combat.combatQueue [combat.currentCharacter].actionNames.Length);
			for (int i = 0; i < combat.combatQueue [combat.currentCharacter].actionNames.Length; i++) {
				Debug.Log ("i = "+i);
				if (combat.combatQueue [combat.currentCharacter].action == combat.combatQueue [combat.currentCharacter].actionNames [i]) {
					combat.combatQueue [combat.currentCharacter].heldBalls -= combat.combatQueue [combat.currentCharacter].GetActionCost (i);
				}
			}
		}
		return -1;
    }

	//Skill2
	public override int Skill2()
	{
        //recall status effects dont stack
        this.addStatusEffect("stunned", 1);
        actionCooldowns[5] = 3;
		return -1;
	}

	// Steal
	public override int Skill3()
	{
        for (int i = 0; i < 2 && Target[0].heldBalls > 0 && this.heldBalls < this.maxBalls; i++) {
            Target[0].heldBalls--;
            this.heldBalls++;
        }
        actionCooldowns[6] = 3;
		return this.Damage/4;
	}

    public override int Skill4() {
        int max = Target[0].maxStamina;
        Target[0].loseStamina(Target[0].maxStamina / 4);
        this.heldBalls -= actionCosts[7];
        this.actionCooldowns[7] = 4;
        return max;
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
