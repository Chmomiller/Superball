using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuro : Character {

    void Start() {
        Name = "Kuro";
        Damage = 1;
        Catch = 100;
        Gather = 1;
        Stamina = 10;
        maxStamina = 10;
        heldBalls = 0;
        Capacity = 4;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Ultimate Catch", "Skill2", "Skill3", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "", "", "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
    }

    // Update is called once per frame
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


    public void preUltimateCatch() {
        for (int i = 0; i < 3; i++) {
            if (combat.Player[i].actionType == "Offensive") {
                combat.Player[i].action = "Throw";
                combat.Player[i].Target[0] = this;
            }
        }
    }

    public override bool Skill1() {
        if (this.heldBalls < this.Capacity) { this.heldBalls++; }
        actionCooldowns[6] = 4;
		return true;
    }

	public override bool Skill2() { return true;}

	public override bool Skill3() { return true;}

	public override bool Skill4() { return true;}

}
