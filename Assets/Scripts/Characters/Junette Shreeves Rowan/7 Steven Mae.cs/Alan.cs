using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alan : Character {
    
    void Start() {  //direct damage that cannot be blocked
        Name = "Game Lead Alan";
		Stamina = maxStamina;
        Role = "Catcher";
		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Team Checkup", "Deadline", "", "" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"Debuffs enemy team", 
											"Strong and unblockable damage", 
											"", 
											"" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Offense", "", "" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 2, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };

		base.Start ();
    }

    void Update() {
		
    }

	// Reactive Armor: If he is attacked on this turn, catch the ball and become steady
    public override bool Skill1() {
        enemies[0].addStatusEffect("debuff", 2);
        enemies[1].addStatusEffect("debuff", 2);
        enemies[2].addStatusEffect("debuff", 2);
        return true;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override bool Skill2() {
        float variance = UnityEngine.Random.Range(1.0f, 1.7f);
        Target[0].loseStamina(this.Damage * (int)variance);
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
}