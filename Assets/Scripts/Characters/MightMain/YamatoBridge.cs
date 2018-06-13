using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YamatoBridge : Yamato {
	
    
    new void Start() {
        Name = "The Bridge";
        Stamina = maxStamina;
        Role = "Supporter";
	
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Observation Gathering", "Captain's Orders", "Hasty Repairs", "Skill4" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls from the ground",
                                          "<color=yellow>Stun</color> each ally for 1 turn, but <color=blue>Buff</color> them for 3. <color=red>4</color> turn cooldown.\nCost: 1    Target: Ally Team",
                                          "Fire a <b>hard-hitting</b> attack at an enemy with and become <color=lime>steady</color> for 2 turns. <color=red>2</color> turn cooldown.\nCost: 1    Target: Single Enemy",
										  "Repair each ally for 40 armor(stamina), but make them <color=orange>unsteady</color> too. <color=red>3</color> turn cooldown.\nCost: None    Target: Ally Team",
                                          "" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Offense", "Utility", "Utility" };
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
				allies [i].addStatusEffect (STATUS.STUN, 1);
				allies [i].addStatusEffect (STATUS.BUFF, 3);
			}
        }

		this.heldBalls -= this.actionCosts [4];
        this.actionCooldowns[4] = 4;
        return 0;
    }

    public override int Skill2() {
        float variance = UnityEngine.Random.Range(0.9f, 1.8f);
		int damage = (int)(Damage * .5 * variance * attackMultiplier * Target [0].defenseMultiplier);
		Target [0].loseStamina (damage);
		this.addStatusEffect(STATUS.STEADY, 2);
		this.heldBalls -= this.actionCosts [5];
        this.actionCooldowns[5] = 2;
		return damage;
    }

    public override int Skill3() {
        for(int i = 0; i< 3; i++) {
			if(allies[i] != this && !allies[i].dead)
			{
				allies [i].gainStamina (40);
				allies[i].addStatusEffect (STATUS.UNSTEADY, 1);
			}
        }
		this.heldBalls -= this.actionCosts [6];
        this.actionCooldowns[6] = 3;
		return 0;
}

    public override int Skill4() {
		return 0;
    }
}
