using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clemence : Character
{
    // Use this for initialization
    void Start()
    {
        Name = "Clemence";
		Damage = 1;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 10;
        heldBalls = 0;
        Role = "Catcher";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Picket Fence", "Vines", "Rain Shield", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Catches for both allies but not yourself", "enemy is blocked from throwing balls and must do something else next", "Blocks the first attack on the next two turns", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 2, 1, 0 };

        if (allegiance == 1) {
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            allies = combat.Enemy;
            enemies = combat.Player;
        }

    }

    void Update(){
        if (allegiance == 1) { //this is unique for Shiro, Clemence and Theodore as they are defaultly under player control
            this.targetingTypes = defaultTargetingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            this.targetingTypes = alternateTargetingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
    }
	
    public override void Skill1() {
        int catchAttempts = 0;
        for (int i = 3; i < combat.Enemy.Length; i++) {
            if (combat.Enemy[i].Target == combat.Player[0]) {
                combat.Enemy[i].Target = this;
                combat.Enemy[i].action = "THROW";
                catchAttempts++;
            }
            if (combat.Enemy[i].Target == combat.Player[1]) {
                combat.Enemy[i].Target = this;
                combat.Enemy[i].action= "THROW";
                catchAttempts++;
            }
        }
        for (int i = 0; i < catchAttempts; i++) {
            this.catchBall(this);
        }
        actionCooldowns[4] = 1; //Where N is the ability number-1

    }

    public override void Skill2() {
        while (Target.actionType == "Offensive") {
            // have them re choose or give them a random other ability. IDK
        }
        actionCooldowns[4] = 4;
    }

    public override void Skill3() {
        if (combat.Enemy[3].actionType == "Offensive") {
            combat.Enemy[3].action = "NONE";
            combat.Enemy[3].heldBalls--;
        } else if (combat.Enemy[3].actionType == "Offensive") {
            combat.Enemy[3].action = "NONE";
            combat.Enemy[3].heldBalls--;
        } else if (combat.Enemy[3].actionType == "Offensive") {
            combat.Enemy[3].action = "NONE";
            combat.Enemy[3].heldBalls--;
        }
        actionCooldowns[5] = 2;
    }

    public override void Skill4() {

    }

}
