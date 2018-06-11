using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skylar : Character {
    
    // Use this for initialization
    new void Start() {
        Name = "Skylar";
        Stamina = maxStamina;
        Role = "Supporter";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Bombing Run", "Supply Run", "Supply Drop", "Running Interference" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"Make all enemies <color=orange>unsteady</color> for 2 turns. <color=red>2</color> turn cooldown.\nCost: None    Target: Enemy Team",
                                            "Gather half of your max ball count. <color=red>2</color> turn cooldown.\nCost: None    Target: Self",
                                            "Heal an ally for 20 stamina and pass off all heald balls. <color=red>2</color> turn cooldown.\nCost: None    Target: Single Ally", 
											"<color=orange>Unsteady</color> and <color=blue>debuffed</color> enemy team for 1 turn. <color=red>3</color>\nCost: 3    Target: Enemy Team" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 2, 0 };
        actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 3 };
        
        base.Start ();
    }

    new void Update() {
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
	public override int Skill1() {
		enemies[0].addStatusEffect("unsteady", 3);
		enemies[1].addStatusEffect("unsteady", 3);
		enemies[2].addStatusEffect("unsteady", 3);
		actionCooldowns[4] = 3;
		return 0;
	}


	// Supply Run: Gather half of her remaining ball capacity
	public override int Skill2() {
		if(heldBalls != maxBalls)
		{
			this.heldBalls += (maxBalls - heldBalls) / 2;
		}
		actionCooldowns[5] = 3;
		return 0;
	}

	// Supply Drop: Gives all balls to an ally and heals them for 20
	public override int Skill3() {
		Target [0].heldBalls += this.heldBalls;
        if (Target [0].heldBalls > Target [0].maxBalls)
		{
			Target [0].heldBalls = Target [0].maxBalls;
		}
        if (this.Stamina > 20) { this.loseStamina(20); } else { this.loseStamina(19); }
		Target[0].gainStamina(20);
		
		this.heldBalls = 0;
		actionCooldowns[6] = 3;
		return 0;
	}

	// Currently does nothing because there is no support for confuse
    public override int Skill4() {
        this.heldBalls -= 3;
        enemies[0].addStatusEffect("unsteady", 2);
        enemies[1].addStatusEffect("unsteady", 2);
        enemies[2].addStatusEffect("unsteady", 2);
        enemies[0].addStatusEffect("debuff", 2);
        enemies[1].addStatusEffect("debuff", 2);
        enemies[2].addStatusEffect("debuff", 2);
        actionCooldowns[6] = 4;
		return 0;
    }

}
