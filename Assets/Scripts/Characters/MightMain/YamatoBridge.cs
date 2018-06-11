using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamatoBridge : Yamato {
	
    
    new void Start() {
        Name = "The Bridge";
        Stamina = maxStamina;
        Role = "Supporter";

		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Observation Gathering", "Captain's Orders", "Hasty Repairs", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Observation Gathering", "Captain's Orders", "Hasty Repairs", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground",
                                                                            "Stuns each ally, but <color=orange>Buffs</color> it in return",
                                                                            "Attacks an enemy with an attack <color=red>50</color>% stronger, but the bridge becomes <color=orange>Steady</color> as well",
                                                                            "Each of the bridge’s allies gets <color=red>40</color> armor, but each ally becomes <color=orange>Unsteady</color> as well",
                                                                            "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Offensive", "Offensive", "Offensive", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 1, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 1, 1, 0, 0 };

		// Check to see if this overwrites stats correctly
		base.Start ();
    }

    new void Update() {
     
    }

	public override int Skill1() {
		for (int i = 0; i < 3; i++)
		{
			if (this.allies [i] != this && !allies [i].dead) 
			{
				allies [i].addStatusEffect ("stun", 1);
				allies [i].addStatusEffect ("buff", 3);
			}
        }

        this.actionCooldowns[4] = 4;
        return 0;
    }

    public override int Skill2() {
        float variance = UnityEngine.Random.Range(0.9f, 1.8f);
		int damage = (int)(Damage * .5 * variance * attackMultiplier * Target [0].defenseMultiplier);
		Target [0].loseStamina (damage);
        this.addStatusEffect("steady", 2);
        this.actionCooldowns[5] = 2;
		return damage;
    }

    public override int Skill3() {
        for(int i = 0; i< 3; i++) {
			if(allies[i] != this)
			{
				allies [i].gainStamina (40);
                if (allies[i].Stamina > allies[i].maxStamina) allies[i].Stamina = allies[i].maxStamina;
				addStatusEffect ("unsteady", 2);
			}
        }
        this.actionCooldowns[6] = 3;
		return 0;
}

    public override int Skill4() {
		return 0;
    }
}
