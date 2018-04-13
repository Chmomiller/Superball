using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clemence : Character
{

    // Use this for initialization
    void Start()
    {
        Name = "Clemence";
		Damage = 10;
        Catch = 100;
        Capacity = 4;
        Gather = 1;
        Stamina = 120;
		maxStamina = 120;
        heldBalls = 0;
        Role = "Catcher";
		actions = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Picket Fence", "Vines", "Rain Shield", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at Target[0] enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Catches for both allies but not yourself", "enemy is blocked from throwing balls and must do something else next", "Blocks the first attack on the next two turns", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 2, 0, 0 };

		actionCosts = new int[]{ 0, 1, 0, 0, 0, 2, 1, 0 };
		base.Start ();
    }
    /*
    void Update(){
        combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        if (combat != null) {
            if (allegiance == 1) { //this is unique for Shiro, Clemence and Theodore as they are defaultly under player control
                this.Target[0]ingTypes = defaultTarget[0]ingTypes;
                allies = combat.Player;
                enemies = combat.Enemy;
            } else {
                this.Target[0]ingTypes = alternateTarget[0]ingTypes;
                allies = combat.Enemy;
                enemies = combat.Player;
            }
        }
   //     this should be set in battle simulator
    }
    */
	
    public override bool Skill1() {
        int catchAttempts = 0;
        for (int i = 3; i < combat.Enemy.Length; i++) {
            if (enemies[i].Target[0] == allies[0]) {
                enemies[i].Target[0] = this;
                enemies[i].action = "THROW";
                catchAttempts++;
            }
            if (enemies[i].Target[0] == allies[1]) {
                enemies[i].Target[0] = this;
                enemies[i].action= "THROW";
                catchAttempts++;
            }
        }
        for (int i = 0; i < catchAttempts; i++) {
            this.catchBall(this);
        }
        actionCooldowns[4] = 1; //Where N is the ability number-1
		return true;

    }

    public override bool Skill2() {
        while (Target[0].actionType == "Offensive") {
            // have them re choose or give them a random other ability. IDK
        }
        actionCooldowns[4] = 4;
		return true;
    }

    public override bool Skill3() {
        if (enemies[0].actionType == "Offensive") {
            enemies[0].action = "NONE";
            enemies[0].heldBalls--;
        } else if (enemies[1].actionType == "Offensive") {
            enemies[1].action = "NONE";
            enemies[1].heldBalls--;
        } else if (enemies[2].actionType == "Offensive") {
            enemies[2].action = "NONE";
            enemies[2].heldBalls--;
        }
        actionCooldowns[5] = 2;
		return true;
    }

    public override bool Skill4() {
		return true;
    }

}
