using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theo : Character {
    
    void Start() { //attacks affecting character script and its components
        Name = "Programmer Theo";
		Stamina = maxStamina;
        Role = "Thrower";
		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Status Swap", "Equalizer", "Power Drain", "" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"Gains buffs of target enemy and gives them your debuffs", 
											"Deals damage based upon target stats", 
											"Target loses a level and you gain one", 
											"" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Utility", "" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 2, 2, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 1, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };

		base.Start ();
    }

    void Update() {
		
    }
	// I haven't bothered to update the skill return values
	/*
	// Reactive Armor: If he is attacked on this turn, catch the ball and become steady
    public override bool Skill1() {
        if (Target[0].findStatus("buff") != 0) {
            this.addStatusEffect("buff", Target[0].statusEffects[Target[0].findStatus("buff")].duration); // you gain the buff and duration they had
            Target[0].removeStatusEffect("buff");
        }
        if (Target[0].findStatus("steady") != 0) {
            this.addStatusEffect("steady", Target[0].statusEffects[Target[0].findStatus("steady")].duration); // you gain the buff and duration they had
            Target[0].removeStatusEffect("steady");
        }
        if (this.findStatus("debuff") != 0) {
            Target[0].addStatusEffect("debuff", this.statusEffects[this.findStatus("buff")].duration); // you gain the buff and duration they had
            this.removeStatusEffect("debuff");
        }
        if (this.findStatus("unsteady") != 0) {
            Target[0].addStatusEffect("unsteady", this.statusEffects[this.findStatus("buff")].duration); // you gain the buff and duration they had
            this.removeStatusEffect("debuff");
        }
        this.actionCooldowns[4] = 4;
        return true;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override bool Skill2() {
        Target[0].loseStamina( (int)( (Target[0].Damage + this.Damage) / 1.5 ) );
        this.actionCooldowns[5] = 2;
        return true;
    }

	// Heavy Bombardment: Charges for a turn then attacks with a powerful strike against all enemies and becomes staggered
    public override bool Skill3() {
        Target[0].Level--;
        Target[0].Damage = (int)(Target[0].Damage * 0.9f);
        Target[0].maxStamina = (int)(Target[0].maxStamina*0.9f);
        Target[0].Stamina *= (int)(Target[0].Stamina * 0.9f); //might be too strong
        if (Target[0].maxStamina < Target[0].Stamina) Target[0].Stamina = Target[0].maxStamina;
        if (Target[0].Level % 2 == 1) Target[0].maxBalls--;;
        this.LevelUp(1);
        this.actionCooldowns[6] = 3;
        return true;
    }

    public override bool Skill4() {
        return false;
    }

	public override void cleanUp(){
	}
	*/
}