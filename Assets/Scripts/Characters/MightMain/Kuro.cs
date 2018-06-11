using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kuro : Character {

    new void Start() {
        Name = "Kuro";
        Stamina = maxStamina;
        Role = "Catcher";

		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Smokescreen", "Safe Haven", "Lord of the Seven Seas", "Cannon Adjustments" };
		actionDescription = new string[]{ "Wait", "Throw ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"<color=lime>Steady</color> your team for one turn. <color=red>2</color> cooldown.\nCost: None    Target: Ally Team", 
											"Catch for your team. <color=red>1</color> turn cooldown.\nCost: None    Target: Ally Team", 
											"Charge up for a turn before unleashing an attack against all enemies. <color=red>2</color> turn cooldown.\nCost: 3    Target: Enemy Team",
                                            "<color=orange>Buff</color> your team for a turn.\nCost: 4    Target: Ally Team" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Utility", "Defense", "Offense", "Utility" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 0, 0 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 0, 3, 4 };

		base.Start ();
    }

    // Update is called once per frame
    new void Update() {
		base.Update ();
		/*
        if (allegiance == 1) {
            this.targetingTypes = alternateTargetingTypes;
            allies = combat.Player;
            enemies = combat.Enemy;
        } else {
            this.targetingTypes = defaultTargetingTypes;
            allies = combat.Enemy;
            enemies = combat.Player;
        }
        */
    }

	// Smokescreen: Steady your team
	public override int Skill1() {
		for(int i = 0; i < 3; i++)
		{
			allies [i].addStatusEffect ("steady", 2);
		}
        actionCooldowns[4] = 3;
		return 0;
    }

	// Safe Haven: Catch for the whole team
	public override int Skill2() { 
		for(int i = 0; i < 3; i++)
		{
			if(enemies[i].actionType == "Offense")
			{
				enemies [i].Target [0] = this;
			}
		}
		actionCooldowns [5] = 2;
		return 0;
	}

	// Lord of the Seven Seas: Charge up for a turn before unleashing an attack against all enemies
	public override int Skill3() { 
		int damage = 0;
		if(findStatus("misc") != -1)
		{
			for(int i = 0; i < 3; i++)
			{
				// This attack does stamina loss before checking for dodging
				int partialDamage = (int)(Damage * 1.5f * attackMultiplier * enemies[i].defenseMultiplier);
				enemies[i].loseStamina(partialDamage);
				damage += partialDamage;
				enemies [i].dodgeBall (this);
			}
		}
		else
		{
			addStatusEffect("misc", 2);
		}
		this.heldBalls -= actionCosts [6];
		actionCooldowns [6] = 3;
		return damage;
	}

	// Cannon Adjustments: Buff your team
	public override int Skill4() { 
		for(int i = 0; i < 3; i++)
		{
			enemies [i].addStatusEffect ("buff",2);
		}
        this.heldBalls -= this.actionCosts[7];
		return 0;
	}

	public override void cleanUp()
	{
		base.cleanUp ();

		// If getting ready for skill 3 set action for next turn
		if(findStatus("misc") != -1)
		{
			action = "Skill3";
			actionType = "Offense";
			CSUI.ShowTell ("Offense");
		}
	}
}
