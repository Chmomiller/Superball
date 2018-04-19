using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skylar : Character {
    
    // Use this for initialization
    void Start() {
        Name = "Skylar";
        Stamina = maxStamina;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Bombing Run", "Supply Run", "Supply Drop", "Running Interference" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"Make all enemies staggered", 
											"Gather half of your remaining ball capacity", 
											"Gives all balls to an ally and heals them for 20", 
											"Applies confusion to all enemies" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 2, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 2, 0, 0, 0 };
        //actionCosts = new int[]{ 0, 1, 0, 0, 2, 0, 4, 3 };
        actionCosts = new int[]{ 0, 0, 0, 0, 0, 0, 0, 0 };

        base.Start ();
    }

    void Update() {
		/*
        if (combat == null) {
            combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        } else {
            if (allegiance == 1) { 
                this.targetingTypes = alternateTargetingTypes;
                allies = combat.Player;
                enemies = combat.Enemy;
            } else {
                this.targetingTypes = defaultTargetingTypes;
                allies = combat.Enemy;
                enemies = combat.Player;
            }
        }
        */
		base.Update ();
    }
		
	// Bombing Run: Make all enemies staggered
	public override bool Skill1() {
		enemies[0].addStatusEffect("unsteady", 3);
		enemies[1].addStatusEffect("unsteady", 3);
		enemies[2].addStatusEffect("unsteady", 3);
		this.heldBalls -= actionCosts[4];
		actionCooldowns[4] = 6;
		return true;
	}


	// Supply Run: Gather half of her remaining ball capacity
	public override bool Skill2() {
		if(heldBalls != maxBalls)
		{
			this.heldBalls += (maxBalls - heldBalls) / 2;
		}
		actionCooldowns[5] = 20;
		return true;
	}

	// Supply Drop: Gives all balls to an ally and heals them for 20
	public override bool Skill3() {
		Target [0].heldBalls += this.heldBalls;
		if (Target [0].heldBalls > Target [0].maxBalls)
		{
			Target [0].heldBalls = Target [0].maxBalls;
		}
		Target[0].gainStamina(20);
		this.Stamina -= 20;
		this.heldBalls = 0;
		actionCooldowns[6] = 3;
		return true;
	}

	//
    public override bool Skill4() {
        this.heldBalls -= 3;
        enemies[0].addStatusEffect("confuse", 3);
        enemies[1].addStatusEffect("confuse", 3);
        enemies[2].addStatusEffect("confuse", 3);
        actionCooldowns[6] = 4;
		return true;
    }

}
