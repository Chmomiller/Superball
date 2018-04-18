using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoichi : Character {

    void Start() {
        Name = "Yoichi";
        
        Gather = 1;
        Stamina = maxStamina;
        
		maxBalls = 4;
        Role = "Supporter";

        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Friendly Spirit", "Reload", "X or O", "Eight Stages of Shooting" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Get of rid of unsteady and debuff effecs on ally", "Get 2 balls and recover 15 stamina", "Attack enemy 1.15x as strong. If the enemy's stamina is reduced below half you are buffed", "Attack an enemy with 1.25x damage but make yourself unsteady for 2 turns" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Offense", "Offense" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 1, 0, 2, 2 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 2, 0, 1, 1 };
        actionCosts = new int[] { 0, 1, 0, 0, 0, 0, 3, 2 };

		base.Start ();
    }

    // Update is called once per frame
    void Update() {
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
    }

	public override bool Skill1() {
        int statusEffectIndex = Target[0].findStatus("unsteady");
        if (statusEffectIndex != -1) {
            Target[0].statusEffects[statusEffectIndex].duration = 0;
            Target[0].removeDoneStatusEffects();
        }
        statusEffectIndex = Target[0].findStatus("debuff");
        if (statusEffectIndex != -1) {
            Target[0].statusEffects[statusEffectIndex].duration = 0;
            Target[0].removeDoneStatusEffects();
        }
        actionCooldowns[4] = 3;
		return false;
    }

	public override bool Skill2() {
        this.heldBalls += 2;
        if(this.heldBalls > this.maxBalls) { this.heldBalls = this.maxBalls; }
        actionCooldowns[5] = 2;
		return false;
    }

	public override bool Skill3() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if (Target[0].findStatus("unsteady") != -1) { variance *= 1.25f; } //if stunned do more damage
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * 1.15 * variance));
        }
        if (Target[0].Stamina - (int)((this.attack) * 1.15 * variance) < Target[0].maxStamina) {
            this.addStatusEffect("buff", 2);
        }
        actionCooldowns[6] = 2;
		return false;
    }

	public override bool Skill4() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * 1.25f * variance));
        }
        this.addStatusEffect("unsteady", 2);
        actionCooldowns[7] = 4;
		return false;
    }
}
