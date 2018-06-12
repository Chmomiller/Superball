using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trevor : Character {
	
    // Use this for initialization
    new void Start() {
        Name = "Trevor";
        Role = "Thrower";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Thrash", "Riled Up", "Taunt", "Blowbeat" };
		actionDescription = new string[]{ "Wait", "Throw ball at Target enemy", "Attempt to catch any incoming balls", "Gather balls",
										  "Throw a ball at 3 random enemies. These targets can be attacked more than once. <color=red>2</color> turn cooldown\n Cost: 3    Target: Enemy Team", 
										  "Get <color=red>buffed</color> for 2 turns. <color=red>3</color> turn cooldown.\nCost: None    Target: Self",
                                          "<color=red>Buff</color> an enemy but make them <color=orange>unsteady</color> for 2 turns. <color=red>3</color> turn cooldown.\nCost: None    Target: Single Enemy",
										  "Attack an ally but <color=red>buff</color> and <color=lime>steady</color> them for 2 turns. <color=red>2</color> turn cooldown.\nCost: 3    Target: single Ally" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Utility", "Utility", "Offense" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 1, 2 }; 
		actionCosts = new int[]{ 0, 1, 0, 0, 3, 0, 0, 3 };

		base.Start ();
    }

    // Update is called once per frame
    new void Update() {
		base.Update ();
	}


	// Thrash: Throws 3 balls at three random Target[0]s on your team. 1 turn cooldown. Cost: 3 balls
    // Currently doesn't allow players to res off of a catch from this skill
	public override int Skill1()
	{
		int damage = 0;
		for (int i = 0; i < 3; i++) 
		{
			do{
				int aim = UnityEngine.Random.Range (0, 3);
				Target[i] = enemies[aim];
				if(!Target[i].dead)
				{
					break;
				}
			}while(!Target[i].dead);
		}

		for (int i = 0; i < 3; i++) 
		{
			for(int j = 0; j < 3; j++)
			{
				if(enemies[j].Target[0] == Target[i] && enemies[j].actionType == "Defense")
				{
					Target [i] = enemies [j];
				}
			}
		}

		// Throw at the three targets
		for(int i =0 ; i < 3; i++)
		{
			damage += this.throwBall (Target[i]);
		}
	    actionCooldowns[4] = 3;

		return damage;
    }


	//Skill1
    public override int Skill2() {
		this.addStatusEffect(STATUS.BUFF, 3);
        actionCooldowns[5] = 4;
        return 0;
    }

    /*
	public override int Skill2()
	{
		int damage = 0;
		for (int i = 0; i < 3; i++) 
		{
			do{
				int aim = UnityEngine.Random.Range (0, 3);
				Target[i] = enemies[aim];
			}while(!Target[i].dead);
		}

		for (int i = 0; i < 3; i++) 
		{
			for(int j = 0; j < 3; j++)
			{
				if(enemies[j].Target[0] == Target[i] && enemies[j].actionType == "Defense")
				{
					Debug.Log (enemies[j].Name+" is blocking for "+Target[i].Name);
					Target [i] = enemies [j];
				}
			}
		}

		// Throw at the three targets
		for(int i =0 ; i < 3; i++)
		{
			damage += this.throwBall (Target[i]);
		}
		actionCooldowns[4] = 1;

		return damage;
	}
    */
    // Skill3

    public override int Skill3() {
		Target[0].addStatusEffect(STATUS.BUFF, 2);
		Target[0].addStatusEffect(STATUS.UNSTEADY, 3);
        actionCooldowns[6] = 4;
        return 0;
    }
    /*
    public override int Skill3()
	{
		int damage = 0;
		for (int i = 0; i < 3; i++) 
		{
			do{
				int aim = UnityEngine.Random.Range (0, 3);
				Target[i] = enemies[aim];
				if(!Target[i].dead)
				{
					break;
				}
			}while(!Target[i].dead);
		}

		for (int i = 0; i < 3; i++) 
		{
			for(int j = 0; j < 3; j++)
			{
				if(enemies[j].Target[0] == Target[i] && enemies[j].actionType == "Defense")
				{
					Target [i] = enemies [j];
				}
			}
		}

		// Throw at the three targets
		for(int i =0 ; i < 3; i++)
		{
			damage += this.throwBall (Target[i]);
		}
		actionCooldowns[4] = 1;

		return damage;
	}
    */
    public override int Skill4() {
        this.throwBall(Target[0]);
		Target[0].addStatusEffect(STATUS.BUFF, 3);
		Target[0].addStatusEffect(STATUS.STEADY, 3);
		this.heldBalls -= this.actionCosts[7];
        this.actionCooldowns[7] = 3; 
        return this.Damage;
    }

}
