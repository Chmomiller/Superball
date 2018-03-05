using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiro : Character{

    void Start()
    {
        Name = "Shiro";
		Damage = 1;
        Catch = 50;
        Capacity = 8;
        Gather = 3;
        Stamina = 8;
        heldBalls = 0;
        maxBalls = 10;
        Role = "Support";
        
	    actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
	    actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Pass off all your balls to ally", "Heal ally for a 1/4 of max Stamina", "Reduces damage allies take for two turns", "" };
	    actionTypes = new string[] { "None", "Offense", "Defense", "utility", "Utility", "Utility", "Utility" };
	    actionCosts = new int[] { 0, 1, 0, 1, 0, 0, 0 };
	    defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 2, 2, 0, 0 };
	    alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 1, 1, 0, 0 };
    }
		
    // Update is called once per frame
    void Update()
    {
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

	public override void Skill1() //Pass off
    {

        while (this.heldBalls > 0 && Target.heldBalls < Target.maxBalls) {
            this.heldBalls--;
            Target.heldBalls++;
        }
        return;

    }

    public override void Skill2() {
        Target.Stamina += Target.maxStamina / 4;
        if (Target.Stamina > Target.maxStamina) {
            Target.Stamina = Target.maxStamina;
        }
        actionCooldowns[5] = 3; //where N is assuming this is the N+1th ability.
    }


    public override void Skill3() { //keep fighting
        if (allies[0] != this) {
            allies[0].addStatusEffect("halfDmg", 2);
        }
        if (allies[1] != this) {
            allies[1].addStatusEffect("halfDmg", 2);
        }
        if (allies[2] != this) {
            allies[2].addStatusEffect("halfDmg", 2);
        }
        actionCooldowns[6] = 4; //where N is assuming this is the N+1th ability.
    }


}