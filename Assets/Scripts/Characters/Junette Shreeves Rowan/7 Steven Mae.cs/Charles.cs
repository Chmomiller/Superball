using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charles : Character {
    
    void Start() { //motivating your team
        Name = "Game Lead Charles";
		Stamina = maxStamina;
        Role = "Supporter";
		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Unify Team", "Motivate", "", "" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"Reduces ally damage taken and heals them a modest ammount", 
											"Buffs ally damage for a long time", 
											"", 
											"" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "", "" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 1, 1, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 2, 2, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };

		base.Start ();
    }

    void Update() {
		
    }
	// I haven't bothered to update the skill return values
	/*
	// Reactive Armor: If he is attacked on this turn, catch the ball and become steady
    public override bool Skill1() {
        Target[0].addStatusEffect("steady", 3);
        Target[0].Stamina += Target[0].maxStamina / 8;
        this.actionCooldowns[4] = 5;
        return true;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override bool Skill2() {
        Target[0].addStatusEffect("buff", 4);
        this.actionCooldowns[5] = 6;
		return true;
    }

	// Heavy Bombardment: Charges for a turn then attacks with a powerful strike against all enemies and becomes staggered
    public override bool Skill3() {
		return true;
    }

    public override bool Skill4() {
        return false;
    }

	public override void cleanUp(){
	}
	*/
}