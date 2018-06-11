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

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Picket Fence", "Vines", "Planted Stance", "Rain Shield" };
        actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground",
                                          "<color=orange>Steady</color> a teammate for 2 turns. <color=red>2</color> turn cooldown.\nCost: None    Target: Single Ally",
                                          "<color=blue>Debuff</color> an enemy for <color=red>3</color> turns. <color=red>4</color> turn cooldown.\nCost: 3    Target: Single Enemy",
                                          "Become <color=orange>Steady</color> and reduce the cooldown on other skills by 2. <color=red>5</color> turn cooldown.\nCost: None    Target: Self",
                                          ""};
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Defense", "Defense", "Utility" , "Defense" };
		defaultTargetingTypes = new int[]{ 0, 1, 2, 0, 0, 1, 0, 0 };

		actionCosts = new int[]{ 0, 1, 0, 0, 2, 3, 0, 0 };
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


    public override int Skill1() {
        Target[0].addStatusEffect("steady", 3);
        this.heldBalls -= actionCosts[4];
        this.actionCooldowns[4] = 3;
        return 0;
    }

    public override int Skill2() {
        Target[0].addStatusEffect("debuff", 4);
        this.heldBalls -= actionCosts[5];
        this.actionCooldowns[5] = 4;
        return 0;
    }

    public override int Skill3() {
        this.addStatusEffect("steady", 3);
        for(int i = 0; i<this.statusEffects.Length; i++) {
            statusEffects[i].duration -= 2;
            if (statusEffects[i].duration < 0) statusEffects[i].duration = 0;
        }
        this.actionCooldowns[6] = 5;
        return 0;
    }
    /*
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
        actionCooldowns[5] = 4;
		return 0;
    }
    
	// Rain Shield: Blocks the first attack on the next two turns
    public override int Skill3() {
        this.addStatusEffect("steady", 2);

        if (this.actionCooldowns[4] > 2) { this.actionCooldowns[4] -= 2; } else { this.actionCooldowns[4] = 0; }
        if (this.actionCooldowns[5] > 2) { this.actionCooldowns[5] -= 2; } else { this.actionCooldowns[5] = 0; }
        if (this.actionCooldowns[7] > 2) { this.actionCooldowns[7] -= 2; } else { this.actionCooldowns[7] = 0; }
        return 0;
        }
        */
    public override int Skill4() {
        addStatusEffect("misc", 3);
        actionCooldowns[7] = 3;
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
		Gather = 1;
		maxStamina = 130;
		maxBalls = 2;
		Level = 1;
		Experience = 0;
	}
}
