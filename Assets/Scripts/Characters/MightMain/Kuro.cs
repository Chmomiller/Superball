using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuro : Character {

    void Start() {
        Name = "Kuro";
        Gather = 1;
        Stamina = maxStamina;
        maxBalls = 4;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Ultimate Catch", "Skill2", "Skill3", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "", "", "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Defense", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 3, 0 };

		base.Start ();
    }

    // Update is called once per frame
    void Update() {
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


    public void preUltimateCatch() {
        for (int i = 0; i < 3; i++) {
            if (combat.Player[i].actionType == "Offense") {
                combat.Player[i].action = "Throw";
                combat.Player[i].Target[0] = this;
            }
        }
    }

	// Smokescreen: Make yourself and allies steady
    public override bool Skill1() {
		for(int i = 0; i < 3; i++)
		{
			allies [i].addStatusEffect ("steady", 1);
		}
        actionCooldowns[4] = 3;
		return true;
    }

	// Safe Haven: Catch for the whole team
	public override bool Skill2() { 
		for(int i = 0; i < 3; i++)
		{
			if(enemies[i].actionType == "Offense")
			{
				enemies [i].Target [0] = this;
			}
		}
		actionCooldowns [5] = 2;
		return true;
	}

	// Lord of the Seven Seas: Charge up for a turn before unleashing an attack against all enemies
	public override bool Skill3() { 
		if(findStatus("misc") != -1)
		{
			for(int i = 0; i < 3; i++)
			{
				// This attack does stamina loss before checking for dodging
				enemies[i].loseStamina((int)(Damage * 1.5f));
				enemies [i].dodgeBall (this);
			}
		}
		else
		{
			addStatusEffect("misc", 2);
		}
		this.heldBalls -= actionCosts [6];
		actionCooldowns [6] = 3;
		return true;
	}

	public override bool Skill4() { return true;}

	public override void cleanUp()
	{
		base.cleanUp ();

		// If getting ready for skill 3 set action for next turn
		if(findStatus("misc") != -1)
		{
			action = "Skill3";
			actionType = "Offense";
		}
	}
}
