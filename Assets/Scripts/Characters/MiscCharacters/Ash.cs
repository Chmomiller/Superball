using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ash : Character {

    new void Start() {
        Name = "Ash";
        Stamina = maxStamina;
        Role = "Catcher";
        
        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Meat Shield", "Swineflesh", "Fiery Masterpiece", "" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Halves damage you take for 1 turn", "Buffs yourself and gives 20 stamina", "Hit an enemy with a 1.5x attack with a chance to debuff", "" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Offense", "Offense" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 0, 0, 2, 0 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 0, 0, 1, 0 };
        actionCosts = new int[] { 0, 1, 0, 0, 2, 3, 5, 0 };
    }

    new void Update() {
        if (combat == null) {
            combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        } else {
            if (allegiance == 1) { //this is unique for Shiro, Clemence and Theodore as they are defaultly under player control
                this.targetingTypes = alternateTargetingTypes;
                allies = combat.Player;
                enemies = combat.Enemy;
            } else {
                this.targetingTypes = defaultTargetingTypes;
                allies = combat.Enemy;
                enemies = combat.Player;
            }
        }
    }
	// I haven't bothered to update the skill return values
	/*
    public override int Skill1() {
        this.addStatusEffect("halfDmg", 1);
        actionCooldowns[4] = 3;
		return false;
    }

	public override bool Skill2() {
        this.addStatusEffect("buff", 3);
        if(this.Stamina +20 < this.maxStamina) {
            this.gainStamina(20);
        } else {
            this.gainStamina(Mathf.Abs(this.Stamina + 20 - this.maxStamina));
        }
        actionCooldowns[2] = 3;
		return false;
    }

	public override bool Skill3() {
        float variance = UnityEngine.Random.Range(.8f, 1.2f);
        Target[0].loseStamina((int)(this.Damage * 1.5f * variance));
        if (Random.Range(0, 10) > 6){Target[0].addStatusEffect("debuff", 2); }
        actionCooldowns[6] = 3;
		return false;
    }

	public override bool Skill4() {
		return false;
    }
    */
}