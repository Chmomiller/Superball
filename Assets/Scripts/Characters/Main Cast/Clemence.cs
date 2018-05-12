using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clemence : Character
{

    // Use this for initialization
    new void Start()
    {
        Name = "Clemence";
        
        Gather = 1;
        Stamina = maxStamina;
        
        //heldBalls = 0;
        Role = "Catcher";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Picket Fence", "Vines", "Rain Shield", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", 
										  "Catches for both allies but not yourself", 
										  "If enemy is throwing, they are stunned", 
										  "Blocks the first attack on the next two turns", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility" , "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 2, 0, 0, 1, 0 };

		actionCosts = new int[]{ 0, 1, 0, 0, 0, 2, 1, 0 };
		base.Start ();
    }

    new void Update(){
		base.Update ();
    }
    
	// Picket Fence: Catches for both allies but not yourself
	public override int Skill1() {
        int catchAttempts = 0;
        for (int i = 3; i < combat.Enemy.Length; i++) {
			// This doesn't necessarily check if allies 0 & 1 are not this character
			if ((enemies[i].Target[0] == allies[0] || enemies[i].Target[0] == allies[1])
				&& enemies[i].actionType == "Offense") {
                enemies[i].Target[0] = this;
                catchAttempts++;
            }
        }
        for (int i = 0; i < catchAttempts; i++) {
            this.catchBall(this);
        }
        actionCooldowns[4] = 1; //Where N is the ability number-1
		return 0;

    }

	// Vines: If enemy is throwing, they are stunned
    public override int Skill2() {
        if (Target[0].actionType == "Offense") {
			Target [0].addStatusEffect ("stun", 1);
        }
        actionCooldowns[4] = 4;
		return 0;
    }

	// Rain Shield: Blocks the first attack on the next two turns
    public override int Skill3() {
        if (enemies[0].actionType == "Offense") {
            enemies[0].action = "None";
            enemies[0].heldBalls--;
        } else if (enemies[1].actionType == "Offense") {
            enemies[1].action = "None";
            enemies[1].heldBalls--;
        } else if (enemies[2].actionType == "Offense") {
            enemies[2].action = "None";
            enemies[2].heldBalls--;
        }
        actionCooldowns[5] = 2;
		return -1;
    }

    public override int Skill4() {
		return 0;
    }

}
