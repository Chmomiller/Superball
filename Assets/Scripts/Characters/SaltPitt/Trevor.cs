using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trevor : Character {
	
    // Use this for initialization
    new void Start() {
        Name = "Trevor";
        Role = "Thrower";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Thrash", "Riled Up", "Skill3", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at Target enemy", "Attempt to catch any incoming balls", "Gather balls",
                                          "Choose <color = red>3 random targets on the enemy team and throw one ball at each. These targets can be the same more than once.", 
										  "Target is <i>blocked</i> from throwing balls and must do something else next", 
										  "Blocks the first attack on the next <color = red>2 turns", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Utility", "Utility", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 1, 0, 0 }; 
		alternateTargetingTypes = new int[]{ 0, 2, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 3, 0, 0, 0 };

		base.Start ();
    }

    // Update is called once per frame
    new void Update() {
		base.Update ();
		/*
        if (allegiance == 1) {
            this.Target[0]Types = alternateTarget[0]ingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else{
            this.Target[0]Types = defaultTarget[0]ingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
        */
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


	//Skill1
    public override int Skill2() {
        this.addStatusEffect("buffed", 3);
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
        Target[0].addStatusEffect("buff", 3);
        Target[0].addStatusEffect("unsteady", 2);
        actionCooldowns[5] = 4;
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
    public override int Skill4() {
        this.throwBall(Target[0]);
        Target[0].addStatusEffect("buff", 3);
        Target[0].addStatusEffect("steady", 3);
        this.heldBalls -= 3;
        this.actionCooldowns[6] = 3; 
        return this.Damage;
    }

}
