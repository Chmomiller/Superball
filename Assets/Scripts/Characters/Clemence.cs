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
		actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Picket Fence", "Vines", "Rain Shield", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Catches for both allies but not yourself", "enemy is blocked from throwing balls and must do something else next", "Blocks the first attack on the next two turns", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 0, 0 };

		actionCosts = new int[]{ 0, 1, 0, 0, 0, 2, 1, 0 };
    }
    /*
    void Update(){
        combat = GameObject.Find("EmptyCombatManagerPrefab").GetComponent<CombatManager>();
        if (combat != null) {
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
   //     this should be set in battle simulator
    }
    */
	
    public override void Skill1() {
        int catchAttempts = 0;
        for (int i = 3; i < combat.Enemy.Length; i++) {
            if (enemies[i].Target == allies[0]) {
                enemies[i].Target = this;
                enemies[i].action = "THROW";
                catchAttempts++;
            }
            if (enemies[i].Target == allies[1]) {
                enemies[i].Target = this;
                enemies[i].action= "THROW";
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
        if (enemies[3].actionType == "Offensive") {
            enemies[3].action = "NONE";
            enemies[3].heldBalls--;
        } else if (enemies[3].actionType == "Offensive") {
            enemies[3].action = "NONE";
            enemies[3].heldBalls--;
        } else if (enemies[3].actionType == "Offensive") {
            enemies[3].action = "NONE";
            enemies[3].heldBalls--;
        }
        actionCooldowns[5] = 2;
    }

    public override void Skill4() {

    }

}
