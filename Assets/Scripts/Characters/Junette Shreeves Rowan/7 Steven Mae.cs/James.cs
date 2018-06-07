using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class James : Character {
    
    new void Start() {  //affects art of other characters and their stats
        Name = "Artist James";
		Stamina = maxStamina;
        Role = "Thrower";
		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Art Upgrade", "Art Downgrade", "", "" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"Buffs your team and heals them a little", 
											"Debuffs enemy team and damages them a little", 
											"", 
											"" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Offense", "", "" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };

		base.Start ();
    }

    new void Update() {
		
    }
	// I haven't bothered to update the skill return values
	/*
    public override bool Skill1() {
        if (allies[0] != this) { allies[0].addStatusEffect("buff", 2); allies[0].Stamina += allies[0].maxStamina / 10; }
        if (allies[1] != this) { allies[1].addStatusEffect("buff", 2); allies[1].Stamina += allies[1].maxStamina / 10; }
        if (allies[2] != this) { allies[2].addStatusEffect("buff", 2); allies[2].Stamina += allies[2].maxStamina / 10; }
        this.actionCooldowns[4] = 4;
        return true;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override bool Skill2() {
        enemies[0].addStatusEffect("debuff", 2);
        enemies[0].loseStamina(enemies[0].maxStamina / 15);
        enemies[1].addStatusEffect("debuff", 2);
        enemies[1].loseStamina(enemies[1].maxStamina / 15);
        enemies[2].addStatusEffect("debuff", 2);
        enemies[2].loseStamina(enemies[2].maxStamina / 15);
        this.actionCooldowns[5] = 4;
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