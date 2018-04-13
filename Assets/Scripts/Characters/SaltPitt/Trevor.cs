﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trevor : Character {
	
    // Use this for initialization
    void Start() {
        Name = "Trevor";
        Damage = 10;
        Catch = 25;
        Capacity = 8;
        Stamina = 70;
        heldBalls = 0;
        Role = "Thrower";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Thrash", "Skill2", "Skill3", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at Target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Throws at 3 random Targets", "enemy is blocked from throwing balls and must do something else next", "Blocks the first attack on the next two turns", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 }; 
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 3, 0, 0, 0 };
		base.Start ();
    }

    // Update is called once per frame
	/*
    bool Update() {
        if (allegiance == 1) {
            this.Target[0]ingTypes = alternateTarget[0]ingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else{
            this.Target[0]ingTypes = defaultTarget[0]ingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
	}
	*/

	// Thrash: Throws 3 balls at three random Target[0]s on your team. 1 turn cooldown. Cost: 3 balls
    // Currently doesn't allow players to res off of a catch from this skill
	public override bool Skill1()
    {
        float variance;
        for (int i = 0; i < 3; i++) {
            variance = UnityEngine.Random.Range(0.8f, 1.2f);
            Target[i] = this.enemies[UnityEngine.Random.Range(0, 3)];				
	    }
		for (int i = 0; i < 3; i++) 
		{
			for(int j = 0; j < 3; )
			{
				if(enemies[j].Target[0] == Target[i] && enemies[j].actionType == "Defense")
				{
					Target [i] = enemies [j];
				}
			}
		}
		for(int i =0 ; i < 3; i++)
		{
			combat.DoAction (this, "Throw");
		}
	    actionCooldowns[4] = 1;
		return false;
    }
}