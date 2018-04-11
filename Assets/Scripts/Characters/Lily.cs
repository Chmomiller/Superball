using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lily : Character {

    void Start() {
        Name = "Lily";
        Damage = 1;
        Catch = 100;
        Gather = 1;
        Stamina = 10;
        maxStamina = 10;
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

    public override void Skill1() {
        if (Target.Stamina + 30 < Target.maxStamina) {
            Target.gainStamina(30);
        } else {
            Target.gainStamina(Mathf.Abs(Target.Stamina + 30 - Target.maxStamina));
        }
        actionCooldowns[4] = 3;
    }

    public override void Skill2() {
        for (int i = 0; i < 3; i++) {
            if (allies[i] != this) {
                allies[i].addStatusEffect("buff", 3);
            }
        }
        actionCooldowns[5] = 3;
    }

    public override void Skill3() {
            float variance = UnityEngine.Random.Range(.8f, 1.0f);
            Target.loseStamina((int)(this.Damage * variance));
            Target.addStatusEffect("debuff", 2);
        actionCooldowns[6] = 3;
    }

    public override void Skill4() {
    }
}