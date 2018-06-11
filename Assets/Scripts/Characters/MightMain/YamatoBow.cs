using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamatoBow : Yamato {
	
    
    new void Start() {
        Name = "The Bow";
        Stamina = maxStamina;
        Role = "Thrower";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Strong Ram", "Depth Charge", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Strong Ram", "Depth Charge", "Deep Torpedoes", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground",
                                                    "Ram into target with an attack that makes the target <color=orange>Unsteady</color>",
                                                    "Drops explosives off the front, hitting all enemies with a regular attack", "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 1, 1, 0, 0 };

		base.Start ();
    }

    new void Update() {
    }

	// Charges forward with a ram
    public override int Skill1() {
        float variance = UnityEngine.Random.Range(.7f, 1.2f);
		int damage = (int)(1.5f * this.Damage * variance * attackMultiplier * Target [0].defenseMultiplier);
		Target[0].loseStamina(damage);
        Target[0].addStatusEffect("unsteady", 2);
        this.actionCooldowns[4] = 3;
		return damage;
    }

	// Drops explosives off the front
    public override int Skill2() {
        float variance;
		int damage = 0;
		variance = UnityEngine.Random.Range(0.7f, 1.0f);
        for (int i = 0; i < 3; i++) 
		{
			int partialDamage = (int)(this.Damage * variance * attackMultiplier * enemies [i].defenseMultiplier);
			damage += partialDamage;
			enemies[i].loseStamina(partialDamage);
        }
        this.actionCooldowns[5] = 2;
		return damage;
    }

	public override int Skill3() {
		return 0;
}

	public override int Skill4() {
		return 0;
    }
}
