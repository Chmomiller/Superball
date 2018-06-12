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
										  "Hands refreshments to one teammate, healing 1/4 of their maximum stamina. <color=red>3</color> turn cooldown.\nCost: None    Target: Single Ally", 
										  "All teammates are <color=#00ff00ff>steadied</color> for 2 turns. <color=red>4</color> turn cooldown.\nCost: None    Target: Ally Team", 
										  "All teammates are <color=blue>buffed</color> for two turns.  <color=red>4</color> turn cooldown.\nCost: None    Target: Ally Team" };
	    actionTypes = new string[] { "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility" };
	    actionCosts = new int[] { 0, 1, 0, 1, 0, 0, 0, 0 };
	    defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 2, 2, 0, 0 };
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

	public override int Skill1() // Pass Off: Gives all balls to a single teammate up to their max
    {
        while (this.heldBalls > 0 && Target[0].heldBalls < Target[0].maxBalls) {
            this.heldBalls--;
            Target[0].heldBalls++;
        }
		return 0;
    }

	// Refreshments: 
    public override int Skill2() {
        Target[0].Stamina += Target[0].maxStamina / 4;
        if (Target[0].Stamina > Target[0].maxStamina) {
            Target[0].Stamina = Target[0].maxStamina;
        }
        actionCooldowns[5] = 4; //where N is assuming this is the N+1th ability.
		return 0;
    }

	// Keep Fighting:
    public override int Skill3() { //keep fighting
		for(int i = 0; i < 3; i++)
		{
			if (allies[i] != this && !allies[i].dead) {
				allies[i].addStatusEffect(STATUS.UNSTEADY, 2);
			}
		}
        actionCooldowns[6] = 4; //where N is assuming this is the N+1th ability.
		return 0;
    }

	public override void ResetChar()
	{
		Damage = 10;
		Gather = 2;
		maxStamina = 140;
		maxBalls = 4;
		Level = 1;
		Experience = 0;
	}
}