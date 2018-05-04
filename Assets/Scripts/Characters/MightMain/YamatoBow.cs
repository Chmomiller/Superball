using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamatoBow : Yamato {
	
    
    void Start() {
        Name = "The Bow of the Imperial Japanese Battleship Yamato";
        Stamina = maxStamina;
        Role = "Thrower";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Strong Ram", "Depth Charge", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Strong Ram", "Depth Charge", "Deep Torpedoes", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground", "Charges forward with a ram", "Drops explosives off the front", "", "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 1, 1, 0, 0 };

		base.Start ();
    }

    void Update() {
    }

    public override bool Skill1() {
        float variance = UnityEngine.Random.Range(.7f, 1.2f);
		Target[0].loseStamina((int)(1.5f * this.Damage * variance * attackMultiplier * Target[0].defenseMultiplier));
        this.actionCooldowns[4] = 3;
        return true;
    }

    public override bool Skill2() {
        float variance;
		variance = UnityEngine.Random.Range(0.7f, 1.0f);
        for (int i = 0; i < 3; i++) 
		{
			enemies[i].loseStamina((int)(this.attack * variance * attackMultiplier * enemies[i].defenseMultiplier));
        }
        this.actionCooldowns[5] = 2;
   		return true;
    }

    public override bool Skill3() {
		return true;
}

    public override bool Skill4() {
		return false;
    }
}
