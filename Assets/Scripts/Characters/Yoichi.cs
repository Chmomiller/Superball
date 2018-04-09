using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yoichi : Character {

    void Start() {
        Name = "Yoichi";
        Damage = 1;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 10;
        heldBalls = 0;
        Role = "Supporter";

        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Friendly Spirit", "Reload", "X or O", "Eight Stages of Shooting" };
        actionDescription = new string[] { "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Get of rid of unsteady and debuff effecs on ally", "Get 2 balls and recover 15 stamina", "Attack enemy 1.15x as strong. If the enemy's stamina is reduced below half you are buffed", "Attack an enemy with 1.25x damage but make yourself unsteady for 2 turns" };
        actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Offense", "Offense" };
        defaultTargetingTypes = new int[] { 0, 2, 0, 0, 1, 0, 2, 2 };
        alternateTargetingTypes = new int[] { 0, 1, 0, 0, 2, 0, 1, 1 };
        actionCosts = new int[] { 0, 1, 0, 0, 0, 0, 3, 2 };
    }

    // Update is called once per frame
    void Update() {
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

    public override void Skill1() {
        int statusEffectIndex = Target.findStatus("unsteady");
        if (statusEffectIndex != -1) {
            Target.statusEffects[statusEffectIndex].duration = 0;
            Target.removeDoneStatusEffects();
        }
        statusEffectIndex = Target.findStatus("debuff");
        if (statusEffectIndex != -1) {
            Target.statusEffects[statusEffectIndex].duration = 0;
            Target.removeDoneStatusEffects();
        }
        actionCooldowns[4] = 3;
    }

    public override void Skill2() {
        this.heldBalls += 2;
        if(this.heldBalls > this.maxBalls) { this.heldBalls = this.maxBalls; }
        actionCooldowns[5] = 2;
    }

    public override void Skill3() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        if (Target.findStatus("unsteady") != -1) { variance *= 1.25f; } //if stunned do more damage
        Target.dodgeBall((int)((this.attack)* 1.15 * variance));
        if(Target.Stamina - (int)((this.attack) * 1.15 * variance) < Target.maxStamina) {
            this.addStatusEffect("buff", 2);
        }
        actionCooldowns[6] = 2;
    }

    public override void Skill4() {
        float variance = UnityEngine.Random.Range(.7f, 1.3f);
        Target.dodgeBall((int)((this.attack) * 1.25 * variance));
        this.addStatusEffect("unsteady", 2);
        actionCooldowns[7] = 4;
    }
}
