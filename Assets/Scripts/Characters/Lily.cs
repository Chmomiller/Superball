using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lily : Character {

    void Start() {
        Name = "Lily";
        Catch = 100;
        Gather = 1;
        Stamina = maxStamina;
        heldBalls = 0;
        Capacity = 4;
        Role = "Supporter";

        actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Break Bread", "Cake Time", "Pretzel Knot", "" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Heals ally by 30 stamina", "Buffs both allies attack for 3 turns", "Weakens an enemy, halving their attack for 2 turns", "" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Utility", "Offense", "Offense", "Offense" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 1, 0, 2, 0 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 2, 0, 1, 0 };
        actionCosts = new int[] { 0, 1, 0, 0, 1, 3, 2, 0 };

		base.Start ();
    }

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
        if (Target[0].Stamina + 30 < Target[0].maxStamina) {
            Target[0].gainStamina(30);
        } else {
            Target[0].gainStamina(Mathf.Abs(Target[0].Stamina + 30 - Target[0].maxStamina));
        }
        actionCooldowns[4] = 3;
		return false;
    }

	public override bool Skill2() {
        for (int i = 0; i < 3; i++) {
            if (allies[i] != this) {
                allies[i].addStatusEffect("buff", 3);
            }
        }
        actionCooldowns[5] = 3;
		return false;
    }

	public override bool Skill3() {
            float variance = UnityEngine.Random.Range(.8f, 1.0f);
            Target[0].loseStamina((int)(this.Damage * variance));
            Target[0].addStatusEffect("debuff", 2);
        actionCooldowns[6] = 3;
		return false;
    }

    public override bool Skill4() {
		return false;
    }
}