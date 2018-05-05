using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tristian : Character {
    
    void Start() { //Combat manager related skills
        Name = "Programmer Tristian";
		Stamina = maxStamina;
        Role = "Catcher";
		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Combat Pause", "Battle Prepartion", "Turn Manipulation", "" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"All players who have chosen actions, do nothing", 
											"Steadies all allies for 1 turn",
                                            "Allows allies to take an extra turn", 
											"" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };

		base.Start ();
    }

    void Update() {
		
    }
	// I haven't bothered to update the skill return values
	/*
	// Reactive Armor: If he is attacked on this turn, catch the ball and become steady
    public override bool Skill1() {
        if (allies[0].action != "None") allies[0].action = "None";
        if (allies[1].action != "None") allies[1].action = "None";
        if (allies[2].action != "None") allies[2].action = "None";
        if (enemies[0].action != "None") enemies[0].action = "None";
        if (enemies[1].action != "None") enemies[1].action = "None";
        if (enemies[2].action != "None") enemies[2].action = "None";
        this.actionCooldowns[3] = 4;
        return true;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override bool Skill2() {
        allies[0].addStatusEffect("steady", 1);
        allies[1].addStatusEffect("steady", 1);
        allies[2].addStatusEffect("steady", 1);
        this.actionCooldowns[4] = 3;
		return true;
    }

    //This resets the turns of both sides, but resets the cooldowns of the player team as if they didnt cast it
    public override bool Skill3() {
        //set to planning phase again
        if (allies[0] != this) {
            for (int i = 0; i < 7; i++) {
                if (allies[0].action == allies[0].actions[i]) { //find the action they chose and set cooldown to 0
                    allies[0].actionCooldowns[i] = 0;
                    break;
                }
            }
        }

        if (allies[1] != this) {
            for (int i = 0; i < 7; i++) {
                if (allies[1].action == allies[1].actions[i]) { //find the action they chose and set cooldown to 0
                    allies[1].actionCooldowns[i] = 0;
                    break;
                }
            }
        }

        if (allies[2] != this) {
            for (int i = 0; i < 7; i++) {
                if (allies[2].action == allies[2].actions[i]) { //find the action they chose and set cooldown to 0
                    allies[2].actionCooldowns[2] = 0;
                    break;
                }
            }
        }

        enemies[0].action = "None";
        enemies[1].action = "None";
        enemies[2].action = "None";

        this.actionCooldowns[5] = 6;
        return true;
    }

    public override bool Skill4() {
        return false;
    }

	public override void cleanUp(){
	}
	*/
}