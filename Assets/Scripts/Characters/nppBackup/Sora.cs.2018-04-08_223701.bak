using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sora : Character {
    
    // Use this for initialization
    void Start() {
        Name = "default";
        Damage = 1;
        Catch = 100;
        Gather = 1;
        Stamina = 10;
        maxStamina = 10;
        heldBalls = 0;
        Capacity = 4;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Supply Drop", "Ultimate Support", "Eye in the Sky", "Running Interference" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Provides balls and stamina to ally", "Fully heals all allies and buffs them", "debuffs enemy team dodge", "Applies confusion to all enemies" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 2, 3, 4, 3 };
    }

    void Update() {
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

    public override void Skill1() {
        this.heldBalls -= 2;
        Target.heldBalls += 3;
        if (Target.heldBalls > Target.Capacity) Target.heldBalls = Target.Capacity;
        Target.Stamina += 20;
        actionCooldowns[4] = 3;
    }

    public override void Skill2() {
        this.heldBalls -= 5;
        allies[0].Stamina = enemies[0].maxStamina;
        allies[0].addStatusEffect("buff",3);

        allies[1].Stamina = enemies[1].maxStamina;
        allies[1].addStatusEffect("buff", 3);
        actionCooldowns[5] = 20;
    }

    public override void Skill3() {
        this.heldBalls -= 4;
        enemies[0].addStatusEffect("unsteady", 3);
        enemies[1].addStatusEffect("unsteady", 3);
        enemies[2].addStatusEffect("unsteady", 3);
        actionCooldowns[6] = 6;
    }

    public override void Skill4() {
        this.heldBalls -= 3;
        enemies[0].addStatusEffect("confuse", 3);
        enemies[1].addStatusEffect("confuse", 3);
        enemies[2].addStatusEffect("confuse", 3);
        actionCooldowns[6] = 4;
    }

}
