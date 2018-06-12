using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mei : Character {
	int cleaning;
    // Use this for initialization
    new void Start() {
        Name = "Mei";
        Stamina = maxStamina;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Silver Platter", "Clean Up", "Cup of Tea", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
										  "Give half of your ball count to each of your allies.\nCost: Varies    Target: Ally Team",
                                          "Gather half of the balls used this turn at the end of the round. <color=red>1</color> turn cooldown.\nCost: None    Target: Self", 
										  "Heal an ally for 20% of their stamina and remove all status effects on them. <color=red>2</color> turn cooldown.\nCost: None    Target: Single Ally", 
										  "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 2, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };

		cleaning = 0;

		base.Start ();
    }

    // Update is called once per frame
    new void Update () {
		base.Update ();
    }
		
	/*
	//PassOff here isnt an ability that can be selected, but rather a helper function to SilverPlatter 
	private void PassOff(Character target, int gift) {
		int diff = target.maxBalls - target.heldBalls;
		while (diff > 0 && this.heldBalls > 0) {
			target.heldBalls++;
			diff = Target[0].maxBalls - Target[0].heldBalls;
		}
	}
	*/

	// Silver Platter: Mei gives half her current ball count to each of her active allies
	public override int Skill1() {
		int gift = heldBalls;
		int count = 0;
		// Get the number of active allies
		for(int i = 0; i < 3; i++)
		{
			if(allies[i] != this && ! allies[i].dead)
			{
				count++;	
			}
		}
		// If there are 2 active allies give each half of your ball count
		if(count == 2)
		{
			for(int i = 0; i < 3; i++)
			{
				if(allies[i] != this)
				{
					if (gift == heldBalls) 
					{
						allies [i].heldBalls += (int)gift / 2;
						gift -= (int)gift / 2;
					} 
					else 
					{
						allies [i].heldBalls += gift;
					}
					if(allies[i].heldBalls > allies[i].maxBalls)
					{
						allies [i].heldBalls = allies [i].maxBalls;
					}
				}
			}
			heldBalls = 0;
		}
		// If there is 1 active ally give them half of your ball count
		else if(count == 1)
		{
			for (int i = 0; i < 3; i++) 
			{
				if (allies[i] != this && !allies[i].dead) 
				{
					allies [i].heldBalls += (int)gift / 2;
					gift -= (int)gift / 2;
				} 
			}
			heldBalls = gift;
		}
		// If there are no active allies do nothing
		return 0;
    }
		
	// Clean-Up: Gather an amount of balls equal to half the balls spent on actions last turn(?)
	// 
	// Currently there is a problem if Mei isn't already in the last position: that whoever she swaps with effectively loses their action
	public override int Skill2() {
		int cleanUp = 0;
		for(int i = 0; i < 6; i++)
		{
			if(combat.combatQueue[i] != this)
			{
				for(int j = 0; j < combat.combatQueue[i].actionCosts.Length; j++)
				{
					if(combat.combatQueue[i].actions[j] == combat.combatQueue[i].action)
					{
						cleanUp += combat.combatQueue [i].GetActionCost (j);
					}
				}
			}
		}
		heldBalls += cleanUp / 2;
		if(heldBalls > maxBalls)
		{
			heldBalls = maxBalls;
		}
        this.actionCooldowns[5] = 2;
		return 0;
    }


	public override int Skill3() {
		Target [0].gainStamina (Target[0].maxStamina/5);
        for(int i =0; i<Target[0].statusEffects.Length; i++) {
            Target[0].statusEffects[i].duration = 0;
        }
        Target[0].removeDoneStatusEffects();
        this.actionCooldowns[6] = 3;
		return 0;
    }

	public override int Skill4() {
		return 0;
    }

	public override void cleanUp()
	{
		base.cleanUp ();

		// This collects all balls she cleaned up during the turn
		heldBalls += cleaning;
		cleaning = 0;
	}
}
