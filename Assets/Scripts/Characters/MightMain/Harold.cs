using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harold : Character {
    
    new void Start() {
        Name = "Harold";
		Stamina = maxStamina;
        Role = "Thrower";
		actions = new string[]{ "None", "Throw", "Catch", "Gather", "Skill1", "Skill2", "Skill3", "Skill4" };
		actionNames = new string[]{ "None", "Throw", "Catch", "Gather", "Reactive Armor", "Suppressing Fire", "Heavy Bombardment", "Five Rounds Rapid" };
		actionDescription = new string[]{ "Wait", "Throw a ball at target enemy", "Attempt to catch any incoming balls", "Gather balls", 
											"If attacked this turn, catch the ball and gain steady", 
											"Counterattack when attacked on the next two turns", 
											"Charge for a turn then attack with a powerful strike against an enemy and becomes staggered", 
											"Throw five balls at a single target inaccurately" };
		actionTypes = new string[]{ "None", "Offense", "Defense", "Utility", "Defense", "Defense", "Offense", "Offense" };
		defaultTargetingTypes = new int[]{ 0, 1, 0, 0, 0, 0, 1, 1 };
		alternateTargetingTypes = new int[]{ 0, 1, 0, 0, 1, 1, 1, 1 };
		actionCosts = new int[]{ 0, 1, 0, 0, 0, 4, 6, 5 };

		base.Start ();
    }

    new void Update() {
		base.Update ();
		/*
        if (combat == null) {
            combat = GameObject.Find("CombatManager").GetComponent<CombatManager>();
        } else {
            if (allegiance == 1) { 
                this.targetingTypes = alternateTargetingTypes;
                allies = combat.Player;
                enemies = combat.Enemy;
            } else {
                this.targetingTypes = defaultTargetingTypes;
                allies = combat.Enemy;
                enemies = combat.Player;
            }
        }
        */
    }

	public new bool dodgeBall(Character attacker)
	{
		if(findStatus("misc") != -1)
		{
			this.throwBall (attacker);
		}
		return base.dodgeBall (attacker);
	}

	// Reactive Armor: If he is attacked on this turn, catch the ball and become steady
    public override bool Skill1() {
		this.heldBalls++;
		if(this.heldBalls > this.maxBalls)
		{
			this.heldBalls = this.maxBalls;
		}
		// adds steady for 1 turn
		addStatusEffect ("steady", 2);

        actionCooldowns[4] = 3;
		return false;
    }

	// Suppressing Fire: Counterattack when attacked on the next two turns
    public override bool Skill2() {
		addStatusEffect ("misc", 3);
		return true;
    }

	// Heavy Bombardment: Charges for a turn then attacks with a powerful strike against all enemies and becomes staggered
    public override bool Skill3() {
		if(findStatus("misc") != -1)
		{
			// This attack does stamina loss before checking for dodging
			Target[2].loseStamina((int)(Damage * 2 * attackMultiplier * Target[2].defenseMultiplier));
			Target[2].dodgeBall (this);
			addStatusEffect ("unsteady", 1);
		}
		else
		{
			addStatusEffect("misc", 2);
		}
		this.heldBalls -= actionCosts [6];
		return true;
    }

    public override bool Skill4() {
        //Five rounds rapid
        float variance = UnityEngine.Random.Range(.6f, 1.1f); //most likely to throw weaker variance
        for(int i = 0; i <= 5; i++) {
			Target[0].loseStamina((int)(this.attack * variance * attackMultiplier * Target[0].defenseMultiplier));
        }
		return true;
    }

	public override void cleanUp()
	{
		// Checks if Skill3 or Skill2 was used
		bool whichAction = false;
		if(action == "Skill3")
		{
			whichAction = true;
		}
		base.cleanUp ();

		// If getting ready for skill 3 set action and target for next turn
		if(findStatus("misc") != -1)
		{
			if(whichAction)
			{
				action = "Skill3";
				actionType = "Offense";
				Target [0] = Target [2];
				Target [1] = Target [2];
				CSUI.ShowTell ("Offense");
			}
		}
	}
}