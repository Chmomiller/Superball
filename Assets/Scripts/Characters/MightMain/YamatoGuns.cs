using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamatoGuns : Yamato {
	
    
    new void Start() {
        Name = "The Gun";
        Stamina = maxStamina;
        Role = "Thrower";

        actionNames = new string[] { "None", "Throw", "Catch", "Gather", "Artillery Barrage", "Bombardment", "Skill3", "Skill4" };
        actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", 
										  "Fire at an enemy with a <b>heavy-hitting</b> attack that can't be caught. <color=red>2</color> turn cooldown.\nCost: 3    Target: Single Enemy", 
										  "Fire at 3 random enemies with a <i>weak</i> attack. <color=red>4</color> turn cooldown.\nCost: 3    Target: Enemy Team", 
										  "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offense", "Offense", "Offense", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 3, 3, 0, 0 };

		base.Start ();
    }

    new void Update() {
     
    }

    public override int Skill1() {
        Target[0] = Target[2];
        float variance = UnityEngine.Random.Range(1.7f, 2.2f);
		int damage = (int)(this.Damage * 1.25 * variance * attackMultiplier * Target [0].defenseMultiplier);
		Target [0].loseStamina (damage);
		this.heldBalls -= actionCosts[4];
        actionCooldowns[4] = 2;
		return damage;
    }

    public override int Skill2() {
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
		actionCooldowns[4] = 4;

		return damage;
    }
    public override int Skill3() {
		return 0;
}

	public override int Skill4() {
		return 0;
    }
}
