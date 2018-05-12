using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kazuto : Character {

    new void Start() {
        Name = "Kazuto";
        Stamina = maxStamina;
        
        Role = "Thrower";

        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Flurry", "Slash", "Cleave", "One Stroke" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Attacks all enemies with an 0.75 strength attack", "Attack an enemy with a 75% of making them unsteady", "If the enemy is unsteady, this tatck has 1.25x damage", "attacks enemy with 1.75x strike but debuffs you for 2 turns" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense", "Offense" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 0, 2, 2, 2 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 0, 1, 1, 1 };
        actionCosts = new int[] { 0, 1, 0, 0, 2, 2, 1, 4 };

		base.Start ();
    }

    // Update is called once per frame
    new void Update() {
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
	// I haven't bothered to update the skill return values
	/*
	public override bool Skill1() {
        float variance;
        for (int i = 0; i < 3; i++) {
            variance = UnityEngine.Random.Range(.7f, 1.3f);
            if (!enemies[i].dodgeBall(this)) {
                Target[0].loseStamina((int)((this.attack) * 0.75f * variance));
            }
        }
        actionCooldowns[4] = 2;
		return false;
    }

	public override bool Skill2() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * variance));
        }
        if (UnityEngine.Random.Range(0, 4) > 3) {
            Target[0].addStatusEffect("unsteady", 2);
        }
        actionCooldowns[5] = 3;
		return false;
    }

	public override bool Skill3() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if(Target[0].findStatus("unsteady") != -1) { variance *= 1.25f; } //if stunned do more damage
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * variance));
        }
        actionCooldowns[6] = 2;
		return false;
    }

	public override bool Skill4() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if (!Target[0].dodgeBall(this)) {
            Target[0].loseStamina((int)((this.attack) * 1.75 * variance));
        }
        this.addStatusEffect("debuff", 2);
        actionCooldowns[7] = 4;
		return false;
    }
	*/
}
