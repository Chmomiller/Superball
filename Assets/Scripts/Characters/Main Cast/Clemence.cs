using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clemence : Character
{
	bool blocking = false;
	int startingHealth = 0;
	int catchAttempts = 0;
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
										  "Atempt to catch for both allies. <color=red>1</color> turn cooldown.\nCost: None    Target: Ally Team", 
										  "If target enemy is throwing, they are <color=yellow>stunned</color> for 1 turn. <color=red>3</color> turn cooldown.\nCost: None    Target: Single Enemy", 
										  "Block the first attack on the next two turns. <color=red>2</color> turn cooldown.\nCost: None    Target: Self", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Defense", "Defense", "Defense" , "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 2, 0, 0, 1, 0, 0 };

		actionCosts = new int[]{ 0, 1, 0, 0, 0, 2, 1, 0 };
		base.Start ();
    }

    new void Update(){
		base.Update ();
    }
    
	public new bool catchBall(Character attacker)
	{
		if(catchAttempts > 0)
		{
			catching = true;
		}
		return base.catchBall (attacker);
	}

	public new bool dodgeBall(Character attacker)
	{
		if (blocking) 
		{
			blocking = false;
			if(startingHealth > Stamina)
			{
				Stamina = startingHealth;
			}
			return false;
		}
		return base.dodgeBall (attacker);
	}

	// Picket Fence: Catches for both allies but not yourself
	public override int Skill1() {
		int count = 0;
		foreach(Character C in allies)
		{
			if(C != this)
			{
				Target [count] = C;
				count++;
			}
		}
        
        for (int i = 3; i < combat.Enemy.Length; i++) {
			if ((enemies[i].Target[0] == Target[0] || enemies[i].Target[0] == Target[1])
				&& enemies[i].actionType == "Offense" 
				&& allies[i] != this) {
                enemies[i].Target[0] = this;
            }
        }
		catchAttempts = 2;
        actionCooldowns[4] = 2; //Where N is the ability number-1
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
		addStatusEffect ("misc", 3);
        actionCooldowns[5] = 3;
		return 0;
    }

    public override int Skill4() {
		return 0;
    }

	new public void cleanUp()
	{
		base.cleanUp ();
		if(findStatus("misc") != -1)
		{
			blocking = true;
			startingHealth = Stamina;
		}
		catchAttempts = 0;
	}

	public override void ResetChar()
	{
		Damage = 10;
		Catch = 100;
		Gather = 1;
		maxStamina = 130;
		maxBalls = 2;
		Level = 1;
		Experience = 0;
	}
}
