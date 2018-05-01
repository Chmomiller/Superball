using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shiro : Character{

    new void Start()
    {
        Name = "Shiro";
        Stamina = maxStamina;
        Role = "Support";
        
	    actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Pass Off", "Refreshments", "Keep Fighting", "Cheer On" };
	    actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
										  "Gives all balls to a single teammate up to their max.\nCost: Varies    Target: Single Ally", 
										  "Hands Blue Bison™ refreshments to one teammate, to recover 1/4 of their maximum stamina. <color=red>3</color> turn cooldown.\nCost: None    Target: Single Ally", 
										  "All teammates are <color=#00ff00ff>steadied</color> for 2 turns. <color=red>4</color> turn cooldown.\nCost: None    Target: Ally Team", 
										  "All teammates are <color=blue>buffed</color> for two turns.  <color=red>4</color> turn cooldown.\nCost: None    Target: Ally Team" };
	    actionTypes = new string[] { "None", "Offense", "Defense", "utility", "Utility", "Utility", "Utility" };
	    actionCosts = new int[] { 0, 1, 0, 1, 0, 0, 0, 0 };
	    defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 2, 2, 0, 0 };
	    alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 1, 1, 0, 0 };
		base.Start ();
    }
		
    // Update is called once per frame
    new void Update()
    {
		base.Update ();
		/*
        if (allegiance == 1) { //this is unique for Shiro, Clemence and Theodore as they are defaultly under player control
            this.targetingTypes = defaultTargetingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            this.targetingTypes = alternateTargetingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }*/
    }

	public override bool Skill1() //Pass off
    {
        while (this.heldBalls > 0 && Target[0].heldBalls < Target[0].maxBalls) {
            this.heldBalls--;
            Target[0].heldBalls++;
        }
		return false;
    }

    public override bool Skill2() {
        Target[0].Stamina += Target[0].maxStamina / 4;
        if (Target[0].Stamina > Target[0].maxStamina) {
            Target[0].Stamina = Target[0].maxStamina;
        }
        actionCooldowns[5] = 3; //where N is assuming this is the N+1th ability.
		return false;
    }


    public override bool Skill3() { //keep fighting
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
		return false;
    }


}