using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamatoGuns : Yamato {
	
    
    void Start() {
        Name = "The Main Armamment of the Imperial Japanese Battleship Yamato";
        Stamina = maxStamina;
        Role = "Thrower";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Artillery Barrage", "Bombardment", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Strong Ram", "Depth Charge", "Deep Torpedoes", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", 
										  "Hit an enemy with an attack at 1.5 strength", 
										  "Drops explosives off the front", "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 1, 1, 0, 0 };

		base.Start ();
    }

    void Update() {
     
    }

	public override int Skill1() {
        float variance = UnityEngine.Random.Range(1.7f, 2.2f);
		int damage = (int)(this.Damage * 1.25 * variance * attackMultiplier * Target [0].defenseMultiplier);
		Target [0].loseStamina (damage);
        this.heldBalls -= 3;
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
    public override int Skill3() {
		return 0;
}

	public override int Skill4() {
		return 0;
    }
}
